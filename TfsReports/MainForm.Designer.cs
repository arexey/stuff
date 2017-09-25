using CardMaker.Model;

namespace CardMaker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.connectButton = new System.Windows.Forms.ToolStripButton();
            this.refreshQueryTreeButton = new System.Windows.Forms.ToolStripButton();
            this.queryHierarchyTreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.reportTypeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.reportProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.loadDataButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.teamsToShowCheckBoxList = new System.Windows.Forms.CheckedListBox();
            this.capacityTable = new System.Windows.Forms.TableLayoutPanel();
            this.projectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startIterationComboBox = new System.Windows.Forms.ComboBox();
            this.projectionProgressPanel = new System.Windows.Forms.Panel();
            this.projectionProgressBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.projectionTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.WorkItemsDataSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.progressPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.projectionProgressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkItemsDataSourceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "WorkItemsDataSet";
            reportDataSource1.Value = this.WorkItemsDataSourceBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "CardMaker.SmallCards.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 28);
            this.reportViewer.Margin = new System.Windows.Forms.Padding(0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer.ShowDocumentMapButton = false;
            this.reportViewer.ShowPromptAreaButton = false;
            this.reportViewer.Size = new System.Drawing.Size(507, 711);
            this.reportViewer.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip);
            this.splitContainer1.Panel1.Controls.Add(this.queryHierarchyTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer);
            this.splitContainer1.Panel2.Controls.Add(this.progressPanel);
            this.splitContainer1.Size = new System.Drawing.Size(868, 741);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 1;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectButton,
            this.refreshQueryTreeButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(360, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // connectButton
            // 
            this.connectButton.Image = ((System.Drawing.Image)(resources.GetObject("connectButton.Image")));
            this.connectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(72, 22);
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // refreshQueryTreeButton
            // 
            this.refreshQueryTreeButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshQueryTreeButton.Image")));
            this.refreshQueryTreeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshQueryTreeButton.Name = "refreshQueryTreeButton";
            this.refreshQueryTreeButton.Size = new System.Drawing.Size(66, 22);
            this.refreshQueryTreeButton.Text = "Refresh";
            this.refreshQueryTreeButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // queryHierarchyTreeView
            // 
            this.queryHierarchyTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryHierarchyTreeView.ImageIndex = 0;
            this.queryHierarchyTreeView.ImageList = this.imageList1;
            this.queryHierarchyTreeView.Location = new System.Drawing.Point(0, 28);
            this.queryHierarchyTreeView.Name = "queryHierarchyTreeView";
            this.queryHierarchyTreeView.SelectedImageIndex = 0;
            this.queryHierarchyTreeView.Size = new System.Drawing.Size(360, 713);
            this.queryHierarchyTreeView.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_Closed_32xLG.png");
            this.imageList1.Images.SetKeyName(1, "Table_32.png");
            this.imageList1.Images.SetKeyName(2, "Network_ConnectTo.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportTypeComboBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(504, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // reportTypeComboBox
            // 
            this.reportTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reportTypeComboBox.DropDownWidth = 150;
            this.reportTypeComboBox.Items.AddRange(new object[] {
            "Large Cards (Half Page)",
            "Small Cards (Quarter Page)",
            "Compact Small Cards (Fixed Size)",
            "Ultra Compact (No Description)"});
            this.reportTypeComboBox.Name = "reportTypeComboBox";
            this.reportTypeComboBox.Size = new System.Drawing.Size(200, 25);
            this.reportTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.reportTypeComboBox_SelectedIndexChanged);
            // 
            // progressPanel
            // 
            this.progressPanel.BackColor = System.Drawing.SystemColors.Control;
            this.progressPanel.Controls.Add(this.reportProgressBar);
            this.progressPanel.Controls.Add(this.label1);
            this.progressPanel.Location = new System.Drawing.Point(56, 77);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(298, 100);
            this.progressPanel.TabIndex = 1;
            this.progressPanel.Visible = false;
            // 
            // reportProgressBar
            // 
            this.reportProgressBar.Location = new System.Drawing.Point(27, 50);
            this.reportProgressBar.Name = "reportProgressBar";
            this.reportProgressBar.Size = new System.Drawing.Size(248, 23);
            this.reportProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.reportProgressBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Preparing Report...";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(66, 32);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(882, 787);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(874, 747);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Task Cards";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.flowLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 36);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(874, 747);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Firends of Green";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.projectionProgressPanel);
            this.flowLayoutPanel1.Controls.Add(this.projectionTableLayoutPanel);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(662, 523);
            this.flowLayoutPanel1.TabIndex = 10;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Controls.Add(this.printButton);
            this.panel1.Controls.Add(this.loadDataButton);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.teamsToShowCheckBoxList);
            this.panel1.Controls.Add(this.capacityTable);
            this.panel1.Controls.Add(this.projectButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.startIterationComboBox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 231);
            this.panel1.TabIndex = 9;
            // 
            // refreshButton
            // 
            this.refreshButton.Enabled = false;
            this.refreshButton.Location = new System.Drawing.Point(191, 205);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 10;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // printButton
            // 
            this.printButton.Enabled = false;
            this.printButton.Location = new System.Drawing.Point(109, 205);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 9;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // loadDataButton
            // 
            this.loadDataButton.AutoSize = true;
            this.loadDataButton.Location = new System.Drawing.Point(5, 3);
            this.loadDataButton.Name = "loadDataButton";
            this.loadDataButton.Size = new System.Drawing.Size(75, 23);
            this.loadDataButton.TabIndex = 1;
            this.loadDataButton.Text = "Load Data";
            this.loadDataButton.UseVisualStyleBackColor = true;
            this.loadDataButton.Click += new System.EventHandler(this.loadDataButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Capacity";
            // 
            // teamsToShowCheckBoxList
            // 
            this.teamsToShowCheckBoxList.CheckOnClick = true;
            this.teamsToShowCheckBoxList.FormattingEnabled = true;
            this.teamsToShowCheckBoxList.Location = new System.Drawing.Point(5, 45);
            this.teamsToShowCheckBoxList.Name = "teamsToShowCheckBoxList";
            this.teamsToShowCheckBoxList.Size = new System.Drawing.Size(176, 154);
            this.teamsToShowCheckBoxList.TabIndex = 2;
            this.teamsToShowCheckBoxList.ThreeDCheckBoxes = true;
            // 
            // capacityTable
            // 
            this.capacityTable.AutoSize = true;
            this.capacityTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.capacityTable.ColumnCount = 1;
            this.capacityTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.capacityTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.capacityTable.Location = new System.Drawing.Point(188, 89);
            this.capacityTable.Name = "capacityTable";
            this.capacityTable.RowCount = 1;
            this.capacityTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.capacityTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.capacityTable.Size = new System.Drawing.Size(48, 18);
            this.capacityTable.TabIndex = 7;
            // 
            // projectButton
            // 
            this.projectButton.AutoSize = true;
            this.projectButton.Enabled = false;
            this.projectButton.Location = new System.Drawing.Point(4, 205);
            this.projectButton.Name = "projectButton";
            this.projectButton.Size = new System.Drawing.Size(98, 23);
            this.projectButton.TabIndex = 3;
            this.projectButton.Text = "Create Projection";
            this.projectButton.UseVisualStyleBackColor = true;
            this.projectButton.Click += new System.EventHandler(this.projectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start Iteration:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Include teams:";
            // 
            // startIterationComboBox
            // 
            this.startIterationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startIterationComboBox.FormattingEnabled = true;
            this.startIterationComboBox.Location = new System.Drawing.Point(188, 45);
            this.startIterationComboBox.Name = "startIterationComboBox";
            this.startIterationComboBox.Size = new System.Drawing.Size(190, 21);
            this.startIterationComboBox.TabIndex = 5;
            // 
            // projectionProgressPanel
            // 
            this.projectionProgressPanel.BackColor = System.Drawing.SystemColors.Control;
            this.projectionProgressPanel.Controls.Add(this.projectionProgressBar);
            this.projectionProgressPanel.Controls.Add(this.label5);
            this.projectionProgressPanel.Location = new System.Drawing.Point(3, 240);
            this.projectionProgressPanel.Name = "projectionProgressPanel";
            this.projectionProgressPanel.Size = new System.Drawing.Size(298, 100);
            this.projectionProgressPanel.TabIndex = 10;
            this.projectionProgressPanel.Visible = false;
            // 
            // projectionProgressBar
            // 
            this.projectionProgressBar.Location = new System.Drawing.Point(27, 50);
            this.projectionProgressBar.Name = "projectionProgressBar";
            this.projectionProgressBar.Size = new System.Drawing.Size(248, 23);
            this.projectionProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.projectionProgressBar.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Preparing Projection...";
            // 
            // projectionTableLayoutPanel
            // 
            this.projectionTableLayoutPanel.AutoSize = true;
            this.projectionTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.projectionTableLayoutPanel.ColumnCount = 1;
            this.projectionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.projectionTableLayoutPanel.Location = new System.Drawing.Point(3, 346);
            this.projectionTableLayoutPanel.Name = "projectionTableLayoutPanel";
            this.projectionTableLayoutPanel.RowCount = 1;
            this.projectionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.projectionTableLayoutPanel.Size = new System.Drawing.Size(2, 2);
            this.projectionTableLayoutPanel.TabIndex = 0;
            // 
            // WorkItemsDataSourceBindingSource
            // 
            this.WorkItemsDataSourceBindingSource.DataMember = "WorkItems";
            this.WorkItemsDataSourceBindingSource.DataSource = typeof(CardMaker.Model.WorkItemsDataSource);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 787);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Card Maker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.progressPanel.ResumeLayout(false);
            this.progressPanel.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.projectionProgressPanel.ResumeLayout(false);
            this.projectionProgressPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkItemsDataSourceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource WorkItemsDataSourceBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView queryHierarchyTreeView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton refreshQueryTreeButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.ProgressBar reportProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton connectButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button loadDataButton;
        private System.Windows.Forms.TableLayoutPanel projectionTableLayoutPanel;
        private System.Windows.Forms.CheckedListBox teamsToShowCheckBoxList;
        private System.Windows.Forms.Button projectButton;
        private System.Windows.Forms.ComboBox startIterationComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel capacityTable;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Panel projectionProgressPanel;
        private System.Windows.Forms.ProgressBar projectionProgressBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox reportTypeComboBox;
        private System.Windows.Forms.Button refreshButton;
    }
}

