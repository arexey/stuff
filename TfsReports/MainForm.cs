using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardMaker.Model;
using Microsoft.TeamFoundation;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.VisualStudio.Services.Location;
using Newtonsoft.Json;

namespace CardMaker
{
    public partial class MainForm : Form
    {
        private WorkItemStore workItemStore;
        private QueryHierarchy queryHierarchy;
        private TfsConfig tfsConfig;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTfsConfig();

            reportTypeComboBox.SelectedIndex = 0;

            bool connected = false;
            while (!connected)
            {
                try
                {
                    PopulateQueryTree();
                    connected = true;
                }
                catch (TeamFoundationServerException)
                {
                    ConfigureTfs(true);
                }
            }
        }

        private void PopulateQueryTree()
        {
            var tfsUri = new Uri(tfsConfig.ProjectCollectionUrl);
            TfsTeamProjectCollection tpc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(tfsUri);
            workItemStore = tpc.GetService<WorkItemStore>();
            var projectName = tfsConfig.ProjectName;
            queryHierarchy = workItemStore.Projects[projectName].QueryHierarchy;
            queryHierarchy.Refresh();

            var rootNode = new TreeNode(projectName);
            queryHierarchyTreeView.Nodes.Clear();
            queryHierarchyTreeView.Nodes.Add(rootNode);

            PopulateChildren(rootNode, queryHierarchy);

            rootNode.Expand();

            queryHierarchyTreeView.NodeMouseDoubleClick += treeView1_NodeMouseDoubleClick;

            queryHierarchyTreeView.Refresh();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node;

            if (node.Tag != null && !(node.Tag is QueryFolder))
            {
                var item = node.Tag as QueryItem;

                ShowReport(item);
            }
        }

        private void ShowReport(QueryItem query)
        {
            var queryDefinition = workItemStore.GetQueryDefinition(query.Id);

            if (queryDefinition.QueryType != QueryType.List)
            {
                MessageBox.Show(@"Only List queries are supported. This query is of type: " + queryDefinition.QueryType);
                return;
            }

            var ds = new WorkItemsDataSource
            {
                WorkItems = new List<WorkItemsData>()
            };

            reportProgressBar.Value = 0;
            reportViewer.Visible = false;
            progressPanel.Visible = true;
            progressPanel.Refresh();

            var t = new Task(() =>
            {
                var result = workItemStore.Query(
                    queryDefinition.QueryText,
                    new Dictionary<string, string>
                    {
                        {"project", tfsConfig.ProjectName},
                        {"Project", tfsConfig.ProjectName}
                    });

                var increment = (int) Math.Ceiling(100.0/result.Count);

                ThreadCallback d;
                foreach (WorkItem workItem in result)
                {

                    // useful for getting complete list of fields during debugging
                    //var fieldNames = workItem.Fields.OfType<Field>().Select(f => f.Name).ToArray();

                    var item = new WorkItemsData
                    {
                        Id = workItem.Id,
                        ItemType = workItem.Type.Name,
                        Title = workItem.Title,
                        AssignedTo = GetValue(workItem, "Assigned To", ""),
                        Rank = GetValue(workItem, "Rank", 0),
                        Cost = GetValue(workItem, tfsConfig.CostFieldName, 0),
                        Keywords = GetValue(workItem, tfsConfig.TeamFieldName, ""),
                        Team = GetTeamName(GetValue(workItem, tfsConfig.TeamFieldName, "")),
                        Iteration = workItem.IterationPath,
                        IterationSubPath = workItem.IterationPath.Replace(tfsConfig.IterationBasePath + "\\", ""),
                        Area = workItem.AreaPath,
                        AreaSubPath = workItem.AreaPath.Replace(tfsConfig.AreaPathBase + "\\", ""),
                        Description = workItem.Description
                    };
                    ds.WorkItems.Add(item);

                    d = delegate
                    {
                        reportProgressBar.Value = Math.Min(100, reportProgressBar.Value + increment);
                    };
                    reportProgressBar.Invoke(d);
                    Thread.Sleep(300);
                }
                d = delegate { reportProgressBar.Value = 100; };
                reportProgressBar.Invoke(d);
                //Thread.Sleep(400);
            });
            var a = t.GetAwaiter();
            a.OnCompleted(delegate
            {
                WorkItemsDataSourceBindingSource.DataSource = ds.WorkItems;
                progressPanel.Visible = false;
                reportViewer.Visible = true;
                reportViewer.RefreshReport();
            });
            t.Start();
        }

