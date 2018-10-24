using System;
using System.Windows.Forms;
using MusicCollectionController;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionForms
{
    public partial class TestForm : Form
    {
        private static readonly String TEST_LIBRARY_NAME = "TEST_LIBRARY";
        public TestForm()
        {
            InitializeComponent();
            InitializeData();
        }

        protected void InitializeData()
        {
            IMusicCollection musicCollection = Driver.CreateXmlMusicCollection();
            IAlbumLibrary albumLibrary = Controller.ReadLibrary(musicCollection.Persistance, TEST_LIBRARY_NAME);
            musicLibraryLabel.Text = albumLibrary.LibraryName;

            foreach (IAlbum a in albumLibrary.Albums)
            {
                musicCollectionGridView.Rows.Add(new object[] {a.Name, a.Artist, a.Year.ToString(), a.PlayCount.ToString(), a.Url});
            }
        }
    }
}
