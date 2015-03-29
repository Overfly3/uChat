using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using uChat_Client.dialogs;
using uChat_Client.managers;

namespace uChat_Client
{
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
        }

        private void uiButtonForLogin_Click(object sender, EventArgs e)
        {
            if(validateNickName())
            {
                new ChatDialog(uiTextBoxForNickName.Text).Show();

                //set login dialog to unvisible if successfully logged in
                Visible = false;
            }
            else
            {
                createErrorMessageBox("Please make sure that your nickname doesn't contain special characters, numbers, is empty or not longer than 12 characters!");
            }
        }

        private void createErrorMessageBox(string errorText)
        {
            MessageBox.Show(errorText,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private bool validateNickName()
        {
            if (Regex.IsMatch(uiTextBoxForNickName.Text, @"^[a-zA-Z]+$") && ! string.IsNullOrEmpty(uiTextBoxForNickName.Text) && uiTextBoxForNickName.Text.Length <= 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
