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
    public partial class Messeges : UserControl
    {
        public Messeges()
        {
            InitializeComponent();
            HideMsg();
            HideMailbox();
            answerButton.Hide();
            msgSuccessLabel.Hide();
        }
        // do refaktoryzacji (spróbować utworzyć klasę dla poniższych zmiennych)
        private string to = "";
        private string from = "";
        private string title = "";
        private string message = "";
        private bool readMsg = false;
        private int accountId = 0;
        // do refaktoryzacji (spróbować zrobić globalne conn, command oraz reader)
        public static MySqlConnection conn = new MySqlConnection("datasource=sql7.freemysqlhosting.net;port=3306;username=sql7313340;password=EMvDjki61A");
        static MySqlCommand command;
        static MySqlDataReader reader;

        private void HideMailbox() // ukrycie skrzynki odbiorczej
        {
            msgListBox.Hide();
        }

        private void ShowMailbox() // pokazanie skrzynki odbiorczej
        {
            msgListBox.Show();
        }

        private void HideMsg() // ukrycie elementów do tworzenia nowej wiadomości
        {
            msgToLabel.Hide();
            msgToTextBox.Hide();
            msgTitleLabel.Hide();
            msgTitleTextBox.Hide();
            msgRichTextBox.Hide();
            sendButton.Hide();
        }

        private void ShowMsg() // pokazanie elementów do tworzenia nowej wiadomości
        {
            msgToLabel.Show();
            msgToTextBox.Show();
            msgTitleLabel.Show();
            msgTitleTextBox.Show();
            msgRichTextBox.Show();
            sendButton.Show();
        }

        private void ClearMsg() // wyczyszczenie pól do tworzenia nowej wiadomości
        {
            msgToTextBox.Clear();
            msgTitleTextBox.Clear();
            msgRichTextBox.Clear();
        }

        private void backButton_Click(object sender, EventArgs e) // powrót (przycisk)
        {
            ClearMsg();
            answerButton.Hide();
            HideMailbox();
            HideMsg();
            msgSuccessLabel.Hide();
            this.Hide();
        }

        private void createMsgButton_Click(object sender, EventArgs e) // wejście do utworzenia nowej wiadomości
        {
            HideMailbox();
            ClearMsg();
            ShowMsg();
            answerButton.Hide();
        }

        private void mailboxButton_Click(object sender, EventArgs e) // wejście do skrzynki odbiorczej
        {
            HideMsg();
            ClearMsg();
            msgListBox.Items.Clear();
            Mailbox();
            ShowMailbox();
            answerButton.Hide();
            msgSuccessLabel.Hide();
        }

        private void Mailbox() // pobranie wszystkich wiadomości
        {
            string select = "SELECT * FROM (sql7313340." + Form1.login + "Mailbox)";
            command = new MySqlCommand(select, conn);
            conn.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                from = reader.GetString(1);
                title = reader.GetString(2);
                msgListBox.Items.Add(from + " " + title);
            }
            reader.Close();
            conn.Close();
        }

        private void msgListBox_Click(object sender, EventArgs e) // wyświetlenie wiadomości
        {
            msgListBox.Hide();
            int msgId = msgListBox.SelectedIndex;
            string select = "SELECT * FROM (sql7313340." + Form1.login + "Mailbox)";
            string update = "";
            conn.Open();
            reader = command.ExecuteReader();
            for (int i = 0; i <= msgId; i++)
            {
                //if (i == msgId)
                //{
                    reader.Read();
                    message = reader.GetString(3);
                    msgToTextBox.Clear();
                    msgToTextBox.AppendText(reader.GetString(1)); // autouzupełnienie pola adresata do ewentualnej odpowiedzi
                    
                    update = "UPDATE sql7313340." + Form1.login + "Mailbox SET ReadMsg=true WHERE Message='" + message + "'";
                    
                //}
                //message = "";
            }
            reader.Close();
            command = new MySqlCommand(update, conn);
            command.ExecuteNonQuery();
            conn.Close();
            msgRichTextBox.AppendText(message);
            //if (msgListBox.SelectedItem.ToString() == "Wiadomość 1")
            //msgRichTextBox.AppendText("Wiadomość 1");
            msgRichTextBox.Show();
            answerButton.Show();
        }

        private void answerButton_Click(object sender, EventArgs e) // przycisk do odpowiedzi na wiadomość
        {
            HideMailbox();
            msgRichTextBox.Clear();
            ShowMsg();
            answerButton.Hide();
        }

        private void sendButton_Click(object sender, EventArgs e) // wysłanie wiadomości (przycisk)
        {
            SendMsg();
            msgSuccessLabel.BackColor = Color.Green;
            msgSuccessLabel.Show();
        }

        private void SendMsg() // wysłanie wiadomości
        {
            to = msgToTextBox.Text;
            title = msgTitleTextBox.Text;
            message = msgRichTextBox.Text;
            readMsg = false;
            string select = "SELECT Id FROM (sql7313340.Accounts) WHERE Login='" + Form1.login + "'";
            command = new MySqlCommand(select, conn);
            conn.Open();
            //reader.Close();
            reader = command.ExecuteReader();
            reader.Read();
            accountId = reader.GetInt32(0);
            reader.Close();
            string insertMsg = "INSERT INTO sql7313340." + to + "Mailbox (FromUser, Title, Message, ReadMsg, Id_account) VALUES('" + Form1.login + "','" + title + "','" + message + "','" + readMsg + "','" + accountId + "')";
            command = new MySqlCommand(insertMsg, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        private static MySqlConnection conn2 = new MySqlConnection("datasource=sql7.freemysqlhosting.net;port=3306;username=sql7313340;password=EMvDjki61A");
        private static MySqlCommand command2;
        private static MySqlDataReader reader2;

        public static int CheckNewMsgs() // zliczanie nieprzeczytanych wiadomości
        {
            int msgsToRead = 0;
            string select = "SELECT COUNT(Id) FROM (sql7313340." + Form1.login + "Mailbox) WHERE ReadMsg=0";
            command2 = new MySqlCommand(select, conn2);
            conn2.Open();
            reader2 = command2.ExecuteReader();
            reader2.Read();
            msgsToRead = reader2.GetInt32(0);
            reader2.Close();
            conn2.Close();
            if (msgsToRead > 0)
                return msgsToRead;
            else return 0;
        }
    }
}
