using System;
using System.Collections.Generic;
using System.Windows;
using MusicCollectionController;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionForms
{
    public partial class MainWindow : Window
    {
        private IUserInfo? _mUserInfo;
        private readonly IMusicCollection _mMusicCollection;
        private IAlbumLibrary? _mAlbumLibrary;

        public MainWindow()
        {
            InitializeComponent();
            _mMusicCollection = Driver.CreateXmlMusicCollection();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string userName = UserNameTextBox.Text;
            string password = PasswordBox.Password;

            IUserInfo? userInfo = _mMusicCollection.LogInService.LogIn(userName, password);

            if (userInfo != null)
            {
                _mUserInfo = userInfo;
                _mAlbumLibrary = Controller.ReadLibrary(_mMusicCollection.Persistance, _mUserInfo);

                LoginPanel.Visibility = Visibility.Collapsed;
                AdminPanel.Visibility = Visibility.Visible;

                BindAlbumLibrary();
                LoginErrorText.Visibility = Visibility.Collapsed;
                UserNameTextBox.Text = "";
                PasswordBox.Password = "";
            }
            else
            {
                LoginErrorText.Text = "Invalid username or password. Please try again.";
                LoginErrorText.Visibility = Visibility.Visible;
            }
        }

        private void BindAlbumLibrary()
        {
            if (_mAlbumLibrary != null)
            {
                AlbumDataGrid.ItemsSource = _mAlbumLibrary.Albums;
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var searchWindow = new SearchWindow(_mMusicCollection.ConsumerService);
            searchWindow.Owner = this;
            if (searchWindow.ShowDialog() == true)
            {
                IList<IAlbum> selectedAlbums = searchWindow.SelectedAlbums;
                if (selectedAlbums != null && _mAlbumLibrary != null)
                {
                    foreach (IAlbum album in selectedAlbums)
                    {
                        _mAlbumLibrary.AddAlbum(album);
                    }
                    BindAlbumLibrary();
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_mAlbumLibrary != null)
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

                MessageBox.Show(this, message, "Save");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (_mAlbumLibrary != null)
            {
                IAlbum? selectedAlbum = AlbumDataGrid.SelectedItem as IAlbum;
                if (selectedAlbum != null)
                {
                    _mAlbumLibrary.RemoveAlbum(selectedAlbum);
                    BindAlbumLibrary();
                }
            }
        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            _mUserInfo = null;
            _mAlbumLibrary = null;
            AdminPanel.Visibility = Visibility.Collapsed;
            LoginPanel.Visibility = Visibility.Visible;
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if (_mUserInfo != null)
            {
                var changePasswordWindow = new ChangePasswordWindow();
                changePasswordWindow.Owner = this;
                if (changePasswordWindow.ShowDialog() == true)
                {
                    string currentPassword = changePasswordWindow.CurrentPassword;
                    string newPassword = changePasswordWindow.NewPassword;

                    if (Controller.ChangePassword(_mMusicCollection.LogInService, _mUserInfo, currentPassword, newPassword))
                    {
                        MessageBox.Show(this, "Password has been successfully changed.", "Password Changed");
                    }
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
