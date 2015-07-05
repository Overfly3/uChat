using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using uChat_Client.Entities;
using uChat_Client.managers;

namespace uChat_Client.dialogs
{
    public partial class ChatDialog : Form
    {
        public ChatDialog(string nickName)
        {
            InitializeComponent();
            uiLabelForTitle.Text = nickName;
            setUi();
            uiTextBoxForMessage.Select();
        }

        private void setUi()
        {
            foreach (User user in new ChatManager().GetAllOnlineUsers())
            {
                addNewUserToUi(user.NickName);
            }
        }

        private void addNewUserToUi(string nickName)
        {
            RadioButton radioButton = new RadioButton();
            radioButton.Appearance = System.Windows.Forms.Appearance.Button;
            radioButton.AutoSize = true;
            radioButton.Dock = System.Windows.Forms.DockStyle.Top;
            radioButton.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            radioButton.Name = "radioButton" + nickName;
            radioButton.Size = new System.Drawing.Size(101, 27);
            radioButton.Text = nickName;
            radioButton.UseVisualStyleBackColor = true;
        }

        private void uiButtonForSendMessage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(uiTextBoxForMessage.Text))
            {
                string messageToSend = uiTextBoxForMessage.Text;
                if (new ChatManager().SendMessage(messageToSend, getSelectedUserName()))
                {
                    showMessage(messageToSend);
                    uiTextBoxForMessage.Text = string.Empty;
                    //move the caret to the end of the text
                    uiTextBoxForChat.SelectionStart = uiTextBoxForChat.TextLength;
                    //scroll to the caret
                    uiTextBoxForChat.ScrollToCaret();
                }
                else
                {
                    createErrorMessageBox("Couldn't send message please try again or restart the client.");
                }
            }
        }

        private void showMessage(string messageToSend)
        {
            uiTextBoxForChat.Text += uiLabelForTitle.Text + ": " + messageToSend + "\r\n";
        }

        private string getSelectedUserName()
        {
            RadioButton checkedButton = uiGroupBoxForUsers.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            return checkedButton.Text;
        }

        private void ChatDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            new ChatManager().LogOut();
            Application.Exit();
        }

        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);

        private void uiTextBoxForChat_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(uiTextBoxForChat.Handle);
        }

        private void createErrorMessageBox(string errorText)
        {
            MessageBox.Show(errorText,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}