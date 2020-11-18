namespace Admin_przychodni
{
    partial class Form1
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
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.adminButton = new System.Windows.Forms.Button();
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.doctorButton = new System.Windows.Forms.Button();
            this.receptionistButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.receptionistControlPanel = new Admin_przychodni.ReceptionistControl();
            this.doctorControlPanel = new Admin_przychodni.DoctorControl();
            this.adminControlPanel = new Admin_przychodni.AdminControl();
            this.welcome1 = new Admin_przychodni.Welcome();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(295, 100);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(150, 13);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Witaj! Kto korzysta z aplikacji?";
            // 
            // adminButton
            // 
            this.adminButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adminButton.Location = new System.Drawing.Point(298, 116);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(150, 50);
            this.adminButton.TabIndex = 1;
            this.adminButton.Text = "Administrator";
            this.adminButton.UseVisualStyleBackColor = true;
            this.adminButton.Click += new System.EventHandler(this.adminButton_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(295, 113);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(36, 13);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "Login:";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(298, 129);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(150, 20);
            this.loginTextBox.TabIndex = 3;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(295, 152);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(39, 13);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Hasło:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(298, 168);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(150, 20);
            this.passwordTextBox.TabIndex = 5;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(295, 191);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(54, 13);
            this.errorLabel.TabIndex = 6;
            this.errorLabel.Text = "Złe dane!";
            // 
            // loginButton
            // 
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.Location = new System.Drawing.Point(298, 207);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(150, 50);
            this.loginButton.TabIndex = 7;
            this.loginButton.Text = "Zaloguj";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // doctorButton
            // 
            this.doctorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.doctorButton.Location = new System.Drawing.Point(298, 172);
            this.doctorButton.Name = "doctorButton";
            this.doctorButton.Size = new System.Drawing.Size(150, 50);
            this.doctorButton.TabIndex = 8;
            this.doctorButton.Text = "Lekarz";
            this.doctorButton.UseVisualStyleBackColor = true;
            this.doctorButton.Click += new System.EventHandler(this.doctorButton_Click);
            // 
            // receptionistButton
            // 
            this.receptionistButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.receptionistButton.Location = new System.Drawing.Point(298, 228);
            this.receptionistButton.Name = "receptionistButton";
            this.receptionistButton.Size = new System.Drawing.Size(150, 50);
            this.receptionistButton.TabIndex = 9;
            this.receptionistButton.Text = "Recepcjonista";
            this.receptionistButton.UseVisualStyleBackColor = true;
            this.receptionistButton.Click += new System.EventHandler(this.receptionistButton_Click);
            // 
            // backButton
            // 
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(85, 25);
            this.backButton.TabIndex = 10;
            this.backButton.Text = "<- Powrót";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // receptionistControlPanel
            // 
            this.receptionistControlPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.receptionistControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receptionistControlPanel.Location = new System.Drawing.Point(0, 0);
            this.receptionistControlPanel.Name = "receptionistControlPanel";
            this.receptionistControlPanel.Size = new System.Drawing.Size(718, 450);
            this.receptionistControlPanel.TabIndex = 13;
            // 
            // doctorControlPanel
            // 
            this.doctorControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doctorControlPanel.Location = new System.Drawing.Point(0, 0);
            this.doctorControlPanel.Name = "doctorControlPanel";
            this.doctorControlPanel.Size = new System.Drawing.Size(718, 450);
            this.doctorControlPanel.TabIndex = 12;
            // 
            // adminControlPanel
            // 
            this.adminControlPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.adminControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminControlPanel.Location = new System.Drawing.Point(0, 0);
            this.adminControlPanel.Name = "adminControlPanel";
            this.adminControlPanel.Size = new System.Drawing.Size(718, 450);
            this.adminControlPanel.TabIndex = 11;
            // 
            // welcome1
            // 
            this.welcome1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcome1.Location = new System.Drawing.Point(0, 0);
            this.welcome1.Name = "welcome1";
            this.welcome1.Size = new System.Drawing.Size(718, 450);
            this.welcome1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 450);
            this.Controls.Add(this.welcome1);
            this.Controls.Add(this.receptionistControlPanel);
            this.Controls.Add(this.doctorControlPanel);
            this.Controls.Add(this.adminControlPanel);
            this.Controls.Add(this.receptionistButton);
            this.Controls.Add(this.doctorButton);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.adminButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.backButton);
            this.Name = "Form1";
            this.Text = "Admin przychodni";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button adminButton;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button doctorButton;
        private System.Windows.Forms.Button receptionistButton;
        private System.Windows.Forms.Button backButton;
        private AdminControl adminControlPanel;
        private DoctorControl doctorControlPanel;
        private ReceptionistControl receptionistControlPanel;
        private Welcome welcome1;
    }
}

