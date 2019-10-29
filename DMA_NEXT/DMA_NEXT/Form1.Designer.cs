namespace DMA_NEXT
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Analyze_Button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.FileData = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LogTab = new System.Windows.Forms.TabPage();
            this.SysInfoTab = new System.Windows.Forms.TabPage();
            this.sysdatagridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.ReportsButton = new System.Windows.Forms.Button();
            this.Loggin_Button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.FileData.SuspendLayout();
            this.SysInfoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sysdatagridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Analyze_Button
            // 
            this.Analyze_Button.FlatAppearance.BorderSize = 0;
            this.Analyze_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Analyze_Button.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Analyze_Button.ForeColor = System.Drawing.Color.Black;
            this.Analyze_Button.Image = ((System.Drawing.Image)(resources.GetObject("Analyze_Button.Image")));
            this.Analyze_Button.Location = new System.Drawing.Point(0, 52);
            this.Analyze_Button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Analyze_Button.Name = "Analyze_Button";
            this.Analyze_Button.Size = new System.Drawing.Size(239, 118);
            this.Analyze_Button.TabIndex = 1;
            this.Analyze_Button.Text = "Analyze";
            this.Analyze_Button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Analyze_Button.UseVisualStyleBackColor = true;
            this.Analyze_Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(25, 33);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(968, 598);
            this.dataGridView1.TabIndex = 2;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.FileData);
            this.MainTabControl.Controls.Add(this.LogTab);
            this.MainTabControl.Controls.Add(this.SysInfoTab);
            this.MainTabControl.Location = new System.Drawing.Point(246, 90);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1004, 691);
            this.MainTabControl.TabIndex = 3;
            // 
            // FileData
            // 
            this.FileData.Controls.Add(this.panel4);
            this.FileData.Controls.Add(this.dataGridView1);
            this.FileData.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileData.ForeColor = System.Drawing.Color.Black;
            this.FileData.Location = new System.Drawing.Point(4, 22);
            this.FileData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.FileData.Name = "FileData";
            this.FileData.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.FileData.Size = new System.Drawing.Size(996, 665);
            this.FileData.TabIndex = 1;
            this.FileData.Tag = "FileData";
            this.FileData.Text = "File Data";
            this.FileData.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(25, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1267, 10);
            this.panel4.TabIndex = 7;
            // 
            // LogTab
            // 
            this.LogTab.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogTab.ForeColor = System.Drawing.Color.Black;
            this.LogTab.Location = new System.Drawing.Point(4, 22);
            this.LogTab.Name = "LogTab";
            this.LogTab.Size = new System.Drawing.Size(996, 665);
            this.LogTab.TabIndex = 2;
            this.LogTab.Text = "Logging";
            this.LogTab.UseVisualStyleBackColor = true;
            // 
            // SysInfoTab
            // 
            this.SysInfoTab.Controls.Add(this.sysdatagridView);
            this.SysInfoTab.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SysInfoTab.ForeColor = System.Drawing.Color.Black;
            this.SysInfoTab.Location = new System.Drawing.Point(4, 22);
            this.SysInfoTab.Name = "SysInfoTab";
            this.SysInfoTab.Size = new System.Drawing.Size(996, 665);
            this.SysInfoTab.TabIndex = 3;
            this.SysInfoTab.Text = "Local System Information";
            this.SysInfoTab.UseVisualStyleBackColor = true;
            // 
            // sysdatagridView
            // 
            this.sysdatagridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sysdatagridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sysdatagridView.GridColor = System.Drawing.Color.Black;
            this.sysdatagridView.Location = new System.Drawing.Point(14, 33);
            this.sysdatagridView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.sysdatagridView.Name = "sysdatagridView";
            this.sysdatagridView.RowTemplate.Height = 24;
            this.sysdatagridView.Size = new System.Drawing.Size(968, 598);
            this.sysdatagridView.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.ReportsButton);
            this.panel1.Controls.Add(this.Loggin_Button);
            this.panel1.Controls.Add(this.Analyze_Button);
            this.panel1.Location = new System.Drawing.Point(0, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 658);
            this.panel1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(7, 451);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(239, 118);
            this.button2.TabIndex = 4;
            this.button2.Text = "File System";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ReportsButton
            // 
            this.ReportsButton.BackColor = System.Drawing.Color.Transparent;
            this.ReportsButton.FlatAppearance.BorderSize = 0;
            this.ReportsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportsButton.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportsButton.ForeColor = System.Drawing.Color.Black;
            this.ReportsButton.Image = ((System.Drawing.Image)(resources.GetObject("ReportsButton.Image")));
            this.ReportsButton.Location = new System.Drawing.Point(1, 313);
            this.ReportsButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ReportsButton.Name = "ReportsButton";
            this.ReportsButton.Size = new System.Drawing.Size(239, 118);
            this.ReportsButton.TabIndex = 3;
            this.ReportsButton.Text = "Import";
            this.ReportsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ReportsButton.UseVisualStyleBackColor = false;
            this.ReportsButton.Click += new System.EventHandler(this.ReportsButton_Click);
            // 
            // Loggin_Button
            // 
            this.Loggin_Button.FlatAppearance.BorderSize = 0;
            this.Loggin_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Loggin_Button.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loggin_Button.ForeColor = System.Drawing.Color.Black;
            this.Loggin_Button.Image = ((System.Drawing.Image)(resources.GetObject("Loggin_Button.Image")));
            this.Loggin_Button.Location = new System.Drawing.Point(0, 185);
            this.Loggin_Button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Loggin_Button.Name = "Loggin_Button";
            this.Loggin_Button.Size = new System.Drawing.Size(239, 114);
            this.Loggin_Button.TabIndex = 2;
            this.Loggin_Button.Text = "Logging";
            this.Loggin_Button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Loggin_Button.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Location = new System.Drawing.Point(1, 826);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1267, 10);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1267, 10);
            this.panel3.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(1, 813);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1267, 10);
            this.panel6.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fixToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
           // this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // fixToolStripMenuItem
            // 
            this.fixToolStripMenuItem.Name = "fixToolStripMenuItem";
            this.fixToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fixToolStripMenuItem.Text = "Fix";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1267, 835);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainTabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "DM Analyzer Next";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.FileData.ResumeLayout(false);
            this.SysInfoTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sysdatagridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Analyze_Button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage FileData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Loggin_Button;
        private System.Windows.Forms.Button ReportsButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage LogTab;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TabPage SysInfoTab;
        private System.Windows.Forms.DataGridView sysdatagridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fixToolStripMenuItem;
    }
}

