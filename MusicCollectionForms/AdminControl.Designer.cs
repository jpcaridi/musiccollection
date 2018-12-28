namespace MusicCollectionForms
{
    partial class AdminControl
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
            this.searchButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.musicCollectionGridView = new System.Windows.Forms.DataGridView();
            this.albumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.musicLibraryLabel = new System.Windows.Forms.Label();
            this.logOffButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.musicCollectionGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(178, 34);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(97, 34);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // musicCollectionGridView
            // 
            this.musicCollectionGridView.AllowUserToAddRows = false;
            this.musicCollectionGridView.AllowUserToDeleteRows = false;
            this.musicCollectionGridView.AllowUserToOrderColumns = true;
            this.musicCollectionGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.musicCollectionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.musicCollectionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.albumName,
            this.artistName,
            this.albumYear,
            this.playCount,
            this.albumLink});
            this.musicCollectionGridView.Location = new System.Drawing.Point(16, 76);
            this.musicCollectionGridView.Name = "musicCollectionGridView";
            this.musicCollectionGridView.Size = new System.Drawing.Size(673, 420);
            this.musicCollectionGridView.TabIndex = 5;
            // 
            // albumName
            // 
            this.albumName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.albumName.DataPropertyName = "Name";
            this.albumName.HeaderText = "Album";
            this.albumName.Name = "albumName";
            this.albumName.Width = 61;
            // 
            // artistName
            // 
            this.artistName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.artistName.DataPropertyName = "Artist";
            this.artistName.HeaderText = "Artist";
            this.artistName.Name = "artistName";
            this.artistName.Width = 55;
            // 
            // albumYear
            // 
            this.albumYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.albumYear.DataPropertyName = "Year";
            this.albumYear.HeaderText = "Year";
            this.albumYear.Name = "albumYear";
            this.albumYear.Width = 54;
            // 
            // playCount
            // 
            this.playCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.playCount.DataPropertyName = "PlayCount";
            this.playCount.HeaderText = "Play Count";
            this.playCount.Name = "playCount";
            this.playCount.Width = 83;
            // 
            // albumLink
            // 
            this.albumLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.albumLink.DataPropertyName = "Url";
            this.albumLink.HeaderText = "Link";
            this.albumLink.Name = "albumLink";
            // 
            // musicLibraryLabel
            // 
            this.musicLibraryLabel.AutoSize = true;
            this.musicLibraryLabel.Location = new System.Drawing.Point(13, 60);
            this.musicLibraryLabel.Name = "musicLibraryLabel";
            this.musicLibraryLabel.Size = new System.Drawing.Size(69, 13);
            this.musicLibraryLabel.TabIndex = 4;
            this.musicLibraryLabel.Text = "Music Library";
            // 
            // logOffButton
            // 
            this.logOffButton.Location = new System.Drawing.Point(16, 34);
            this.logOffButton.Name = "logOffButton";
            this.logOffButton.Size = new System.Drawing.Size(75, 23);
            this.logOffButton.TabIndex = 8;
            this.logOffButton.Text = "Log Off";
            this.logOffButton.UseVisualStyleBackColor = true;
            this.logOffButton.Click += new System.EventHandler(this.logOffButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Location = new System.Drawing.Point(16, 502);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // AdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.logOffButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.musicCollectionGridView);
            this.Controls.Add(this.musicLibraryLabel);
            this.Name = "AdminControl";
            this.Size = new System.Drawing.Size(708, 536);
            ((System.ComponentModel.ISupportInitialize)(this.musicCollectionGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView musicCollectionGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumName;
        private System.Windows.Forms.DataGridViewTextBoxColumn artistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn playCount;
        private System.Windows.Forms.DataGridViewLinkColumn albumLink;
        private System.Windows.Forms.Label musicLibraryLabel;
        private System.Windows.Forms.Button logOffButton;
        private System.Windows.Forms.Button deleteButton;
    }
}
