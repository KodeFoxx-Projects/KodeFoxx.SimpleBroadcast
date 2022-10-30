namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp
{
    partial class Main
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.tabs = new System.Windows.Forms.TabControl();
            this.showsOverviewTabPage = new System.Windows.Forms.TabPage();
            this.artistsOverviewTabPage = new System.Windows.Forms.TabPage();
            this.artistsOverview = new System.Windows.Forms.ListView();
            this.songsOverviewTabPage = new System.Windows.Forms.TabPage();
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.containerPanel.SuspendLayout();
            this.bodyPanel.SuspendLayout();
            this.tabs.SuspendLayout();
            this.artistsOverviewTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Black;
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1082, 60);
            this.headerPanel.TabIndex = 0;
            // 
            // containerPanel
            // 
            this.containerPanel.Controls.Add(this.bodyPanel);
            this.containerPanel.Controls.Add(this.footerPanel);
            this.containerPanel.Controls.Add(this.headerPanel);
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 0);
            this.containerPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(1082, 753);
            this.containerPanel.TabIndex = 1;
            // 
            // bodyPanel
            // 
            this.bodyPanel.BackColor = System.Drawing.Color.White;
            this.bodyPanel.Controls.Add(this.tabs);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(0, 60);
            this.bodyPanel.Margin = new System.Windows.Forms.Padding(9);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Padding = new System.Windows.Forms.Padding(16);
            this.bodyPanel.Size = new System.Drawing.Size(1082, 665);
            this.bodyPanel.TabIndex = 2;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.showsOverviewTabPage);
            this.tabs.Controls.Add(this.artistsOverviewTabPage);
            this.tabs.Controls.Add(this.songsOverviewTabPage);
            this.tabs.Controls.Add(this.aboutTabPage);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(16, 16);
            this.tabs.Margin = new System.Windows.Forms.Padding(16);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1050, 633);
            this.tabs.TabIndex = 0;
            // 
            // showsOverviewTabPage
            // 
            this.showsOverviewTabPage.Location = new System.Drawing.Point(4, 29);
            this.showsOverviewTabPage.Name = "showsOverviewTabPage";
            this.showsOverviewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.showsOverviewTabPage.Size = new System.Drawing.Size(1042, 600);
            this.showsOverviewTabPage.TabIndex = 0;
            this.showsOverviewTabPage.Text = " Shows ";
            this.showsOverviewTabPage.UseVisualStyleBackColor = true;
            // 
            // artistsOverviewTabPage
            // 
            this.artistsOverviewTabPage.Controls.Add(this.artistsOverview);
            this.artistsOverviewTabPage.Location = new System.Drawing.Point(4, 29);
            this.artistsOverviewTabPage.Name = "artistsOverviewTabPage";
            this.artistsOverviewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.artistsOverviewTabPage.Size = new System.Drawing.Size(1042, 600);
            this.artistsOverviewTabPage.TabIndex = 1;
            this.artistsOverviewTabPage.Text = " Artists ";
            this.artistsOverviewTabPage.UseVisualStyleBackColor = true;
            // 
            // artistsOverview
            // 
            this.artistsOverview.Location = new System.Drawing.Point(6, 6);
            this.artistsOverview.Name = "artistsOverview";
            this.artistsOverview.Size = new System.Drawing.Size(370, 588);
            this.artistsOverview.TabIndex = 0;
            this.artistsOverview.UseCompatibleStateImageBehavior = false;
            this.artistsOverview.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.artistsOverview_AfterLabelEdit);
            this.artistsOverview.DoubleClick += new System.EventHandler(this.artistsOverview_DoubleClick);
            this.artistsOverview.KeyUp += new System.Windows.Forms.KeyEventHandler(this.artistsOverview_KeyUp);
            // 
            // songsOverviewTabPage
            // 
            this.songsOverviewTabPage.Location = new System.Drawing.Point(4, 29);
            this.songsOverviewTabPage.Name = "songsOverviewTabPage";
            this.songsOverviewTabPage.Size = new System.Drawing.Size(1042, 600);
            this.songsOverviewTabPage.TabIndex = 2;
            this.songsOverviewTabPage.Text = " Songs ";
            this.songsOverviewTabPage.UseVisualStyleBackColor = true;
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.Location = new System.Drawing.Point(4, 29);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Size = new System.Drawing.Size(1042, 600);
            this.aboutTabPage.TabIndex = 3;
            this.aboutTabPage.Text = " About ";
            this.aboutTabPage.UseVisualStyleBackColor = true;
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.Sienna;
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 725);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1082, 28);
            this.footerPanel.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 753);
            this.Controls.Add(this.containerPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1100, 800);
            this.Name = "Main";
            this.Text = "Main";
            this.containerPanel.ResumeLayout(false);
            this.bodyPanel.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.artistsOverviewTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel headerPanel;
        private Panel containerPanel;
        private Panel footerPanel;
        private Panel bodyPanel;
        private TabControl tabs;
        private TabPage showsOverviewTabPage;
        private TabPage artistsOverviewTabPage;
        private TabPage songsOverviewTabPage;
        private TabPage aboutTabPage;
        private ListView artistsOverview;
    }
}