        private string GetTeamName(string keywords)
        {
            var firstKeyword = keywords
                .Split(new[] {',', ';'}, StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault();
            if (firstKeyword != null)
            {
                return firstKeyword
                    .Trim()
                    .ToLower();
            }
            return String.Empty;
        }

        private delegate void ThreadCallback();

        private static string GetValue(WorkItem workItem, string fieldName, object fallbackValue)
        {
            if (!workItem.Fields.Contains(fieldName))
            {
                return fallbackValue.ToString();
            }
            return (workItem[fieldName] ?? fallbackValue).ToString();
        }

        private void PopulateChildren(TreeNode treeNode, IEnumerable<QueryItem> folder)
        {
            foreach (var item in folder)
            {
                var node = new TreeNode(item.Name) {Tag = item};
                node.ImageIndex = node.SelectedImageIndex = 1;
                treeNode.Nodes.Add(node);
                if (item is QueryFolder)
                {
                    node.ImageIndex = node.SelectedImageIndex = 0;
                    PopulateChildren(node, item as QueryFolder);
                }
                if (tfsConfig.ExpandPaths.Any(path => item.Path.Equals(path, StringComparison.InvariantCultureIgnoreCase)))
                {
                    node.Expand();
                    node.EnsureVisible();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PopulateQueryTree();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            ConfigureTfs();
        }

        private void ConfigureTfs(bool mustPick = false)
        {
            var connectForm = new TfsConnectForm();
            var done = false;
            while (!done)
            {
                var result = connectForm.ShowDialog(this);
                if (result == DialogResult.OK && !String.IsNullOrWhiteSpace(connectForm.TfsConfig.ProjectCollectionUrl))
                {
                    tfsConfig = connectForm.TfsConfig;
                    done = true;
                }
                if (!mustPick)
                {
                    done = true;
                }
            }
            SaveTfsConfig();
            PopulateQueryTree();
        }

        private void SaveTfsConfig()
        {
            File.WriteAllText("CardMaker.settings", JsonConvert.SerializeObject(tfsConfig));
        }

        private void LoadTfsConfig()
        {
            if (File.Exists("CardMaker.settings"))
            {
                var content = File.ReadAllText("CardMaker.settings");
                tfsConfig = JsonConvert.DeserializeObject<TfsConfig>(content);
            }
            else
            {
                ConfigureTfs(true);
            }
        }

        private void reportTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            WorkItemsDataSourceBindingSource.DataSource = typeof(WorkItemsDataSource);
            WorkItemsDataSourceBindingSource.DataMember = "WorkItems";

            reportDataSource1.Name = "WorkItemsDataSet";
            if (reportTypeComboBox.SelectedIndex == 1)
            {
                reportViewer.LocalReport.ReportEmbeddedResource = "CardMaker.SmallCards.rdlc";
            }
            else if (reportTypeComboBox.SelectedIndex == 2)
            {
                reportViewer.LocalReport.ReportEmbeddedResource = "CardMaker.SmallCardsCompact.rdlc";
            }
            else if (reportTypeComboBox.SelectedIndex == 3)
            {
                reportViewer.LocalReport.ReportEmbeddedResource = "CardMaker.SmallCardsUltraCompact.rdlc";
            }
            else
            {
                reportDataSource1.Name = "WorkItems";
                reportViewer.LocalReport.ReportEmbeddedResource = "CardMaker.StoryCard.rdlc";                
            }
            
            reportDataSource1.Value = WorkItemsDataSourceBindingSource;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource1);

        }

        private void loadDataButton_Click(object sender, EventArgs e)
        {
            projectButton.Enabled = false;

            LoadData();

            teamsToShowCheckBoxList.Items.Clear();
            foreach (var team in FogTeamNames)
            {
                teamsToShowCheckBoxList.Items.Add(team, false);
            }
            teamsToShowCheckBoxList.ItemCheck += (o, args) =>
            {
                if (args.NewValue == CheckState.Checked)
                {
                    FillCapacityTable((string) teamsToShowCheckBoxList.Items[args.Index]);
                }
                else
                {
                    FillCapacityTable(@"", (string) teamsToShowCheckBoxList.Items[args.Index]);

                }
            };

            startIterationComboBox.Items.AddRange(FogIterationNames.Cast<object>().ToArray());
            startIterationComboBox.SelectedIndex = 0;
            startIterationComboBox.SelectedIndexChanged += (o, args) => FillCapacityTable();

            FillCapacityTable();

            projectButton.Enabled = true;
        }

        private IEnumerable<WorkItemsData> LoadData()
        {
            printButton.Enabled = false;
            refreshButton.Enabled = false;
            projectionTableLayoutPanel.Visible = false;

            var queryResult = workItemStore.Query(@"
SELECT 
    [System.Id], 
    [System.WorkItemType],
    [System.Title],
    [System.AssignedTo],
    [System.State],
    [System.Tags],
    [Microsoft.VSTS.Common.Keywords],
    [System.AreaPath],
    [System.IterationPath]
FROM
    WorkItems
WHERE
    [System.TeamProject] = @project AND
    [System.WorkItemType] = 'Task' AND
    [System.State] <> '#Closed#' AND
    [System.AreaPath] UNDER 'OSGS\OSGS-OSG Services\Marketplace\ME-Marketplace Engagement' AND
    [System.IterationPath] UNDER 'OSGS\Threshold'
ORDER BY
    [System.IterationPath]",
                new Dictionary<string, string>
                {
                    {"project", tfsConfig.ProjectName},
                    {"Project", tfsConfig.ProjectName}
                });

            var workItems = new List<WorkItemsData>(queryResult.Count);

            workItems.AddRange(queryResult.Cast<WorkItem>().Select(item =>
            {
                var iterationSubPath = item.IterationPath.Replace(tfsConfig.IterationBasePath + "\\", "");
                var firstLevelIteration =
                    iterationSubPath == tfsConfig.IterationBasePath
                        ? ""
                        : iterationSubPath.Split('\\')[0];
                var data = new WorkItemsData
                {
                    Id = item.Id,
                    ItemType = item.Type.Name,
                    Title = item.Title,
                    AssignedTo = GetValue(item, "Assigned To", ""),
                    State = item.State,
                    Rank = GetValue(item, "Rank", 0),
                    Cost = GetValue(item, tfsConfig.CostFieldName, 0),
                    Keywords = GetValue(item, tfsConfig.TeamFieldName, ""),
                    Team = GetTeamName(GetValue(item, tfsConfig.TeamFieldName, "")),
                    Iteration = item.IterationPath,
                    IterationSubPath = iterationSubPath,
                    FirstLevelIteration = firstLevelIteration,
                    Area = item.AreaPath,
                    AreaSubPath = item.AreaPath.Replace(tfsConfig.AreaPathBase + "\\", ""),
                    Description = item.Description,
                    ItemUrl = String.Format("{0}/{1}/_workitems#_a=edit&id={2}",
                        tfsConfig.ProjectCollectionUrl,
                        tfsConfig.ProjectName,
                        item.Id)
                };

                data.Team = !String.IsNullOrWhiteSpace(data.Team) ? data.Team : "(unassigned)";

                return data;
            }));

            FogWorkItems = workItems;

            var iterationNodes = new List<string>();
            TfsConnectForm.PopulateNodesList(
                workItemStore.Projects[tfsConfig.ProjectName].IterationRootNodes.OfType<Node>(),
                iterationNodes,
                n => n.Path,
                n => n.HasChildNodes,
                n => n.ChildNodes.OfType<Node>());

            FogIterationNames = iterationNodes
                .Where(n => n.StartsWith(tfsConfig.IterationBasePath) && n != tfsConfig.IterationBasePath)
                .Select(
                    n =>
                        n == tfsConfig.IterationBasePath
                            ? tfsConfig.IterationBasePath
                            : n.Replace(tfsConfig.IterationBasePath + "\\", ""))
                .Where(n => !n.Contains("\\"))
                .Distinct();

            FogTeamNames = workItems.Select(wi => wi.Team.ToLower()).Distinct();

            return workItems;
        }

        public void FillCapacityTable(string includeTeam = "", string excludeTeam = "")
        {
            capacityTable.SuspendLayout();

            capacityTable.Controls.Clear();
            capacityTable.RowCount = 1;
            capacityTable.ColumnCount = 2;

            var lbl = new Label { Text = @"Team" };
            capacityTable.Controls.Add(lbl);
            capacityTable.SetRow(lbl, 0);
            capacityTable.SetColumn(lbl, 0);

            var iterations = FogIterationNames
                .Where(
                    name =>
                        startIterationComboBox.SelectedItem == null ||
                        String.Compare(name, (string) startIterationComboBox.SelectedItem,
                            StringComparison.InvariantCultureIgnoreCase) >= 0)
                .ToArray();

            var currentColumn = 1;
            foreach (var iteration in iterations)
            {
                capacityTable.ColumnCount++;
                capacityTable.LayoutSettings.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                lbl = new Label { Text = iteration, AutoSize = true };
                capacityTable.Controls.Add(lbl);
                capacityTable.SetRow(lbl, 0);
                capacityTable.SetColumn(lbl, currentColumn);

                currentColumn++;
            }

            CapacityControls = new Dictionary<string, Dictionary<string, TextBox>>();

            var currentRow = 1;
            var teamNames = teamsToShowCheckBoxList.CheckedItems
                .Cast<string>().Where(team => team != excludeTeam);
            if (includeTeam != String.Empty)
            {
                teamNames = teamNames.
                Concat(new[] {includeTeam});
            }
            teamNames = teamNames.OrderBy(team => teamsToShowCheckBoxList.Items.IndexOf(team));

            foreach (var teamName in teamNames)
            {
                if (!CapacityControls.ContainsKey(teamName))
                {
                    CapacityControls.Add(teamName, new Dictionary<string, TextBox>());
                }

                capacityTable.RowCount++;
                var teamLabel = new Label
                {
                    Text = teamName
                };
                capacityTable.Controls.Add(teamLabel);
                capacityTable.SetColumn(teamLabel, 0);
                capacityTable.SetRow(teamLabel, currentRow);

                currentColumn = 1;
                foreach (var iteration in iterations)
                {
                    var capacityTextBox = new TextBox
                    {
                        Text = @"100",
                        Width = 50,
                        AutoSize = true
                    };
                    capacityTable.Controls.Add(capacityTextBox);
                    capacityTable.SetColumn(capacityTextBox, currentColumn);
                    capacityTable.SetRow(capacityTextBox, currentRow);

                    CapacityControls[teamName].Add(iteration, capacityTextBox);

                    currentColumn++;
                }


                currentRow++;
            }
            capacityTable.ResumeLayout();
        }

        public Dictionary<string, Dictionary<string, TextBox>> CapacityControls { get; set; }

        public IEnumerable<string> FogTeamNames { get; set; }

        private void SortAndDisplayData(IEnumerable<WorkItemsData> workItems)
        {
            printButton.Enabled = false;
            //projectionTableLayoutPanel.Visible = false;
            projectionProgressPanel.Visible = true;
            projectionProgressBar.Value = 0;

            var t = new Task(() =>
            {
                var itemsToDisplay =
                    (workItems as IList<WorkItemsData> ?? workItems.ToList()).Where(
                        wi => teamsToShowCheckBoxList.CheckedItems.Contains(wi.Team) &&
                            (wi.State != "Closed" || wi.FirstLevelIteration != ""))
                        .ToList();

                var sortedData = new SortedData
                {
                    Teams = new Dictionary<string, TeamData>(),
                    WorkItems = itemsToDisplay.OrderBy(i => i.State == "Closed" ? 0 : 1).ThenBy(wi => wi.Rank)
                };

                var teamsToProject = teamsToShowCheckBoxList.CheckedItems.Cast<string>().ToList();
                var teamCount = teamsToProject.Count;
                var counter = 0;

                foreach (var team in teamsToProject)
                {
                    var currentTeam = team;

                    var teamWorkItems = itemsToDisplay
                        .Where(
                            wi => String.Compare(wi.Team, currentTeam, StringComparison.InvariantCultureIgnoreCase) == 0)
                        .OrderBy(wi => wi.Rank);

                    var teamData = new TeamData
                    {
                        TeamName = team,
                        WorkItems = teamWorkItems,
                        Areas = new Dictionary<string, AreaData>()
                    };

                    var areas = teamWorkItems.Select(wi => wi.AreaSubPath).Distinct();

                    foreach (var area in areas)
                    {
                        var currentArea = area;
                        var areaWorkItems = teamWorkItems
                            .Where(wi => wi.AreaSubPath == currentArea)
                            .OrderBy(wi => wi.Rank);

                        var areaData = new AreaData
                        {
                            AreaName = area,
                            WorkItems = areaWorkItems,
                            Iterations = new Dictionary<string, List<WorkItemsData>>()
                        };

                        teamData.Areas.Add(areaData.AreaName, areaData);
                    }

                    sortedData.Teams.Add(teamData.TeamName, teamData);

                    counter ++;
                    SetProgressValue(Math.Min(10, (int)Math.Ceiling(10.0*counter/teamCount)));
                }

                var startIteration = "";
                startIterationComboBox.Invoke(new Action(() => startIteration = (string) startIterationComboBox.SelectedItem));

                sortedData.IterationNames =
                    FogIterationNames
                        .Where(
                            name =>
                                String.IsNullOrWhiteSpace(startIteration)||
                                String.Compare(name,
                                    startIteration,
                                    StringComparison.InvariantCultureIgnoreCase) >= 0)
                        .ToList();

                foreach (var workItem in itemsToDisplay.Where(wi => wi.FirstLevelIteration != "").OrderBy(wi => wi.Rank))
                {
                    if (
                        !sortedData.Teams[workItem.Team.ToLower()].Areas[workItem.AreaSubPath].Iterations.ContainsKey(
                            workItem.FirstLevelIteration))
                    {
                        sortedData.Teams[workItem.Team.ToLower()].Areas[workItem.AreaSubPath].Iterations.Add(
                            workItem.FirstLevelIteration, new List<WorkItemsData>());
                    }
                    sortedData.Teams[workItem.Team.ToLower()].Areas[workItem.AreaSubPath].Iterations[
                        workItem.FirstLevelIteration]
                        .Add
                        (workItem);
                }

                SetProgressValue(25);

                var itemsToProject = itemsToDisplay
                    .Where(item => item.FirstLevelIteration == "")
                    .ToList();

                counter = 0;

                foreach (var team in teamsToProject)
                {
                    string currentTeam = team;
                    var teamItemsToProject =
                        new Stack<WorkItemsData>(itemsToProject.Where(item => item.Team == currentTeam));
                    foreach (var iteration in sortedData.IterationNames)
                    {
                        string currentIteration = iteration;
                        int capacity;
                        int.TryParse(CapacityControls[team][iteration].Text, out capacity);

                        foreach (var a in sortedData.Teams[team].Areas.Values)
                        {
                            foreach (var i in a.Iterations.Where(iter => iter.Key == currentIteration))
                            {
                                capacity -= i.Value.Sum(iter => int.Parse(iter.Cost));
                            }
                        }

                        while (teamItemsToProject.Count > 0 && capacity > 0)
                        {
                            var item = teamItemsToProject.Peek();

                            AreaData area;
                            if (!sortedData.Teams[team].Areas.ContainsKey(item.AreaSubPath))
                            {
                                area = new AreaData
                                {
                                    AreaName = item.AreaSubPath,
                                    Iterations = new Dictionary<string, List<WorkItemsData>>()
                                };
                                sortedData.Teams[team].Areas.Add(item.AreaSubPath, area);
                            }
                            else
                            {
                                area = sortedData.Teams[team].Areas[item.AreaSubPath];
                            }

                            List<WorkItemsData> iterationItems;
                            if (!area.Iterations.TryGetValue(iteration, out iterationItems))
                            {
                                iterationItems = new List<WorkItemsData>();
                                area.Iterations.Add(iteration, iterationItems);
                            }

                            int cost;
                            int.TryParse(item.Cost, out cost);

                            if (capacity - cost >= 0)
                            {
                                iterationItems.Add(teamItemsToProject.Pop());
                            }
                            capacity -= cost;
                        }
                    }
                    counter++;
                    SetProgressValue(25 + Math.Min(25, (int) Math.Ceiling(25.0*counter/teamCount)));
                }

                SetProgressValue(50);

                var builder = new ControlTableLayoutBuilder();

                builder.BuildLayout(
                    projectionTableLayoutPanel, 
                    sortedData, 
                    progress => SetProgressValue(50 + Math.Min(50, (int) Math.Ceiling(50.0*progress/100.0))));

            });
            t.ContinueWith(task =>
            {
                projectionTableLayoutPanel.Invoke(new Action(() => projectionTableLayoutPanel.Visible = true));
                printButton.Invoke(new Action(() =>
                {
                    printButton.Enabled = true;
                    refreshButton.Enabled = true;
                }));
                projectionProgressPanel.Invoke(new Action(() => projectionProgressPanel.Visible = false));
            });
            t.Start();
        }

        private void SetProgressValue(int progressValue)
        {
            var d = new Action(() => { projectionProgressBar.Value = progressValue; });
            projectionProgressBar.Invoke(d);
        }

        public IEnumerable<WorkItemsData> FogWorkItems { get; set; }
        public IEnumerable<string> FogIterationNames { get; set; }

        private void projectButton_Click(object sender, EventArgs e)
        {
            SortAndDisplayData(FogWorkItems);
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            var document = new PrintDocument();

            document.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("Tabloid", 11, 17);

            var bitmap = new Bitmap(projectionTableLayoutPanel.Width, projectionTableLayoutPanel.Height);
            projectionTableLayoutPanel.DrawToBitmap(bitmap, new Rectangle(new Point(), projectionTableLayoutPanel.Size));

            int offsetX = 0, offsetY = 0;
            document.PrintPage += (o, args) =>
            {
                args.Graphics.DrawImage(
                    bitmap, 
                    args.PageBounds,
                    new Rectangle(offsetX, offsetY, args.PageBounds.Width, args.PageBounds.Height),
                    GraphicsUnit.Pixel);

                offsetX += args.PageBounds.Width;
                args.HasMorePages = true;
                if (offsetX > bitmap.Width)
                {
                    offsetX = 0;
                    offsetY += args.PageBounds.Height;
                    if (offsetY > bitmap.Height)
                    {
                        args.HasMorePages = false;
                        return;
                    }
                    args.HasMorePages = true;
                }
                if (args.HasMorePages)
                {
                    return;
                }
            };

            var dialog = new PrintDialog
            {
                Document = document,
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            IEnumerable<WorkItemsData> workItems = LoadData();
            SortAndDisplayData(workItems);
        }
    }

    public class ControlTableLayoutBuilder : ILayoutBuilder<TableLayoutPanel>
    {
        public void BuildLayout(TableLayoutPanel container, SortedData sortedData, Action<int> progressUpdateAction)
        {
            container.Invoke(new Action(() =>
            {
                container.SuspendLayout();

                container.Controls.Clear();
                container.RowCount = 1;
                container.ColumnCount = 1;
                container.LayoutSettings.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                container.RowCount = sortedData.Teams.Count + 1;
                container.ColumnCount = 1;

                container.LayoutSettings.RowStyles.Clear();
                container.LayoutSettings.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                container.RowCount = 1;
            }));

            var lbl = new Label
            {
                Font = new Font("Arial", 18),
                Text = @"Team"
            };
            AddControlToTable(container, lbl, 0, 0);

            container.Invoke(new Action(() =>
            {
                container.ColumnCount++;
                container.LayoutSettings.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }));

            lbl = new Label
            {
                Font = new Font("Arial", 18),
                Text = @"Area",
                AutoSize = true
            };
            AddControlToTable(container, lbl, 0, 1);

            var iterationIndex = new Dictionary<string, int>();
            var count = 0;
            foreach (var iteration in sortedData.IterationNames)
            {
                container.Invoke(new Action(() =>
                {
                    container.ColumnCount++;
                    container.LayoutSettings.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                }));

                lbl = new Label
                {
                    Font = new Font("Arial", 18),
                    Text = iteration,
                    AutoSize = true
                };
                AddControlToTable(container, lbl, 0, count + 2);

                iterationIndex.Add(iteration, count + 2);

                count++;
            }

            progressUpdateAction(10);

            var currentRow = 0;

            var teamCount = sortedData.Teams.Values.Count;
            count = 0;

            foreach (var team in sortedData.Teams.Values)
            {
                container.Invoke(new Action(() =>
                {
                    container.RowCount++;
                    container.LayoutSettings.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }));

                var teamLabel = new Label
                {
                    Text = team.TeamName,
                    Font = new Font("Arial", 18),
                    AutoSize = true
                };

                var areaRow = 0;
                foreach (var area in team.Areas.Values)
                {
                    if (areaRow > 0)
                    {
                        container.Invoke(new Action(() =>
                        {
                            container.RowCount++;
                        }));
                    }
                    var areaLabel = new Label
                    {
                        Text = area.AreaName,
                        Font = new Font("Arial", 16),
                        AutoSize = true
                    };
                    AddControlToTable(container, areaLabel, currentRow + areaRow + 1, 1);

                    foreach (var iteration in sortedData.IterationNames)
                    {
                        if (area.Iterations.ContainsKey(iteration))
                        {
                            var item =
                                area.Iterations[iteration]
                                    .OrderBy(i => i.Rank);

                            var panel = new FlowLayoutPanel
                            {
                                FlowDirection = FlowDirection.LeftToRight,
                                AutoSize = true
                            };

                            AddControlToTable(container, panel, currentRow + areaRow + 1, iterationIndex[iteration]);

                            var d = new Action(() =>
                            {
                                foreach (var itemsData in item)
                                {
                                    var itemPanel = new FlowLayoutPanel
                                    {
                                        Width = 100,
                                        FlowDirection = FlowDirection.TopDown,
                                        BackColor =
                                            !String.IsNullOrEmpty(itemsData.FirstLevelIteration)
                                                ? Color.ForestGreen
                                                : Color.YellowGreen,
                                        BorderStyle = BorderStyle.FixedSingle,
                                        AutoSize = true,
                                        WrapContents = false,
                                        MaximumSize = new Size(100, 400),
                                        Size = new Size(100, 100)
                                    };
                                    itemPanel.BackColor = Color.Green;
                                    var idLabel = new LinkLabel
                                    {
                                        Text = @"ID: " + itemsData.Id,
                                        AutoSize = true,
                                        Tag = itemsData.ItemUrl
                                    };
                                    idLabel.Click += idLabel_Click;
                                    itemPanel.Controls.Add(idLabel);
                                    var stateLabel = new Label
                                    {
                                        Text = @"State: " + itemsData.State,
                                        AutoSize = true
                                    };
                                    itemPanel.Controls.Add(stateLabel);
                                    var rankLabel = new Label
                                    {
                                        Text = @"Rank: " + itemsData.Rank,
                                        AutoSize = true
                                    };
                                    itemPanel.Controls.Add(rankLabel);
                                    var costLabel = new Label
                                    {
                                        Text = @"Cost: " + itemsData.Cost,
                                        AutoSize = true
                                    };
                                    itemPanel.Controls.Add(costLabel);

                                    var titleLabel = new Label
                                    {
                                        Text = itemsData.Title,
                                        AutoSize = true
                                    };

                                    var toolTip = new ToolTip();

                                    itemPanel.Controls.Add(titleLabel);

                                    if (!String.IsNullOrEmpty(itemsData.FirstLevelIteration))
                                    {
                                        itemPanel.BackColor = Color.YellowGreen;
                                    }
                                    if (itemsData.Rank == "0")
                                    {
                                        itemPanel.BackColor = Color.Yellow;
                                        toolTip.SetToolTip(itemPanel,
                                            "Rank is 0 and can create inaccuracy in projection.");
                                        toolTip.SetToolTip(rankLabel,
                                            "Rank is 0 and can create inaccuracy in projection.");
                                        toolTip.SetToolTip(costLabel,
                                            "Rank is 0 and can create inaccuracy in projection.");
                                        toolTip.SetToolTip(titleLabel,
                                            "Rank is 0 and can create inaccuracy in projection.");
                                    }
                                    if (itemsData.Cost == "0")
                                    {
                                        itemPanel.BackColor = Color.Red;
                                        toolTip.SetToolTip(itemPanel,
                                            "Cost is 0 and creates an inaccuracy in projection.");
                                        toolTip.SetToolTip(rankLabel,
                                            "Cost is 0 and creates an inaccuracy in projection.");
                                        toolTip.SetToolTip(costLabel,
                                            "Cost is 0 and creates an inaccuracy in projection.");
                                        toolTip.SetToolTip(titleLabel,
                                            "Cost is 0 and creates an inaccuracy in projection.");
                                    }
                                    if (itemsData.State == "Closed")
                                    {
                                        itemPanel.BackColor = Color.DimGray;
                                        itemPanel.ForeColor = Color.WhiteSmoke;
                                    }

                                    panel.Controls.Add(itemPanel);
                                }
                            });
                            panel.Invoke(d);
                        }
                    }

                    areaRow++;

                }

                AddControlToTable(container, teamLabel, currentRow + 1, 0, team.Areas.Count);

                currentRow += team.Areas.Count;

                count++;
                progressUpdateAction(10 + Math.Min(100, (int)Math.Ceiling(100.0 * count / teamCount)));
            }
            container.Invoke(new Action(container.ResumeLayout));

            //var b = new Bitmap(container.Width, container.Height);
            //container.DrawToBitmap(b, new Rectangle(0, 0, container.Width, container.Height));
            //var p = new PrintDocument();

            //p.PrintPage += (sender, args) =>
            //{
            //    args.Graphics.DrawImage(b, 0, 0);
            //};
            //p.Print();
        }

        void idLabel_Click(object sender, EventArgs e)
        {
            string url = "about:blank";
            var control = sender as Control;
            if (control != null)
            {
                url = control.Tag.ToString();
            }
            Process.Start(url);
        }

        private void AddControlToTable(TableLayoutPanel container, Control control, int row, int column, int rowSpan = 1)
        {
            var d = new Action(() =>
            {
                container.Controls.Add(control);
                container.SetRow(control, row);
                container.SetColumn(control, column);
            });
            container.Invoke(d);
        }
    }

    public interface ILayoutBuilder<TContainer>
    {
        void BuildLayout(TContainer container, SortedData sortedData, Action<int> progressUpdateAction);
    }

    public class AreaData
    {
        public string AreaName { get; set; }
        public IOrderedEnumerable<WorkItemsData> WorkItems { get; set; }
        public Dictionary<string, List<WorkItemsData>> Iterations { get; set; }
    }

    public class TeamData
    {
        public string TeamName { get; set; }
        public Dictionary<string, AreaData> Areas { get; set; }
        public IOrderedEnumerable<WorkItemsData> WorkItems { get; set; }
    }

    public class SortedData
    {
        public Dictionary<string, TeamData> Teams { get; set; }
        public IOrderedEnumerable<WorkItemsData> WorkItems { get; set; }
        public IEnumerable<string> IterationNames { get; set; }
    }

    public class TfsConfig
    {
        public string ProjectName { get; set; }
        public string[] ExpandPaths { get; set; }
        public string AreaPathBase { get; set; }
        public string IterationBasePath { get; set; }
        public string ProjectCollectionUrl { get; set; }
        public string TeamFieldName { get; set; }
        public string CostFieldName { get; set; }

        public TfsConfig()
        {
            ExpandPaths = new string[] {};
        }
    }
}
