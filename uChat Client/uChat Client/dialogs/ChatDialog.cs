using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
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

            setUi();
        }

        private void setUi()
        {
            new ChatManager().GetAllOnlineUsers();
            uiTextBoxForMessage.Select();
        }

        public void AddNewUserToUi(string nickName)
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

            //this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            //this.radioButton2.AutoSize = true;
            //this.radioButton2.Checked = true;
            //this.radioButton2.Dock = System.Windows.Forms.DockStyle.Top;
            //this.radioButton2.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            //this.radioButton2.Location = new System.Drawing.Point(0, 27);
            //this.radioButton2.Name = "radioButton2";
            //this.radioButton2.Size = new System.Drawing.Size(101, 27);
            //this.radioButton2.TabIndex = 1;
            //this.radioButton2.TabStop = true;
            //this.radioButton2.Text = "Friedolin";
            //this.radioButton2.UseVisualStyleBackColor = true;
        }

        private void uiButtonForSendMessage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(uiTextBoxForMessage.Text))
            {
                string messageToSend = uiTextBoxForMessage.Text;
                if (new ChatManager().SendMessage(messageToSend, getSelectedUserName()))
                {
                    uiTextBoxForMessage.Text = string.Empty;
                }
                else
                {
                    createErrorMessageBox("Couldn't send message please try again or restart the client.");
                }
            }
        }

        public void ShowMessage(string messageToSend, string nickName)
        {
            uiTextBoxForChat.Text += "[" + DateTime.Now + "]" + nickName + ": " + messageToSend + "\r\n";
            //move the caret to the end of the text
            uiTextBoxForChat.SelectionStart = uiTextBoxForChat.TextLength;
            //scroll to the caret
            uiTextBoxForChat.ScrollToCaret();
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