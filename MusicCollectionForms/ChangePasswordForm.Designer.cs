namespace MusicCollectionForms
{
    partial class ChangePasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.currentPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newPasswordTestBox = new System.Windows.Forms.TextBox();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currentPasswordTextBox
            // 
            this.currentPasswordTextBox.Location = new System.Drawing.Point(107, 35);
            this.currentPasswordTextBox.Name = "currentPasswordTextBox";
            this.currentPasswordTextBox.PasswordChar = '*';
            this.currentPasswordTextBox.Size = new System.Drawing.Size(341, 20);
            this.currentPasswordTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Password";
            // 
            // newPasswordTestBox
            // 
            this.newPasswordTestBox.Location = new System.Drawing.Point(107, 66);
            this.newPasswordTestBox.Name = "newPasswordTestBox";
            this.newPasswordTestBox.PasswordChar = '*';
            this.newPasswordTestBox.Size = new System.Drawing.Size(341, 20);
            this.newPasswordTestBox.TabIndex = 3;
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.Location = new System.Drawing.Point(107, 93);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(109, 23);
            this.changePasswordButton.TabIndex = 4;
            this.changePasswordButton.Text = "Change Password";
            this.changePasswordButton.UseVisualStyleBackColor = true;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 220);
            this.Controls.Add(this.changePasswordButton);
            this.Controls.Add(this.newPasswordTestBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentPasswordTextBox);
            this.Name = "ChangePasswordForm";
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox currentPasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newPasswordTestBox;
        private System.Windows.Forms.Button changePasswordButton;
    }
}