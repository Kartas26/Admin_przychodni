namespace Admin_przychodni
{
    partial class AdminControl
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
            this.logoutButton = new System.Windows.Forms.Button();
            this.addDoctor = new System.Windows.Forms.Button();
            this.addOfficeHrsButton = new System.Windows.Forms.Button();
            this.addReceptionist = new System.Windows.Forms.Button();
            this.deleteAccountButton = new System.Windows.Forms.Button();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.secondNameLabel = new System.Windows.Forms.Label();
            this.secondNameTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.setPasswordTextBox = new System.Windows.Forms.TextBox();
            this.setPasswordLabel = new System.Windows.Forms.Label();
            this.setLoginTextBox = new System.Windows.Forms.TextBox();
            this.setLoginLabel = new System.Windows.Forms.Label();
            this.specLabel = new System.Windows.Forms.Label();
            this.specTextBox = new System.Windows.Forms.TextBox();
            this.msgLabel = new System.Windows.Forms.Label();
            this.officeHrsControl1 = new Admin_przychodni.OfficeHrsControl();
            this.mailButton = new System.Windows.Forms.Button();
            this.messeges1 = new Admin_przychodni.Messeges();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutButton.Location = new System.Drawing.Point(3, 3);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(85, 25);
            this.logoutButton.TabIndex = 0;
            this.logoutButton.Text = "<- Wyloguj";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // addDoctor
            // 
            this.addDoctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addDoctor.Location = new System.Drawing.Point(181, 99);
            this.addDoctor.Name = "addDoctor";
            this.addDoctor.Size = new System.Drawing.Size(150, 47);
            this.addDoctor.TabIndex = 1;
            this.addDoctor.Text = "Zarejestruj lekarza";
            this.addDoctor.UseVisualStyleBackColor = true;
            this.addDoctor.Click += new System.EventHandler(this.addDoctor_Click);
            // 
            // addOfficeHrsButton
            // 
            this.addOfficeHrsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addOfficeHrsButton.Location = new System.Drawing.Point(181, 152);
            this.addOfficeHrsButton.Name = "addOfficeHrsButton";
            this.addOfficeHrsButton.Size = new System.Drawing.Size(150, 47);
            this.addOfficeHrsButton.TabIndex = 2;
            this.addOfficeHrsButton.Text = "Dyżury";
            this.addOfficeHrsButton.UseVisualStyleBackColor = true;
            this.addOfficeHrsButton.Click += new System.EventHandler(this.addOfficeHrsButton_Click);
            // 
            // addReceptionist
            // 
            this.addReceptionist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addReceptionist.Location = new System.Drawing.Point(181, 205);
            this.addReceptionist.Name = "addReceptionist";
            this.addReceptionist.Size = new System.Drawing.Size(150, 47);
            this.addReceptionist.TabIndex = 3;
            this.addReceptionist.Text = "Zarejestruj recepcjonistę";
            this.addReceptionist.UseVisualStyleBackColor = true;
            this.addReceptionist.Click += new System.EventHandler(this.addReceptionist_Click);
            // 
            // deleteAccountButton
            // 
            this.deleteAccountButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteAccountButton.Location = new System.Drawing.Point(180, 258);
            this.deleteAccountButton.Name = "deleteAccountButton";
            this.deleteAccountButton.Size = new System.Drawing.Size(150, 47);
            this.deleteAccountButton.TabIndex = 4;
            this.deleteAccountButton.Text = "Usuń użytkownika";
            this.deleteAccountButton.UseVisualStyleBackColor = true;
            this.deleteAccountButton.Click += new System.EventHandler(this.deleteAccountButton_Click);
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(181, 192);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.firstNameTextBox.TabIndex = 5;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(180, 176);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(29, 13);
            this.firstNameLabel.TabIndex = 6;
            this.firstNameLabel.Text = "Imię:";
            // 
            // secondNameLabel
            // 
            this.secondNameLabel.AutoSize = true;
            this.secondNameLabel.Location = new System.Drawing.Point(179, 215);
            this.secondNameLabel.Name = "secondNameLabel";
            this.secondNameLabel.Size = new System.Drawing.Size(56, 13);
            this.secondNameLabel.TabIndex = 7;
            this.secondNameLabel.Text = "Nazwisko:";
            // 
            // secondNameTextBox
            // 
            this.secondNameTextBox.Location = new System.Drawing.Point(182, 231);
            this.secondNameTextBox.Name = "secondNameTextBox";
            this.secondNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.secondNameTextBox.TabIndex = 8;
            // 
            // addButton
            // 
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.Location = new System.Drawing.Point(337, 237);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(70, 47);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Zarejestruj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.Location = new System.Drawing.Point(337, 121);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(70, 47);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // backButton
            // 
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(85, 25);
            this.backButton.TabIndex = 11;
            this.backButton.Text = "<- Powrót";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // setPasswordTextBox
            // 
            this.setPasswordTextBox.Location = new System.Drawing.Point(181, 154);
            this.setPasswordTextBox.Name = "setPasswordTextBox";
            this.setPasswordTextBox.Size = new System.Drawing.Size(150, 20);
            this.setPasswordTextBox.TabIndex = 12;
            // 
            // setPasswordLabel
            // 
            this.setPasswordLabel.AutoSize = true;
            this.setPasswordLabel.Location = new System.Drawing.Point(180, 138);
            this.setPasswordLabel.Name = "setPasswordLabel";
            this.setPasswordLabel.Size = new System.Drawing.Size(39, 13);
            this.setPasswordLabel.TabIndex = 13;
            this.setPasswordLabel.Text = "Hasło:";
            // 
            // setLoginTextBox
            // 
            this.setLoginTextBox.Location = new System.Drawing.Point(181, 115);
            this.setLoginTextBox.Name = "setLoginTextBox";
            this.setLoginTextBox.Size = new System.Drawing.Size(150, 20);
            this.setLoginTextBox.TabIndex = 14;
            // 
            // setLoginLabel
            // 
            this.setLoginLabel.AutoSize = true;
            this.setLoginLabel.Location = new System.Drawing.Point(180, 99);
            this.setLoginLabel.Name = "setLoginLabel";
            this.setLoginLabel.Size = new System.Drawing.Size(36, 13);
            this.setLoginLabel.TabIndex = 15;
            this.setLoginLabel.Text = "Login:";
            // 
            // specLabel
            // 
            this.specLabel.AutoSize = true;
            this.specLabel.Location = new System.Drawing.Point(180, 254);
            this.specLabel.Name = "specLabel";
            this.specLabel.Size = new System.Drawing.Size(72, 13);
            this.specLabel.TabIndex = 16;
            this.specLabel.Text = "Specjalizacja:";
            // 
            // specTextBox
            // 
            this.specTextBox.Location = new System.Drawing.Point(181, 271);
            this.specTextBox.Name = "specTextBox";
            this.specTextBox.Size = new System.Drawing.Size(149, 20);
            this.specTextBox.TabIndex = 17;
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.BackColor = System.Drawing.Color.Red;
            this.msgLabel.ForeColor = System.Drawing.Color.White;
            this.msgLabel.Location = new System.Drawing.Point(184, 83);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(35, 13);
            this.msgLabel.TabIndex = 18;
            this.msgLabel.Text = "label1";
            // 
            // officeHrsControl1
            // 
            this.officeHrsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.officeHrsControl1.Location = new System.Drawing.Point(0, 0);
            this.officeHrsControl1.Name = "officeHrsControl1";
            this.officeHrsControl1.Size = new System.Drawing.Size(556, 381);
            this.officeHrsControl1.TabIndex = 19;
            // 
            // mailButton
            // 
            this.mailButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mailButton.Location = new System.Drawing.Point(180, 311);
            this.mailButton.Name = "mailButton";
            this.mailButton.Size = new System.Drawing.Size(150, 47);
            this.mailButton.TabIndex = 20;
            this.mailButton.Text = "Wiadomości";
            this.mailButton.UseVisualStyleBackColor = true;
            this.mailButton.Click += new System.EventHandler(this.mailButton_Click);
            // 
            // messeges1
            // 
            this.messeges1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messeges1.Location = new System.Drawing.Point(0, 0);
            this.messeges1.Name = "messeges1";
            this.messeges1.Size = new System.Drawing.Size(556, 381);
            this.messeges1.TabIndex = 21;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // AdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.messeges1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.officeHrsControl1);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.deleteAccountButton);
            this.Controls.Add(this.addReceptionist);
            this.Controls.Add(this.addOfficeHrsButton);
            this.Controls.Add(this.addDoctor);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.secondNameTextBox);
            this.Controls.Add(this.secondNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.setPasswordTextBox);
            this.Controls.Add(this.setPasswordLabel);
            this.Controls.Add(this.setLoginTextBox);
            this.Controls.Add(this.setLoginLabel);
            this.Controls.Add(this.specLabel);
            this.Controls.Add(this.specTextBox);
            this.Controls.Add(this.mailButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "AdminControl";
            this.Size = new System.Drawing.Size(556, 381);
            this.Load += new System.EventHandler(this.AdminControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button addDoctor;
        private System.Windows.Forms.Button addOfficeHrsButton;
        private System.Windows.Forms.Button addReceptionist;
        private System.Windows.Forms.Button deleteAccountButton;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label secondNameLabel;
        private System.Windows.Forms.TextBox secondNameTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox setPasswordTextBox;
        private System.Windows.Forms.Label setPasswordLabel;
        private System.Windows.Forms.TextBox setLoginTextBox;
        private System.Windows.Forms.Label setLoginLabel;
        private System.Windows.Forms.Label specLabel;
        private System.Windows.Forms.TextBox specTextBox;
        private System.Windows.Forms.Label msgLabel;
        private OfficeHrsControl officeHrsControl1;
        private System.Windows.Forms.Button mailButton;
        private Messeges messeges1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
