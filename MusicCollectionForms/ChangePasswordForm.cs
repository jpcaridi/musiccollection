using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicCollectionForms
{
    public partial class ChangePasswordForm : Form
    {
        public string CurrentPassword => currentPasswordTextBox.Text;

        public string NewPassword => newPasswordTestBox.Text;
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
