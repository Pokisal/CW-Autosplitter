namespace CWAutosplitter.UI.Components
{
    partial class AutosplitterSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Case 1-1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Case 1-2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Case 2-1");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Case 2-2");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Case 2-3");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Case 3-1");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Case 3-2");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Harjit");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Splits", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            this.lblOptions = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblAdvanced = new System.Windows.Forms.Label();
            this.tvwSettings = new System.Windows.Forms.TreeView();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbxReset = new System.Windows.Forms.CheckBox();
            this.cbxSplit = new System.Windows.Forms.CheckBox();
            this.cbxStart = new System.Windows.Forms.CheckBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.btnResetToDefault = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOptions
            // 
            this.lblOptions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOptions.Location = new System.Drawing.Point(4, 17);
            this.lblOptions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(85, 28);
            this.lblOptions.TabIndex = 0;
            this.lblOptions.Text = "Options:";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.lblOptions, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lblAdvanced, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.tvwSettings, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.pnlOptions, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.pnlButtons, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(627, 677);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // lblAdvanced
            // 
            this.lblAdvanced.AutoSize = true;
            this.lblAdvanced.Location = new System.Drawing.Point(4, 68);
            this.lblAdvanced.Margin = new System.Windows.Forms.Padding(4, 6, 4, 0);
            this.lblAdvanced.Name = "lblAdvanced";
            this.lblAdvanced.Size = new System.Drawing.Size(72, 16);
            this.lblAdvanced.TabIndex = 1;
            this.lblAdvanced.Text = "Advanced:";
            // 
            // tvwSettings
            // 
            this.tvwSettings.CheckBoxes = true;
            this.tvwSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwSettings.Location = new System.Drawing.Point(97, 66);
            this.tvwSettings.Margin = new System.Windows.Forms.Padding(4);
            this.tvwSettings.Name = "tvwSettings";
            treeNode1.Name = "Case1-1";
            treeNode1.Text = "Case 1-1";
            treeNode2.Name = "Case1-2";
            treeNode2.Text = "Case 1-2";
            treeNode3.Name = "Case2-1";
            treeNode3.Text = "Case 2-1";
            treeNode4.Name = "Case2-2";
            treeNode4.Text = "Case 2-2";
            treeNode5.Name = "Case2-3";
            treeNode5.Text = "Case 2-3";
            treeNode6.Name = "Case3-1";
            treeNode6.Text = "Case 3-1";
            treeNode7.Name = "Case3-2";
            treeNode7.Text = "Case 3-2";
            treeNode8.Name = "Harjit";
            treeNode8.Text = "Harjit";
            treeNode9.Name = "Splits";
            treeNode9.Text = "Splits";
            this.tvwSettings.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.tvwSettings.Size = new System.Drawing.Size(526, 545);
            this.tvwSettings.TabIndex = 3;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.button1);
            this.pnlOptions.Controls.Add(this.label1);
            this.pnlOptions.Controls.Add(this.textBox1);
            this.pnlOptions.Controls.Add(this.cbxReset);
            this.pnlOptions.Controls.Add(this.cbxSplit);
            this.pnlOptions.Controls.Add(this.cbxStart);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOptions.Location = new System.Drawing.Point(97, 4);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(526, 54);
            this.pnlOptions.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 17);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input Xbox IP Address:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(281, 30);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // cbxReset
            // 
            this.cbxReset.AutoSize = true;
            this.cbxReset.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxReset.Location = new System.Drawing.Point(111, 0);
            this.cbxReset.Margin = new System.Windows.Forms.Padding(4);
            this.cbxReset.Name = "cbxReset";
            this.cbxReset.Size = new System.Drawing.Size(65, 54);
            this.cbxReset.TabIndex = 2;
            this.cbxReset.Text = "Reset";
            this.cbxReset.UseVisualStyleBackColor = true;
            // 
            // cbxSplit
            // 
            this.cbxSplit.AutoSize = true;
            this.cbxSplit.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxSplit.Location = new System.Drawing.Point(56, 0);
            this.cbxSplit.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSplit.Name = "cbxSplit";
            this.cbxSplit.Size = new System.Drawing.Size(55, 54);
            this.cbxSplit.TabIndex = 1;
            this.cbxSplit.Text = "Split";
            this.cbxSplit.UseVisualStyleBackColor = true;
            // 
            // cbxStart
            // 
            this.cbxStart.AutoSize = true;
            this.cbxStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxStart.Location = new System.Drawing.Point(0, 0);
            this.cbxStart.Margin = new System.Windows.Forms.Padding(4);
            this.cbxStart.Name = "cbxStart";
            this.cbxStart.Size = new System.Drawing.Size(56, 54);
            this.cbxStart.TabIndex = 0;
            this.cbxStart.Text = "Start";
            this.cbxStart.UseVisualStyleBackColor = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCheckAll);
            this.pnlButtons.Controls.Add(this.btnUncheckAll);
            this.pnlButtons.Controls.Add(this.btnResetToDefault);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(97, 619);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(0, 12, 13, 12);
            this.pnlButtons.Size = new System.Drawing.Size(526, 54);
            this.pnlButtons.TabIndex = 5;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.AutoSize = true;
            this.btnCheckAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCheckAll.Location = new System.Drawing.Point(147, 12);
            this.btnCheckAll.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(100, 30);
            this.btnCheckAll.TabIndex = 2;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.AutoSize = true;
            this.btnUncheckAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUncheckAll.Location = new System.Drawing.Point(247, 12);
            this.btnUncheckAll.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(117, 30);
            this.btnUncheckAll.TabIndex = 1;
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.UseVisualStyleBackColor = true;
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // btnResetToDefault
            // 
            this.btnResetToDefault.AutoSize = true;
            this.btnResetToDefault.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnResetToDefault.Location = new System.Drawing.Point(364, 12);
            this.btnResetToDefault.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
            this.btnResetToDefault.Name = "btnResetToDefault";
            this.btnResetToDefault.Size = new System.Drawing.Size(149, 30);
            this.btnResetToDefault.TabIndex = 0;
            this.btnResetToDefault.Text = "Reset to Default";
            this.btnResetToDefault.UseVisualStyleBackColor = true;
            this.btnResetToDefault.Click += new System.EventHandler(this.btnResetToDefault_Click);
            // 
            // AutosplitterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AutosplitterSettings";
            this.Size = new System.Drawing.Size(627, 677);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblAdvanced;
        private System.Windows.Forms.TreeView tvwSettings;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.CheckBox cbxReset;
        private System.Windows.Forms.CheckBox cbxSplit;
        private System.Windows.Forms.CheckBox cbxStart;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Button btnUncheckAll;
        private System.Windows.Forms.Button btnResetToDefault;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}
