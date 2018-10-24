using System;
using System.Windows.Forms;
using MusicCollectionController;
using MusicCollectionForms.Properties;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionForms
{
    public partial class MusicCollectionAdmin : Form
    {
        private static readonly String TEST_LIBRARY_NAME = "TEST_LIBRARY";
        private BindingSource bindingSource1 = new BindingSource();
        private IMusicCollection _mMusicCollection;
        private IAlbumLibrary _mAlbumLibrary;

        public MusicCollectionAdmin()
        {
            InitializeComponent();

            _mMusicCollection = Driver.CreateXmlMusicCollection();
            _mAlbumLibrary = Controller.ReadLibrary(_mMusicCollection.Persistance, TEST_LIBRARY_NAME);

            this.Load += new System.EventHandler(MusicCollectionGridView_Load);
        }

        protected void InitializeData()
        {
            
            /*musicLibraryLabel.Text = albumLibrary.LibraryName;

            foreach (IAlbum a in albumLibrary.Albums)
            {
                musicCollectionGridView.Rows.Add(new object[] {a.Name, a.Artist, a.Year.ToString(), a.PlayCount.ToString(), a.Url});
            }*/

        }
        private void MusicCollectionGridView_Load(object sender, EventArgs e)
        {
            foreach (IAlbum a in _mAlbumLibrary.Albums)
            {
                bindingSource1.Add(a);
            }

            musicCollectionGridView.DataSource = bindingSource1;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string message = _mAlbumLibrary.LibraryName;

            if (Controller.WriteLibrary(_mMusicCollection.Persistance, _mAlbumLibrary))
            {
                message += " saved.";
            }
            else
            {
                message += " cannot be saved.";
            }

            MessageBox.Show(this, message, Resources.TestForm_saveButton_Click_Save);
        }
    }
}
