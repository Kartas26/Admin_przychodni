namespace Admin_przychodni
{
    partial class Messeges
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backButton = new System.Windows.Forms.Button();
            this.createMsgButton = new System.Windows.Forms.Button();
            this.mailboxButton = new System.Windows.Forms.Button();
            this.msgTitleTextBox = new System.Windows.Forms.TextBox();
            this.msgRichTextBox = new System.Windows.Forms.RichTextBox();
            this.msgToTextBox = new System.Windows.Forms.TextBox();
            this.msgToLabel = new System.Windows.Forms.Label();
            this.msgTitleLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.msgListBox = new System.Windows.Forms.ListBox();
            this.answerButton = new System.Windows.Forms.Button();
            this.msgSuccessLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.Location = new System.Drawing.Point(3, 9);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(72, 24);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "<- Powrót";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // createMsgButton
            // 
            this.createMsgButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createMsgButton.Location = new System.Drawing.Point(144, 9);
            this.createMsgButton.Name = "createMsgButton";
            this.createMsgButton.Size = new System.Drawing.Size(235, 24);
            this.createMsgButton.TabIndex = 1;
            this.createMsgButton.Text = "Utwórz";
            this.createMsgButton.UseVisualStyleBackColor = true;
            this.createMsgButton.Click += new System.EventHandler(this.createMsgButton_Click);
            // 
            // mailboxButton
            // 
            this.mailboxButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mailboxButton.Location = new System.Drawing.Point(385, 9);
            this.mailboxButton.Name = "mailboxButton";
            this.mailboxButton.Size = new System.Drawing.Size(235, 24);
            this.mailboxButton.TabIndex = 2;
            this.mailboxButton.Text = "Skrzynka odbiorcza";
            this.mailboxButton.UseVisualStyleBackColor = true;
            this.mailboxButton.Click += new System.EventHandler(this.mailboxButton_Click);
            // 
            // msgTitleTextBox
            // 
            this.msgTitleTextBox.Location = new System.Drawing.Point(144, 76);
            this.msgTitleTextBox.Name = "msgTitleTextBox";
            this.msgTitleTextBox.Size = new System.Drawing.Size(475, 20);
            this.msgTitleTextBox.TabIndex = 3;
            // 
            // msgRichTextBox
            // 
            this.msgRichTextBox.Location = new System.Drawing.Point(144, 102);
            this.msgRichTextBox.Name = "msgRichTextBox";
            this.msgRichTextBox.Size = new System.Drawing.Size(475, 248);
            this.msgRichTextBox.TabIndex = 4;
            this.msgRichTextBox.Text = "";
            // 
            // msgToTextBox
            // 
            this.msgToTextBox.Location = new System.Drawing.Point(144, 50);
            this.msgToTextBox.Name = "msgToTextBox";
            this.msgToTextBox.Size = new System.Drawing.Size(475, 20);
            this.msgToTextBox.TabIndex = 5;
            // 
            // msgToLabel
            // 
            this.msgToLabel.AutoSize = true;
            this.msgToLabel.Location = new System.Drawing.Point(114, 57);
            this.msgToLabel.Name = "msgToLabel";
            this.msgToLabel.Size = new System.Drawing.Size(24, 13);
            this.msgToLabel.TabIndex = 6;
            this.msgToLabel.Text = "Do:";
            // 
            // msgTitleLabel
            // 
            this.msgTitleLabel.AutoSize = true;
            this.msgTitleLabel.Location = new System.Drawing.Point(98, 83);
            this.msgTitleLabel.Name = "msgTitleLabel";
            this.msgTitleLabel.Size = new System.Drawing.Size(40, 13);
            this.msgTitleLabel.TabIndex = 7;
            this.msgTitleLabel.Text = "Temat:";
            // 
            // sendButton
            // 
            this.sendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendButton.Location = new System.Drawing.Point(71, 329);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(67, 24);
            this.sendButton.TabIndex = 8;
            this.sendButton.Text = "Wyślij";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // msgListBox
            // 
            this.msgListBox.FormattingEnabled = true;
            this.msgListBox.Location = new System.Drawing.Point(144, 102);
            this.msgListBox.Name = "msgListBox";
            this.msgListBox.Size = new System.Drawing.Size(476, 251);
            this.msgListBox.TabIndex = 9;
            this.msgListBox.Click += new System.EventHandler(this.msgListBox_Click);
            // 
            // answerButton
            // 
            this.answerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.answerButton.Location = new System.Drawing.Point(3, 329);
            this.answerButton.Name = "answerButton";
            this.answerButton.Size = new System.Drawing.Size(72, 24);
            this.answerButton.TabIndex = 10;
            this.answerButton.Text = "Odpowiedz";
            this.answerButton.UseVisualStyleBackColor = true;
            this.answerButton.Click += new System.EventHandler(this.answerButton_Click);
            // 
            // msgSuccessLabel
            // 
            this.msgSuccessLabel.AutoSize = true;
            this.msgSuccessLabel.Location = new System.Drawing.Point(3, 356);
            this.msgSuccessLabel.Name = "msgSuccessLabel";
            this.msgSuccessLabel.Size = new System.Drawing.Size(150, 13);
            this.msgSuccessLabel.TabIndex = 11;
            this.msgSuccessLabel.Text = "Wiadomość została wystłana!";
            // 
            // Messeges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.msgSuccessLabel);
            this.Controls.Add(this.answerButton);
            this.Controls.Add(this.msgListBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.msgTitleLabel);
            this.Controls.Add(this.msgToLabel);
            this.Controls.Add(this.msgToTextBox);
            this.Controls.Add(this.msgRichTextBox);
            this.Controls.Add(this.msgTitleTextBox);
            this.Controls.Add(this.mailboxButton);
            this.Controls.Add(this.createMsgButton);
            this.Controls.Add(this.backButton);
            this.Name = "Messeges";
            this.Size = new System.Drawing.Size(623, 405);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button createMsgButton;
        private System.Windows.Forms.Button mailboxButton;
        private System.Windows.Forms.TextBox msgTitleTextBox;
        private System.Windows.Forms.RichTextBox msgRichTextBox;
        private System.Windows.Forms.TextBox msgToTextBox;
        private System.Windows.Forms.Label msgToLabel;
        private System.Windows.Forms.Label msgTitleLabel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ListBox msgListBox;
        private System.Windows.Forms.Button answerButton;
        private System.Windows.Forms.Label msgSuccessLabel;
    }
}
