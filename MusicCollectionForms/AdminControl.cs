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

        private class BindingAlbum : IAlbum
        {
            public BindingAlbum(IAlbum album)
            {
                Name = album.Name;
                Artist = album.Artist;
                Year = album.Year;
                PlayCount = album.PlayCount;
                Url = album.Url;
            }
            public string Name { get; set; }
            public string Artist { get; set; }
            public uint Year { get; set; }
            public int PlayCount { get; set; }
            public string Url { get; set; }
        }

        private class BindingAlbumLibrary : IAlbumLibrary
        {
            private List<BindingAlbum> _mAlbums;
            public BindingAlbumLibrary(IAlbumLibrary albumLibrary)
            {
                _mAlbums = new List<BindingAlbum>();
                if (albumLibrary != null)
                {
                    LibraryName = albumLibrary.LibraryName;
                    foreach (IAlbum a in albumLibrary.Albums)
                    {
                        _mAlbums.Add(new BindingAlbum(a));
                    }
                }
            }
            public string LibraryName { get; set ; }
            public IReadOnlyList<IAlbum> Albums => _mAlbums.AsReadOnly();

            public void AddAlbum(IAlbum album)
            {
                BindingAlbum newAlbum = new BindingAlbum(album);
                if (!_mAlbums.Contains(newAlbum))
                {
                    _mAlbums.Add(newAlbum);
                }
            }
            public bool RemoveAlbum(IAlbum album)
            {
                if (album == null) throw new ArgumentNullException(nameof(album));

                BindingAlbum bindingAlbum = new BindingAlbum(album);
                return _mAlbums.Contains(bindingAlbum) && _mAlbums.Remove(bindingAlbum);
            }
        }

        public delegate void LogOutEventHandler (object sender);

        private readonly BindingSource _bindingSource1 = new BindingSource();
        private readonly IMusicCollection _mMusicCollection;
        private BindingAlbumLibrary _mAlbumLibrary;

        public event LogOutEventHandler OnLogOut;
        public AdminControl()
        {
            InitializeComponent();
        }

        public AdminControl(IMusicCollection musicCollection, IAlbumLibrary albumLibrary) : this(musicCollection)
        {
            _mAlbumLibrary = new BindingAlbumLibrary(albumLibrary);
            Load += MusicCollectionGridView_Load;
        }

        public AdminControl(IMusicCollection musicCollection) : this()
        {
            _mMusicCollection = musicCollection;
        }

        private void MusicCollectionGridView_Load(object sender, EventArgs e)
        {
            BindAlbumLibrary();
        }


        private void BindAlbumLibrary()
        {
            _bindingSource1.Clear();
            foreach (IAlbum a in _mAlbumLibrary.Albums)
            {
                _bindingSource1.Add(a);
            }
            musicCollectionGridView.DataSource = _bindingSource1;
        }

        public void SetAlbumLibrary(IAlbumLibrary albumLibrary)
        {
            _mAlbumLibrary = new BindingAlbumLibrary(albumLibrary);
            BindAlbumLibrary();
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
                    BindingAlbum bindingAlbum = new BindingAlbum(a);
                    _bindingSource1.Add(bindingAlbum);
                }
            }
        }

        protected virtual void RaiseOnLogout()
        {
            OnLogOut?.Invoke(this);
        }

        private void logOffButton_Click(object sender, EventArgs e)
        {
            RaiseOnLogout();
        }
    }
}
