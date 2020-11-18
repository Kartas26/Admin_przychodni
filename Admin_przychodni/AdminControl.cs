using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Admin_przychodni
{
    public partial class AdminControl : UserControl
    {
        public AdminControl()
        {
            InitializeComponent();
            backButton.Hide();
            HideTextBoxes();
            msgLabel.Hide();
            messeges1.Hide();
            officeHrsControl1.Hide();
        }

        private void AdminControl_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        // do refaktoryzacji (utworzyć globalne zmienne)
        MySqlConnection conn = new MySqlConnection("datasource=sql7.freemysqlhosting.net;port=3306;username=sql7313340;password=EMvDjki61A");
        MySqlCommand command;
        MySqlDataReader reader;
        // do refaktoryzacji (utworzyć klasę dla poniższych zmiennych)
        private bool doingDoctor = false;
        private bool doingReceptionist = false;
        private string fname = "";
        private string sname = "";
        private string spec = ""; 
        private string login = "";
        private string password = "";
        private string function = "";
        private int accountId = 0;

        private void AddDoctor() // dodanie nowego lekarza
        {
            PeekText();
            spec = specTextBox.Text;
            function = "Doctor";
            
            if (fname != "" && sname != "" && spec != "" && login != "" && password != "")
            {
                msgLabel.Hide();
                if (!FindLogin(login))
                {
                    conn.Open();
                    InsertAccount();
                    string insertDoctor = "INSERT INTO sql7313340.Doctors (FirstName, SecondName, Specialization, Id_account) VALUES('" + fname + "','" + sname + "','" + spec + "','" + accountId + "')";
                    command = new MySqlCommand(insertDoctor, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                    Succeeded();
                    specTextBox.Clear();
                }
                else
                {
                    ErrorLogin();
                }
            }
            else
            {
                ErrorEmptyTxt();
            }
        }

        private void AddReceptionist() // dodanie nowego recepcjonisty
        {
            PeekText();
            function = "Receptionist";
            
            if (fname != "" && sname != "" && login != "" && password != "")
            {
                msgLabel.Hide();
                if (!FindLogin(login))
                {
                    conn.Open();
                    InsertAccount();
                    string insertReceptionist = "INSERT INTO sql7313340.Receptionists (FirstName, SecondName, Id_account) VALUES('" + fname + "','" + sname + "','" + accountId + "')";
                    command = new MySqlCommand(insertReceptionist, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                    Succeeded();
                }
                else
                {
                    ErrorLogin();
                }
            }
            else
            {
                ErrorEmptyTxt();
            }
        }

        private void DeleteUser() // usunięcie użytkownika
        {
            login = setLoginTextBox.Text;
            FindLogin(login);
            string selectFunction = "SELECT Function FROM (sql7313340.Accounts) WHERE Login='" + login + "'";
            conn.Open();
            command = new MySqlCommand(selectFunction, conn);
            reader = command.ExecuteReader();
            reader.Read();
            function = reader.GetString(0);
            reader.Close();
            string delete = "DELETE FROM sql7313340." + function + "s WHERE Id_account='" + accountId + "'"; // delete from doctors or receptionists
            command = new MySqlCommand(delete, conn);
            command.ExecuteNonQuery();
            string deleteAccount = "DELETE FROM sql7313340.Accounts WHERE Id='" + accountId + "'"; // delete from accounts
            command = new MySqlCommand(deleteAccount, conn);
            command.ExecuteNonQuery();
            conn.Close();
            Succeeded();
        }
        // poniżej funkcje błędów oraz informacji o wykonanej operacji
        private void Succeeded()
        {
            ClearText();
            msgLabel.BackColor = Color.Green;
            msgLabel.Text = "Operacja zakończona sukcesem!";
            msgLabel.Show();
            accountId = 0;
        }

        private void ErrorEmptyTxt()
        {
            msgLabel.BackColor = Color.Red;
            msgLabel.Text = "Wszystkie pola muszą być wypełnione!";
            msgLabel.Show();
        }

        private void ErrorLogin()
        {
            msgLabel.BackColor = Color.Red;
            msgLabel.Text = "Taki login już istnieje!";
            msgLabel.Show();
            setLoginTextBox.Clear();
        }
        //
        private void InsertAccount() // utworzenie nowego konta użytkownika
        {
            string insertAccount = "INSERT INTO sql7313340.Accounts (Login, Password, Function) VALUES('" + login + "','" + password + "','" + function + "')";
            string select = "SELECT Id FROM (sql7313340.Accounts) WHERE Login='" + login + "'";
            command = new MySqlCommand(insertAccount, conn);
            command.ExecuteNonQuery();
            command = new MySqlCommand(select, conn);
            reader = command.ExecuteReader();
            reader.Read();
            accountId = reader.GetInt32(0);
            reader.Close();
            CreateMailbox(login);
        }

        private void CreateMailbox(string login) // utworzenie skrzynki pocztowej
        {
            string createMailbox = "CREATE TABLE `sql7313340`.`" + login + "Mailbox`( `Id` INT(255) NOT NULL AUTO_INCREMENT, `FromUser` VARCHAR(50), `Title` VARCHAR(1000), `Message` VARCHAR(5000), `ReadMsg` tinyint(1), Id_account INT(255), PRIMARY KEY(`Id`), FOREIGN KEY (Id_account) REFERENCES sql7313340.Accounts(Id)) ENGINE = InnoDB;";
            command = new MySqlCommand(createMailbox, conn);
            command.ExecuteNonQuery();
        }

        private void PeekText() // pobranie danych z pól tekstowych
        {
            fname = firstNameTextBox.Text;
            sname = secondNameTextBox.Text;
            login = setLoginTextBox.Text;
            password = setPasswordTextBox.Text;
        }

        private bool FindLogin(string login) // sprawdzenie czy login znajduje się w bazie
        {
            string select = "SELECT Id FROM (sql7313340.Accounts) WHERE Login='" + login + "'";
            conn.Open();
            command = new MySqlCommand(select, conn);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                accountId = reader.GetInt32(0);
            }
            reader.Close();
            conn.Close();
            if (accountId != 0)
                return true;
            else
                return false;
        }
        // ponizej funkcje do ukrywania, pokazywania elementów itp
        private void ClearText()
        {
            setLoginTextBox.Clear();
            setPasswordTextBox.Clear();
            firstNameTextBox.Clear();
            secondNameTextBox.Clear();
        }

        private void HideTextBoxes()
        {
            setLoginLabel.Hide();
            setLoginTextBox.Hide();
            setPasswordLabel.Hide();
            setPasswordTextBox.Hide();
            firstNameLabel.Hide();
            firstNameTextBox.Hide();
            secondNameLabel.Hide();
            secondNameTextBox.Hide();
            specLabel.Hide();
            specTextBox.Hide();
            addButton.Hide();
            deleteButton.Hide();
        }

        private void ShowTextBoxes()
        {
            backButton.Show();
            firstNameLabel.Show();
            firstNameTextBox.Show();
            secondNameLabel.Show();
            secondNameTextBox.Show();
        }

        private void DoctorActions()
        {
            doingDoctor = true;
            Switch();
            specLabel.Show();
            specTextBox.Show();
        }

        private void ReceptionistActions()
        {
            doingReceptionist = true;
            Switch();
        }

        private void Switch()
        {
            HideButtons();
            ShowTextBoxes();
        }

        private void HideButtons()
        {
            addDoctor.Hide();
            addOfficeHrsButton.Hide();
            addReceptionist.Hide();
            deleteAccountButton.Hide();
            mailButton.Hide();
            logoutButton.Hide();
            backButton.Show();
        }

        private void ShowButtons()
        {
            addDoctor.Show();
            addOfficeHrsButton.Show();
            addReceptionist.Show();
            deleteAccountButton.Show();
            mailButton.Show();
            logoutButton.Show();
            backButton.Show();
        }

        private void ShowSetLabels()
        {
            setLoginLabel.Show();
            setLoginTextBox.Show();
            setPasswordLabel.Show();
            setPasswordTextBox.Show();
        }
        //
        private void addDoctor_Click(object sender, EventArgs e)
        {
            DoctorActions();
            ShowSetLabels();
            addButton.Show();
        }

        private void addOfficeHrsButton_Click(object sender, EventArgs e) // dodanie dyżuru (przycisk)
        {
            HideButtons();
            officeHrsControl1.Show();
            officeHrsControl1.showSetButton();
        }

        private void addReceptionist_Click(object sender, EventArgs e)
        {
            ReceptionistActions();
            ShowSetLabels();
            addButton.Show();
        }

        private void deleteAccountButton_Click(object sender, EventArgs e) // usunięcie konta użytkownika (przycisk)
        {
            HideButtons();
            setLoginLabel.Show();
            setLoginTextBox.Show();
            deleteButton.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            HideTextBoxes();
            ShowButtons();
            msgLabel.Hide();
            ClearText();
            officeHrsControl1.uncheckAll();
            officeHrsControl1.Hide();
            backButton.Hide();
            officeHrsControl1.clearResults();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void addButton_Click(object sender, EventArgs e) // dodanie lekarza lub recepcjonisty (przycisk)
        {
            if (doingDoctor)
                AddDoctor();
            if (doingReceptionist)
                AddReceptionist();
        }

        private void deleteButton_Click(object sender, EventArgs e) // usunięcie użytkownika (przycisk)
        {
            DeleteUser();
        }

        private void mailButton_Click(object sender, EventArgs e) // wejście do skrzynki pocztowej
        {
            //stopBacgroundWorker();
            
            messeges1.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) // zliczanie nieprzeczytanych wiadomości, do refaktoryzacji
        {
            for (; ;)
            {
                int msgsToRead = Messeges.CheckNewMsgs();
                if(mailButton.InvokeRequired)
                {
                    mailButton.Invoke(new Action(delegate () { mailButton.Text = "Wiadomości (" + msgsToRead + ")"; }));
                }
                else
                    mailButton.Text = "Wiadomości (" + msgsToRead + ")";
                System.Threading.Thread.Sleep(5);
            }
        }

        private void stopBacgroundWorker()
        {
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.CancelAsync();
        }
    }
}
