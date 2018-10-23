namespace MusicCollectionForms
{
    partial class TestForm
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
            this.musicLibraryLabel = new System.Windows.Forms.Label();
            this.musicCollectionGridView = new System.Windows.Forms.DataGridView();
            this.albumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumLink = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.musicCollectionGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // musicLibraryLabel
            // 
            this.musicLibraryLabel.AutoSize = true;
            this.musicLibraryLabel.Location = new System.Drawing.Point(12, 9);
            this.musicLibraryLabel.Name = "musicLibraryLabel";
            this.musicLibraryLabel.Size = new System.Drawing.Size(69, 13);
            this.musicLibraryLabel.TabIndex = 0;
            this.musicLibraryLabel.Text = "Music Library";
            // 
            // musicCollectionGridView
            // 
            this.musicCollectionGridView.AllowUserToAddRows = false;
            this.musicCollectionGridView.AllowUserToDeleteRows = false;
            this.musicCollectionGridView.AllowUserToOrderColumns = true;
            this.musicCollectionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.musicCollectionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.albumName,
            this.artistName,
            this.albumYear,
            this.playCount,
            this.albumLink});
            this.musicCollectionGridView.Location = new System.Drawing.Point(12, 25);
            this.musicCollectionGridView.Name = "musicCollectionGridView";
            this.musicCollectionGridView.ReadOnly = true;
            this.musicCollectionGridView.Size = new System.Drawing.Size(683, 444);
            this.musicCollectionGridView.TabIndex = 1;
            // 
            // albumName
            // 
            this.albumName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.albumName.HeaderText = "Album";
            this.albumName.Name = "albumName";
            this.albumName.ReadOnly = true;
            this.albumName.Width = 61;
            // 
            // artistName
            // 
            this.artistName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.artistName.HeaderText = "Artist";
            this.artistName.Name = "artistName";
            this.artistName.ReadOnly = true;
            this.artistName.Width = 55;
            // 
            // albumYear
            // 
            this.albumYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.albumYear.HeaderText = "Year";
            this.albumYear.Name = "albumYear";
            this.albumYear.ReadOnly = true;
            this.albumYear.Width = 54;
            // 
            // playCount
            // 
            this.playCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.playCount.HeaderText = "Play Count";
            this.playCount.Name = "playCount";
            this.playCount.ReadOnly = true;
            this.playCount.Width = 83;
            // 
            // albumLink
            // 
            this.albumLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.albumLink.HeaderText = "Link";
            this.albumLink.Name = "albumLink";
            this.albumLink.ReadOnly = true;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 534);
            this.Controls.Add(this.musicCollectionGridView);
            this.Controls.Add(this.musicLibraryLabel);
            this.Name = "TestForm";
            this.Text = "Music Collection";
            ((System.ComponentModel.ISupportInitialize)(this.musicCollectionGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label musicLibraryLabel;
        private System.Windows.Forms.DataGridView musicCollectionGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumName;
        private System.Windows.Forms.DataGridViewTextBoxColumn artistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn playCount;
        private System.Windows.Forms.DataGridViewLinkColumn albumLink;
    }
}

