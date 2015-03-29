namespace uChat_Client
{
    partial class LoginDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginDialog));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiLabelForNickname = new System.Windows.Forms.Label();
            this.uiTextBoxForNickName = new System.Windows.Forms.TextBox();
            this.uiButtonForLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 101);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // uiLabelForNickname
            // 
            this.uiLabelForNickname.AutoSize = true;
            this.uiLabelForNickname.Location = new System.Drawing.Point(112, 12);
            this.uiLabelForNickname.Name = "uiLabelForNickname";
            this.uiLabelForNickname.Size = new System.Drawing.Size(141, 13);
            this.uiLabelForNickname.TabIndex = 1;
            this.uiLabelForNickname.Text = "Please enter your nickname:";
            // 
            // uiTextBoxForNickName
            // 
            this.uiTextBoxForNickName.Location = new System.Drawing.Point(259, 9);
            this.uiTextBoxForNickName.Name = "uiTextBoxForNickName";
            this.uiTextBoxForNickName.Size = new System.Drawing.Size(205, 20);
            this.uiTextBoxForNickName.TabIndex = 2;
            // 
            // uiButtonForLogin
            // 
            this.uiButtonForLogin.Location = new System.Drawing.Point(259, 71);
            this.uiButtonForLogin.Name = "uiButtonForLogin";
            this.uiButtonForLogin.Size = new System.Drawing.Size(205, 23);
            this.uiButtonForLogin.TabIndex = 3;
            this.uiButtonForLogin.Text = "Login";
            this.uiButtonForLogin.UseVisualStyleBackColor = true;
            this.uiButtonForLogin.Click += new System.EventHandler(this.uiButtonForLogin_Click);
            // 
            // LoginDialog
            // 
            this.AcceptButton = this.uiButtonForLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(476, 106);
            this.Controls.Add(this.uiButtonForLogin);
            this.Controls.Add(this.uiTextBoxForNickName);
            this.Controls.Add(this.uiLabelForNickname);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginDialog";
            this.Text = "Login uChat";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label uiLabelForNickname;
        private System.Windows.Forms.TextBox uiTextBoxForNickName;
        private System.Windows.Forms.Button uiButtonForLogin;
    }
}

