using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using uChat_Client.managers;

namespace uChat_Client
{
    public partial class LoginDialog : Form
    {
        private Thread myLoginThread;

        public LoginDialog()
        {
            InitializeComponent();
            //Care on refactoring otherwise UI wont be loaded the right way!
            myLoginThread = new Thread(new ChatManager(this).startListening);
            myLoginThread.Start();
        }

        private void uiButtonForLogin_Click(object sender, EventArgs e)
        {
            if (validateNickName())
            {
                if (!new ChatManager().LogIn(uiTextBoxForNickName.Text))
                {
                    createErrorMessageBox("Please make sure that you have an internet connection or change your nickname!");
                }
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
            if (Regex.IsMatch(uiTextBoxForNickName.Text, @"^[a-zA-Z]+$") && !string.IsNullOrEmpty(uiTextBoxForNickName.Text) && uiTextBoxForNickName.Text.Length <= 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Thread LoginThread { get { return myLoginThread; } }
    }
}