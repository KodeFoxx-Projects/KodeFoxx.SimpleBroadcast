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
            this.addNewArtist = new System.Windows.Forms.Button();
            this.importArtistsFromFreeFormText = new System.Windows.Forms.Button();
            this.knownArtistsGroup = new System.Windows.Forms.GroupBox();
            this.knownArtistsSep1 = new System.Windows.Forms.Label();
            this.artistsOverviewQuickSearchInput = new System.Windows.Forms.TextBox();
            this.artistsOverviewQuickSearchLabel = new System.Windows.Forms.Label();
            this.artistsOverview = new System.Windows.Forms.ListView();
            this.songsOverviewTabPage = new System.Windows.Forms.TabPage();
            this.knownSongsGroup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.songsOverviewQuickSearchInput = new System.Windows.Forms.TextBox();
            this.songsOverviewQuickSearchLabel = new System.Windows.Forms.Label();
            this.songsOverview = new System.Windows.Forms.ListView();
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.containerPanel.SuspendLayout();
            this.bodyPanel.SuspendLayout();
            this.tabs.SuspendLayout();
            this.artistsOverviewTabPage.SuspendLayout();
            this.knownArtistsGroup.SuspendLayout();
            this.songsOverviewTabPage.SuspendLayout();
            this.knownSongsGroup.SuspendLayout();
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
            this.tabs.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.artistsOverviewTabPage.BackColor = System.Drawing.Color.White;
            this.artistsOverviewTabPage.Controls.Add(this.addNewArtist);
            this.artistsOverviewTabPage.Controls.Add(this.importArtistsFromFreeFormText);
            this.artistsOverviewTabPage.Controls.Add(this.knownArtistsGroup);
            this.artistsOverviewTabPage.Location = new System.Drawing.Point(4, 29);
            this.artistsOverviewTabPage.Name = "artistsOverviewTabPage";
            this.artistsOverviewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.artistsOverviewTabPage.Size = new System.Drawing.Size(1042, 600);
            this.artistsOverviewTabPage.TabIndex = 1;
            this.artistsOverviewTabPage.Text = " Artists ";
            // 
            // addNewArtist
            // 
            this.addNewArtist.Location = new System.Drawing.Point(556, 20);
            this.addNewArtist.Name = "addNewArtist";
            this.addNewArtist.Size = new System.Drawing.Size(480, 42);
            this.addNewArtist.TabIndex = 3;
            this.addNewArtist.Text = "Add new artist (or right click in overview)";
            this.addNewArtist.UseVisualStyleBackColor = true;
            this.addNewArtist.Click += new System.EventHandler(this.addNewArtist_Click);
            // 
            // importArtistsFromFreeFormText
            // 
            this.importArtistsFromFreeFormText.Location = new System.Drawing.Point(556, 68);
            this.importArtistsFromFreeFormText.Name = "importArtistsFromFreeFormText";
            this.importArtistsFromFreeFormText.Size = new System.Drawing.Size(480, 42);
            this.importArtistsFromFreeFormText.TabIndex = 2;
            this.importArtistsFromFreeFormText.Text = "Import from free-form text";
            this.importArtistsFromFreeFormText.UseVisualStyleBackColor = true;
            this.importArtistsFromFreeFormText.Click += new System.EventHandler(this.importArtistsFromFreeFormText_Click);
            // 
            // knownArtistsGroup
            // 
            this.knownArtistsGroup.BackColor = System.Drawing.Color.Transparent;
            this.knownArtistsGroup.Controls.Add(this.knownArtistsSep1);
            this.knownArtistsGroup.Controls.Add(this.artistsOverviewQuickSearchInput);
            this.knownArtistsGroup.Controls.Add(this.artistsOverviewQuickSearchLabel);
            this.knownArtistsGroup.Controls.Add(this.artistsOverview);
            this.knownArtistsGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.knownArtistsGroup.Location = new System.Drawing.Point(10, 10);
            this.knownArtistsGroup.Name = "knownArtistsGroup";
            this.knownArtistsGroup.Padding = new System.Windows.Forms.Padding(16);
            this.knownArtistsGroup.Size = new System.Drawing.Size(540, 584);
            this.knownArtistsGroup.TabIndex = 1;
            this.knownArtistsGroup.TabStop = false;
            this.knownArtistsGroup.Text = " [Known Artists] ";
            // 
            // knownArtistsSep1
            // 
            this.knownArtistsSep1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.knownArtistsSep1.Location = new System.Drawing.Point(10, 61);
            this.knownArtistsSep1.Name = "knownArtistsSep1";
            this.knownArtistsSep1.Size = new System.Drawing.Size(520, 1);
            this.knownArtistsSep1.TabIndex = 3;
            // 
            // artistsOverviewQuickSearchInput
            // 
            this.artistsOverviewQuickSearchInput.Location = new System.Drawing.Point(120, 24);
            this.artistsOverviewQuickSearchInput.Name = "artistsOverviewQuickSearchInput";
            this.artistsOverviewQuickSearchInput.Size = new System.Drawing.Size(404, 27);
            this.artistsOverviewQuickSearchInput.TabIndex = 2;
            this.artistsOverviewQuickSearchInput.TextChanged += new System.EventHandler(this.artistsOverviewQuickSearchInput_TextChanged);
            // 
            // artistsOverviewQuickSearchLabel
            // 
            this.artistsOverviewQuickSearchLabel.AutoSize = true;
            this.artistsOverviewQuickSearchLabel.Location = new System.Drawing.Point(15, 28);
            this.artistsOverviewQuickSearchLabel.Name = "artistsOverviewQuickSearchLabel";
            this.artistsOverviewQuickSearchLabel.Size = new System.Drawing.Size(98, 20);
            this.artistsOverviewQuickSearchLabel.TabIndex = 1;
            this.artistsOverviewQuickSearchLabel.Text = "Quick Search";
            // 
            // artistsOverview
            // 
            this.artistsOverview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.artistsOverview.Location = new System.Drawing.Point(16, 73);
            this.artistsOverview.Name = "artistsOverview";
            this.artistsOverview.Size = new System.Drawing.Size(508, 495);
            this.artistsOverview.TabIndex = 0;
            this.artistsOverview.UseCompatibleStateImageBehavior = false;
            this.artistsOverview.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.artistsOverview_AfterLabelEdit);
            this.artistsOverview.DoubleClick += new System.EventHandler(this.artistsOverview_DoubleClick);
            this.artistsOverview.KeyUp += new System.Windows.Forms.KeyEventHandler(this.artistsOverview_KeyUp);
            this.artistsOverview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.artistsOverview_MouseUp);
            // 
            // songsOverviewTabPage
            // 
            this.songsOverviewTabPage.Controls.Add(this.knownSongsGroup);
            this.songsOverviewTabPage.Location = new System.Drawing.Point(4, 29);
            this.songsOverviewTabPage.Name = "songsOverviewTabPage";
            this.songsOverviewTabPage.Size = new System.Drawing.Size(1042, 600);
            this.songsOverviewTabPage.TabIndex = 2;
            this.songsOverviewTabPage.Text = " Songs ";
            this.songsOverviewTabPage.UseVisualStyleBackColor = true;
            // 
            // knownSongsGroup
            // 
            this.knownSongsGroup.BackColor = System.Drawing.Color.Transparent;
            this.knownSongsGroup.Controls.Add(this.label1);
            this.knownSongsGroup.Controls.Add(this.songsOverviewQuickSearchInput);
            this.knownSongsGroup.Controls.Add(this.songsOverviewQuickSearchLabel);
            this.knownSongsGroup.Controls.Add(this.songsOverview);
            this.knownSongsGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.knownSongsGroup.Location = new System.Drawing.Point(10, 10);
            this.knownSongsGroup.Name = "knownSongsGroup";
            this.knownSongsGroup.Padding = new System.Windows.Forms.Padding(16);
            this.knownSongsGroup.Size = new System.Drawing.Size(1020, 578);
            this.knownSongsGroup.TabIndex = 2;
            this.knownSongsGroup.TabStop = false;
            this.knownSongsGroup.Text = " [Known Songs] ";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(10, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1000, 1);
            this.label1.TabIndex = 3;
            // 
            // songsOverviewQuickSearchInput
            // 
            this.songsOverviewQuickSearchInput.Location = new System.Drawing.Point(120, 24);
            this.songsOverviewQuickSearchInput.Name = "songsOverviewQuickSearchInput";
            this.songsOverviewQuickSearchInput.Size = new System.Drawing.Size(882, 27);
            this.songsOverviewQuickSearchInput.TabIndex = 2;
            this.songsOverviewQuickSearchInput.TextChanged += new System.EventHandler(this.songsOverviewQuickSearchInput_TextChanged);
            // 
            // songsOverviewQuickSearchLabel
            // 
            this.songsOverviewQuickSearchLabel.AutoSize = true;
            this.songsOverviewQuickSearchLabel.Location = new System.Drawing.Point(15, 28);
            this.songsOverviewQuickSearchLabel.Name = "songsOverviewQuickSearchLabel";
            this.songsOverviewQuickSearchLabel.Size = new System.Drawing.Size(98, 20);
            this.songsOverviewQuickSearchLabel.TabIndex = 1;
            this.songsOverviewQuickSearchLabel.Text = "Quick Search";
            // 
            // songsOverview
            // 
            this.songsOverview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.songsOverview.Location = new System.Drawing.Point(16, 73);
            this.songsOverview.Name = "songsOverview";
            this.songsOverview.Size = new System.Drawing.Size(985, 495);
            this.songsOverview.TabIndex = 0;
            this.songsOverview.UseCompatibleStateImageBehavior = false;
            this.songsOverview.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.songsOverview_AfterLabelEdit);
            this.songsOverview.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.songsOverview_BeforeLabelEdit);
            this.songsOverview.DoubleClick += new System.EventHandler(this.songsOverview_DoubleClick);
            this.songsOverview.KeyUp += new System.Windows.Forms.KeyEventHandler(this.songsOverview_KeyUp);
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
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1100, 800);
            this.Name = "Main";
            this.Text = "Main";
            this.containerPanel.ResumeLayout(false);
            this.bodyPanel.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.artistsOverviewTabPage.ResumeLayout(false);
            this.knownArtistsGroup.ResumeLayout(false);
            this.knownArtistsGroup.PerformLayout();
            this.songsOverviewTabPage.ResumeLayout(false);
            this.knownSongsGroup.ResumeLayout(false);
            this.knownSongsGroup.PerformLayout();
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
        private GroupBox knownArtistsGroup;
        private TextBox artistsOverviewQuickSearchInput;
        private Label artistsOverviewQuickSearchLabel;
        private Label knownArtistsSep1;
        private Button importArtistsFromFreeFormText;
        private GroupBox knownSongsGroup;
        private Label label1;
        private TextBox songsOverviewQuickSearchInput;
        private Label songsOverviewQuickSearchLabel;
        private ListView songsOverview;
        private Button addNewArtist;
    }
}