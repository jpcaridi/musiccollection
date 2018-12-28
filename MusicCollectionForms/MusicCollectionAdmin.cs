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
        private readonly BindingSource _bindingSource1 = new BindingSource();
        private IUserInfo _mUserInfo;
        private readonly IMusicCollection _mMusicCollection;
        private IAlbumLibrary _mAlbumLibrary;
        private readonly AdminControl _mAdminControl;
        private readonly UserLogin _mUserLoginControl;

        public MusicCollectionAdmin()
        {
            InitializeComponent();

            _mMusicCollection = Driver.CreateXmlMusicCollection();

            _mAdminControl = new AdminControl(_mMusicCollection, _mAlbumLibrary);
            _mAdminControl.Dock = DockStyle.Fill;
            _mAdminControl.Visible = false;

            _mUserLoginControl = new UserLogin(_mMusicCollection.LogInService);
            _mUserLoginControl.Dock = DockStyle.Fill;

            this.Controls.Add(_mAdminControl);
            this.Controls.Add(_mUserLoginControl);

            _mUserLoginControl.OnLogin += UserLogIn;
            _mAdminControl.OnLogOut += _mAdminControl_OnLogOut;
        }

        private void _mAdminControl_OnLogOut(object sender)
        {
            _mUserInfo = null;
            _mUserLoginControl.Visible = true;
            _mAdminControl.Visible = false;
        }

        private void UserLogIn(object sender, LoginEventArgs e)
        {
            if (e.LogInSuccessful)
            {
                _mUserInfo = e.UserInfo;
                _mAlbumLibrary = Controller.ReadLibrary(_mMusicCollection.Persistance, _mUserInfo);

                _mAdminControl.SetAlbumLibrary(_mAlbumLibrary);

                _mUserLoginControl.Visible = false;
                _mAdminControl.Visible = true;
            }
            else
            {
                MessageBox.Show(this, "Please Try again.", "Log In Fail");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_mUserInfo != null)
            {
                var form = new ChangePasswordForm();
                form.ShowDialog(this);

                string currentPassword = form.CurrentPassword;
                string newPassword = form.NewPassword;

                if (Controller.ChangePassword(_mMusicCollection.LogInService, _mUserInfo, currentPassword, newPassword))
                {
                    MessageBox.Show(this, "Password has been successfully changed.", "Password Changed");
                }
            }
        }
    }
}
