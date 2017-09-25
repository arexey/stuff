using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace CardMaker
{
    public partial class TfsConnectForm : Form
    {
        private List<string> AreaPathNodes;
        public List<string> IterationPathNodes { get; set; }
        public List<string> QueryNodes { get; set; }
        public List<string> FieldList { get; set; } 
        public TfsConfig TfsConfig { get; set; }

        public TfsConnectForm()
        {
            InitializeComponent();

            TfsConfig = new TfsConfig();
            ResetLists();

            UpdateControls(true);
        }

        private void ResetLists()
        {
            AreaPathNodes = new List<string>();
            IterationPathNodes = new List<string>();
            QueryNodes = new List<string>();
            FieldList = new List<string>();
        }

        private void projectPickerButton_Click(object sender, EventArgs e)
        {
            var picker = new TeamProjectPicker(TeamProjectPickerMode.SingleProject,
                false);

            var result = picker.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                var selectedProject = picker.SelectedProjects[0];
                TfsConfig.ProjectCollectionUrl = picker.SelectedTeamProjectCollection.Uri.ToString();
                TfsConfig.ProjectName = selectedProject.Name;

                var workItemStore = picker.SelectedTeamProjectCollection.GetService<WorkItemStore>();

                ResetLists();

                PopulateNodesList(
                    workItemStore.Projects[selectedProject.Name].AreaRootNodes.OfType<Node>(), 
                    AreaPathNodes,
                    n => n.Path,
                    n=>n.HasChildNodes,
                    n=>n.ChildNodes.OfType<Node>());
                PopulateNodesList(
                    workItemStore.Projects[selectedProject.Name].IterationRootNodes.OfType<Node>(), 
                    IterationPathNodes,
                    n => n.Path,
                    n=>n.HasChildNodes,
                    n=>n.ChildNodes.OfType<Node>());

                PopulateNodesList(
                    workItemStore.Projects[selectedProject.Name].QueryHierarchy,
                    QueryNodes,
                    n => n.Path,
                    n => n is QueryFolder,
                    n => (QueryFolder) n);

                FieldList.AddRange(
                    workItemStore.FieldDefinitions
                        .OfType<FieldDefinition>()
                        .Select(fd => fd.Name)
                        .OrderBy(fn => fn));
            }
            UpdateControls();
        }

        public static void PopulateNodesList<T>(
            IEnumerable<T> nodes, 
            List<string> nodeList, 
            Func<T, string> nodeToValue,
            Func<T, bool> hasChildren,
            Func<T, IEnumerable<T>> getChildren)
        {
            foreach (var node in nodes)
            {
                nodeList.Add(nodeToValue(node));
                if (hasChildren(node))
                {
                    PopulateNodesList(getChildren(node), nodeList, nodeToValue, hasChildren, getChildren);
                }
            }
        }

        private void UpdateControls(bool isNew = false)
        {
            projectCollectionUrlTextBox.Text = TfsConfig.ProjectCollectionUrl;
            projectNameTextBox.Text = TfsConfig.ProjectName;

            areaBasePathComboBox.Items.Clear();
            areaBasePathComboBox.Items.AddRange(AreaPathNodes.Cast<object>().ToArray());

            iterationBasePathComboBox.Items.Clear();
            iterationBasePathComboBox.Items.AddRange(IterationPathNodes.Cast<object>().ToArray());

            queryBasePathComboBox.Items.Clear();
            queryBasePathComboBox.Items.AddRange(QueryNodes.Cast<object>().ToArray());

            teamFieldComboBox.Items.Clear();
            teamFieldComboBox.Items.AddRange(FieldList.Cast<object>().ToArray());

            costFieldComboBox.Items.Clear();
            costFieldComboBox.Items.AddRange(FieldList.Cast<object>().ToArray());

            if (!isNew)
            {
                areaBasePathComboBox.SelectedIndex =
                    iterationBasePathComboBox.SelectedIndex =
                        queryBasePathComboBox.SelectedIndex = 0;

                SetFieldValue(teamFieldComboBox, new[] {"Feature Crew", "Keywords"});
                SetFieldValue(costFieldComboBox, new[] {"Cost", "Story Point Estimate"});
            }
        }

        private void SetFieldValue(ComboBox fieldComboBox, IEnumerable<string> candidateNames)
        {
            var item = candidateNames.FirstOrDefault(fieldName => fieldComboBox.Items.Contains(fieldName));
            if (!String.IsNullOrWhiteSpace(item))
            {
                fieldComboBox.SelectedItem = item;
            }
        }

        private void areaBasePathComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TfsConfig.AreaPathBase = areaBasePathComboBox.SelectedItem.ToString();
        }

        private void iterationBasePathComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TfsConfig.IterationBasePath = iterationBasePathComboBox.SelectedItem.ToString();
        }

        private void queryBasePathComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TfsConfig.ExpandPaths = new[]
            {
                TfsConfig.ProjectName + "/My Queries",
                queryBasePathComboBox.SelectedItem.ToString()
            };
        }

        private void teamFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TfsConfig.TeamFieldName = teamFieldComboBox.SelectedItem.ToString();
        }

        private void costFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TfsConfig.CostFieldName = costFieldComboBox.SelectedItem.ToString();
        }
    }
}
