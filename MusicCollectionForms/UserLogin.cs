using System;
using System.Windows.Forms;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionForms
{
    public class LoginEventArgs
    {
        public LoginEventArgs(IUserInfo userInfo, bool logInSuccessful)
        {
            UserInfo = userInfo;
            LogInSuccessful = logInSuccessful;
        }
        public IUserInfo UserInfo { get; }
        public bool LogInSuccessful { get; }
    }

    public partial class UserLogin : UserControl
    {
        public delegate void LoginEventHandler(object sender, LoginEventArgs e);

        public event LoginEventHandler OnLogin;

        private ILogInService _mLogInService;
        public UserLogin()
        {
            InitializeComponent();
            this.VisibleChanged += UserLogin_VisibleChanged;
        }

        private void UserLogin_VisibleChanged(object sender, EventArgs e)
        {
            passwordTextBox.Text = "";
        }

        public UserLogin(ILogInService logInService) : this()
        {
            _mLogInService = logInService;
        }

        protected virtual void RaiseLogInEvent()
        {
            bool loggedIn = true;
            IUserInfo userInfo = _mLogInService?.LogIn(userNameTextBox.Text, passwordTextBox.Text);

            if (userInfo == null)
                loggedIn = false;

            OnLogin?.Invoke(this, new LoginEventArgs(userInfo, loggedIn));
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            RaiseLogInEvent();
        }

        private void userNameTextBox_Enter(object sender, EventArgs e)
        {
            this.ParentForm.AcceptButton = submitButton;
        }

        private void userNameTextBox_Leave(object sender, EventArgs e)
        {
            this.ParentForm.AcceptButton = null;
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            this.ParentForm.AcceptButton = submitButton;
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            this.ParentForm.AcceptButton = null;
        }
    }
}
