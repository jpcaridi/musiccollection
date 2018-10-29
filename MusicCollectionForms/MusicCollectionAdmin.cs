using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MusicCollectionController;
using MusicCollectionForms.Properties;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionForms
{
    public partial class MusicCollectionAdmin : Form
    {
        private static readonly String TEST_LIBRARY_NAME = "TEST_LIBRARY";
        private readonly BindingSource _bindingSource1 = new BindingSource();
        private readonly IMusicCollection _mMusicCollection;
        private readonly IAlbumLibrary _mAlbumLibrary;

        public MusicCollectionAdmin()
        {
            InitializeComponent();

            _mMusicCollection = Driver.CreateXmlMusicCollection();
            _mAlbumLibrary = Controller.ReadLibrary(_mMusicCollection.Persistance, TEST_LIBRARY_NAME);

            Load += MusicCollectionGridView_Load;
        }

        private void MusicCollectionGridView_Load(object sender, EventArgs e)
        {
            foreach (IAlbum a in _mAlbumLibrary.Albums)
            {
                _bindingSource1.Add(a);
            }

            musicCollectionGridView.DataSource = _bindingSource1;

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

        private void searchButton_Click(object sender, EventArgs e)
        {
            var form = new SearchForm(_mMusicCollection.ConsumerService);
            form.ShowDialog(this);

            IList<IAlbum> searchList = form.SelectedAlbums;
            if (searchList != null)
            {
                foreach (IAlbum a in searchList)
                {
                    _mAlbumLibrary.AddAlbum(a);
                    _bindingSource1.Add(a);
                }
            }
        }
    }
}
