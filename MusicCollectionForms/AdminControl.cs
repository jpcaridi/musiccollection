using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicCollectionModel.Interfaces;
using MusicCollectionController;
using MusicCollectionForms.Properties;

namespace MusicCollectionForms
{
    public partial class AdminControl : UserControl
    {
        private readonly BindingSource _bindingSource1 = new BindingSource();
        private readonly IMusicCollection _mMusicCollection;
        private readonly IAlbumLibrary _mAlbumLibrary;
        public AdminControl()
        {
            InitializeComponent();
        }

        public AdminControl(IMusicCollection musicCollection, IAlbumLibrary albumLibrary) : this()
        {
            _mMusicCollection = musicCollection;
            _mAlbumLibrary = albumLibrary;

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
