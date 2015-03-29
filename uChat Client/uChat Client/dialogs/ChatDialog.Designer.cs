namespace uChat_Client.dialogs
{
    partial class ChatDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatDialog));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiLabelForTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.uiTextBoxForChat = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.uiTextBoxForMessage = new System.Windows.Forms.TextBox();
            this.uiButtonForSendMessage = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabelForTitleOfUsers = new System.Windows.Forms.Label();
            this.uiGroupBoxForUsers = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.uiGroupBoxForUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiLabelForTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(536, 460);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 99);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // uiLabelForTitle
            // 
            this.uiLabelForTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiLabelForTitle.AutoSize = true;
            this.uiLabelForTitle.Font = new System.Drawing.Font("Britannic Bold", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabelForTitle.ForeColor = System.Drawing.Color.Green;
            this.uiLabelForTitle.Location = new System.Drawing.Point(193, 24);
            this.uiLabelForTitle.Name = "uiLabelForTitle";
            this.uiLabelForTitle.Size = new System.Drawing.Size(257, 59);
            this.uiLabelForTitle.TabIndex = 1;
            this.uiLabelForTitle.Text = "nickName";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.uiTextBoxForChat, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(112, 110);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(420, 346);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // uiTextBoxForChat
            // 
            this.uiTextBoxForChat.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiTextBoxForChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTextBoxForChat.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBoxForChat.ForeColor = System.Drawing.Color.DarkGreen;
            this.uiTextBoxForChat.Location = new System.Drawing.Point(3, 3);
            this.uiTextBoxForChat.Multiline = true;
            this.uiTextBoxForChat.Name = "uiTextBoxForChat";
            this.uiTextBoxForChat.ReadOnly = true;
            this.uiTextBoxForChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uiTextBoxForChat.Size = new System.Drawing.Size(414, 258);
            this.uiTextBoxForChat.TabIndex = 0;
            this.uiTextBoxForChat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uiTextBoxForChat_MouseDown);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel3.Controls.Add(this.uiTextBoxForMessage, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.uiButtonForSendMessage, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 264);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(420, 82);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // uiTextBoxForMessage
            // 
            this.uiTextBoxForMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTextBoxForMessage.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBoxForMessage.ForeColor = System.Drawing.Color.DarkGreen;
            this.uiTextBoxForMessage.Location = new System.Drawing.Point(3, 3);
            this.uiTextBoxForMessage.Multiline = true;
            this.uiTextBoxForMessage.Name = "uiTextBoxForMessage";
            this.uiTextBoxForMessage.Size = new System.Drawing.Size(331, 76);
            this.uiTextBoxForMessage.TabIndex = 0;
            // 
            // uiButtonForSendMessage
            // 
            this.uiButtonForSendMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiButtonForSendMessage.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButtonForSendMessage.ForeColor = System.Drawing.Color.DarkGreen;
            this.uiButtonForSendMessage.Location = new System.Drawing.Point(340, 3);
            this.uiButtonForSendMessage.Name = "uiButtonForSendMessage";
            this.uiButtonForSendMessage.Size = new System.Drawing.Size(77, 76);
            this.uiButtonForSendMessage.TabIndex = 1;
            this.uiButtonForSendMessage.Text = "Send";
            this.uiButtonForSendMessage.UseVisualStyleBackColor = true;
            this.uiButtonForSendMessage.Click += new System.EventHandler(this.uiButtonForSendMessage_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.uiLabelForTitleOfUsers, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.uiGroupBoxForUsers, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 110);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.67052F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.32948F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(101, 346);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // uiLabelForTitleOfUsers
            // 
            this.uiLabelForTitleOfUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiLabelForTitleOfUsers.AutoSize = true;
            this.uiLabelForTitleOfUsers.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabelForTitleOfUsers.ForeColor = System.Drawing.Color.DarkGreen;
            this.uiLabelForTitleOfUsers.Location = new System.Drawing.Point(11, 7);
            this.uiLabelForTitleOfUsers.Name = "uiLabelForTitleOfUsers";
            this.uiLabelForTitleOfUsers.Size = new System.Drawing.Size(79, 15);
            this.uiLabelForTitleOfUsers.TabIndex = 0;
            this.uiLabelForTitleOfUsers.Text = "Online Users";
            // 
            // uiGroupBoxForUsers
            // 
            this.uiGroupBoxForUsers.Controls.Add(this.radioButton3);
            this.uiGroupBoxForUsers.Controls.Add(this.radioButton2);
            this.uiGroupBoxForUsers.Controls.Add(this.radioButton1);
            this.uiGroupBoxForUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBoxForUsers.Location = new System.Drawing.Point(0, 29);
            this.uiGroupBoxForUsers.Margin = new System.Windows.Forms.Padding(0);
            this.uiGroupBoxForUsers.Name = "uiGroupBoxForUsers";
            this.uiGroupBoxForUsers.Size = new System.Drawing.Size(101, 317);
            this.uiGroupBoxForUsers.TabIndex = 1;
            // 
            // radioButton3
            // 
            this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton3.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.radioButton3.Location = new System.Drawing.Point(0, 50);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(101, 25);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Fritz";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton2.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.radioButton2.Location = new System.Drawing.Point(0, 25);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(101, 25);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Friedolin";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton1.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.radioButton1.Location = new System.Drawing.Point(0, 0);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(101, 25);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Max";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ChatDialog
            // 
            this.AcceptButton = this.uiButtonForSendMessage;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(536, 460);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChatDialog";
            this.Text = "uChat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatDialog_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.uiGroupBoxForUsers.ResumeLayout(false);
            this.uiGroupBoxForUsers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label uiLabelForTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox uiTextBoxForMessage;
        private System.Windows.Forms.Button uiButtonForSendMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label uiLabelForTitleOfUsers;
        private System.Windows.Forms.Panel uiGroupBoxForUsers;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox uiTextBoxForChat;
    }
}