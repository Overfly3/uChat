using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uChat_Client.managers;

namespace uChat_Client.dialogs
{
    public partial class ChatDialog : Form
    {
        public ChatDialog(string nickName)
        {
            InitializeComponent();
            uiLabelForTitle.Text = nickName;
            uiTextBoxForMessage.Select();
        }

        private void uiButtonForSendMessage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(uiTextBoxForMessage.Text))
            {
                string messageToSend = uiTextBoxForMessage.Text;
                showMessage(messageToSend, new ServerCommunicationManager().SendMessage(messageToSend));
                uiTextBoxForMessage.Text = string.Empty;
                //move the caret to the end of the text
                uiTextBoxForChat.SelectionStart = uiTextBoxForChat.TextLength;
                //scroll to the caret
                uiTextBoxForChat.ScrollToCaret();
            }
        }

        private void showMessage(string messageToSend, string answer)
        {
            uiTextBoxForChat.Text += uiLabelForTitle.Text + ": " + messageToSend + "\r\n" + getSelectedUserName() + ": " + answer + "\r\n";
        }

        private string getSelectedUserName()
        {
            RadioButton checkedButton = uiGroupBoxForUsers.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            return checkedButton.Text;
        }

        private void ChatDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        private void uiTextBoxForChat_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(uiTextBoxForChat.Handle);
        }
    }
}
