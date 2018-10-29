using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicCollectionForms
{
    public partial class UserLogin : UserControl
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            loginLabel.Text = "Loging In";
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
