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
        private readonly AdminControl _mAdminControl;
        private readonly UserLogin _mUserLoginControl;

        public MusicCollectionAdmin()
        {
            InitializeComponent();

            _mMusicCollection = Driver.CreateXmlMusicCollection();
            _mAlbumLibrary = Controller.ReadLibrary(_mMusicCollection.Persistance, TEST_LIBRARY_NAME);

            _mAdminControl = new AdminControl(_mMusicCollection, _mAlbumLibrary);
            _mAdminControl.Dock = DockStyle.Fill;
            _mAdminControl.Visible = false;

            _mUserLoginControl = new UserLogin();
            _mUserLoginControl.Dock = DockStyle.Fill;

            this.Controls.Add(_mAdminControl);
            this.Controls.Add(_mUserLoginControl);
        }
    }
}
