namespace CardMaker
{
    partial class TfsConnectForm
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
            System.Windows.Forms.Label areaPathBaseLabel;
            System.Windows.Forms.Label iterationBasePathLabel;
            System.Windows.Forms.Label projectCollectionUrlLabel;
            System.Windows.Forms.Label projectNameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TfsConnectForm));
            this.projectCollectionUrlTextBox = new System.Windows.Forms.TextBox();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.projectPickerButton = new System.Windows.Forms.Button();
            this.areaBasePathComboBox = new System.Windows.Forms.ComboBox();
            this.iterationBasePathComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.queryBasePathComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.teamFieldComboBox = new System.Windows.Forms.ComboBox();
            this.costFieldComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            areaPathBaseLabel = new System.Windows.Forms.Label();
            iterationBasePathLabel = new System.Windows.Forms.Label();
            projectCollectionUrlLabel = new System.Windows.Forms.Label();
            projectNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // areaPathBaseLabel
            // 
            areaPathBaseLabel.AutoSize = true;
            areaPathBaseLabel.Location = new System.Drawing.Point(12, 158);
            areaPathBaseLabel.Name = "areaPathBaseLabel";
            areaPathBaseLabel.Size = new System.Drawing.Size(84, 13);
            areaPathBaseLabel.TabIndex = 1;
            areaPathBaseLabel.Text = "Area Path Base:";
            // 
            // iterationBasePathLabel
            // 
            iterationBasePathLabel.AutoSize = true;
            iterationBasePathLabel.Location = new System.Drawing.Point(12, 184);
            iterationBasePathLabel.Name = "iterationBasePathLabel";
            iterationBasePathLabel.Size = new System.Drawing.Size(100, 13);
            iterationBasePathLabel.TabIndex = 3;
            iterationBasePathLabel.Text = "Iteration Base Path:";
            // 
            // projectCollectionUrlLabel
            // 
            projectCollectionUrlLabel.AutoSize = true;
            projectCollectionUrlLabel.Location = new System.Drawing.Point(12, 106);
            projectCollectionUrlLabel.Name = "projectCollectionUrlLabel";
            projectCollectionUrlLabel.Size = new System.Drawing.Size(108, 13);
            projectCollectionUrlLabel.TabIndex = 5;
            projectCollectionUrlLabel.Text = "Project Collection Url:";
            // 
            // projectNameLabel
            // 
            projectNameLabel.AutoSize = true;
            projectNameLabel.Location = new System.Drawing.Point(12, 132);
            projectNameLabel.Name = "projectNameLabel";
            projectNameLabel.Size = new System.Drawing.Size(74, 13);
            projectNameLabel.TabIndex = 7;
            projectNameLabel.Text = "Project Name:";
            // 
            // projectCollectionUrlTextBox
            // 
            this.projectCollectionUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectCollectionUrlTextBox.Location = new System.Drawing.Point(126, 103);
            this.projectCollectionUrlTextBox.Name = "projectCollectionUrlTextBox";
            this.projectCollectionUrlTextBox.ReadOnly = true;
            this.projectCollectionUrlTextBox.Size = new System.Drawing.Size(358, 20);
            this.projectCollectionUrlTextBox.TabIndex = 6;
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectNameTextBox.Location = new System.Drawing.Point(126, 129);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.ReadOnly = true;
            this.projectNameTextBox.Size = new System.Drawing.Size(358, 20);
            this.projectNameTextBox.TabIndex = 8;
            // 
            // projectPickerButton
            // 
            this.projectPickerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.projectPickerButton.Location = new System.Drawing.Point(491, 101);
            this.projectPickerButton.Name = "projectPickerButton";
            this.projectPickerButton.Size = new System.Drawing.Size(26, 23);
            this.projectPickerButton.TabIndex = 10;
            this.projectPickerButton.Text = "...";
            this.projectPickerButton.UseVisualStyleBackColor = true;
            this.projectPickerButton.Click += new System.EventHandler(this.projectPickerButton_Click);
            // 
            // areaBasePathComboBox
            // 
            this.areaBasePathComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.areaBasePathComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areaBasePathComboBox.FormattingEnabled = true;
            this.areaBasePathComboBox.Location = new System.Drawing.Point(126, 154);
            this.areaBasePathComboBox.Name = "areaBasePathComboBox";
            this.areaBasePathComboBox.Size = new System.Drawing.Size(358, 21);
            this.areaBasePathComboBox.TabIndex = 13;
            this.areaBasePathComboBox.SelectedIndexChanged += new System.EventHandler(this.areaBasePathComboBox_SelectedIndexChanged);
            // 
            // iterationBasePathComboBox
            // 
            this.iterationBasePathComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iterationBasePathComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iterationBasePathComboBox.FormattingEnabled = true;
            this.iterationBasePathComboBox.Location = new System.Drawing.Point(126, 181);
            this.iterationBasePathComboBox.Name = "iterationBasePathComboBox";
            this.iterationBasePathComboBox.Size = new System.Drawing.Size(358, 21);
            this.iterationBasePathComboBox.TabIndex = 14;
            this.iterationBasePathComboBox.SelectedIndexChanged += new System.EventHandler(this.iterationBasePathComboBox_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(235, 319);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(145, 30);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Base Query Path:";
            // 
            // queryBasePathComboBox
            // 
            this.queryBasePathComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryBasePathComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.queryBasePathComboBox.FormattingEnabled = true;
            this.queryBasePathComboBox.Location = new System.Drawing.Point(126, 209);
            this.queryBasePathComboBox.Name = "queryBasePathComboBox";
            this.queryBasePathComboBox.Size = new System.Drawing.Size(358, 21);
            this.queryBasePathComboBox.TabIndex = 17;
            this.queryBasePathComboBox.SelectedIndexChanged += new System.EventHandler(this.queryBasePathComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(339, 65);
            this.label2.TabIndex = 18;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Team Field:";
            // 
            // teamFieldComboBox
            // 
            this.teamFieldComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teamFieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamFieldComboBox.FormattingEnabled = true;
            this.teamFieldComboBox.Location = new System.Drawing.Point(126, 237);
            this.teamFieldComboBox.Name = "teamFieldComboBox";
            this.teamFieldComboBox.Size = new System.Drawing.Size(358, 21);
            this.teamFieldComboBox.TabIndex = 20;
            this.teamFieldComboBox.SelectedIndexChanged += new System.EventHandler(this.teamFieldComboBox_SelectedIndexChanged);
            // 
            // costFieldComboBox
            // 
            this.costFieldComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.costFieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.costFieldComboBox.FormattingEnabled = true;
            this.costFieldComboBox.Location = new System.Drawing.Point(126, 265);
            this.costFieldComboBox.Name = "costFieldComboBox";
            this.costFieldComboBox.Size = new System.Drawing.Size(358, 21);
            this.costFieldComboBox.TabIndex = 21;
            this.costFieldComboBox.SelectedIndexChanged += new System.EventHandler(this.costFieldComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Cost Field:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(386, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 30);
            this.button1.TabIndex = 23;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TfsConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 361);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.costFieldComboBox);
            this.Controls.Add(this.teamFieldComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.queryBasePathComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.iterationBasePathComboBox);
            this.Controls.Add(this.areaBasePathComboBox);
            this.Controls.Add(this.projectPickerButton);
            this.Controls.Add(areaPathBaseLabel);
            this.Controls.Add(iterationBasePathLabel);
            this.Controls.Add(projectCollectionUrlLabel);
            this.Controls.Add(this.projectCollectionUrlTextBox);
            this.Controls.Add(projectNameLabel);
            this.Controls.Add(this.projectNameTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1560, 400);
            this.Name = "TfsConnectForm";
            this.Text = "TFS Connection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox projectCollectionUrlTextBox;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.Button projectPickerButton;
        private System.Windows.Forms.ComboBox areaBasePathComboBox;
        private System.Windows.Forms.ComboBox iterationBasePathComboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox queryBasePathComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox teamFieldComboBox;
        private System.Windows.Forms.ComboBox costFieldComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}