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
using System.Diagnostics;

namespace Admin_przychodni
{

    public partial class OfficeHrsControl : UserControl
    {
        // do refaktoryzacji (spróbować utworzyć klasę dla poniższych zmiennych)
        private string office;
        private string begin;
        private string end;
        private string doctor;
        private string date;
        private string name;
        private string surname;
        private string specialization;
        private int doctorId;
        // do refaktoryzacji (spróbować zrobić globalne conn, command oraz reader)
        MySqlConnection conn = new MySqlConnection("datasource=sql7.freemysqlhosting.net;port=3306;username=sql7313340;password=EMvDjki61A");
        MySqlCommand command;
        MySqlDataReader reader;

        public OfficeHrsControl()
        {
            InitializeComponent();

            timePickerBegin.Format = DateTimePickerFormat.Custom;
            timePickerBegin.CustomFormat = "HH:mm";
            timePickerBegin.ShowUpDown = true;

            timePickerEnd.Format = DateTimePickerFormat.Custom;
            timePickerEnd.CustomFormat = "HH:mm";
            timePickerEnd.ShowUpDown = true;

            showAllDoctorData(true);

            disableButtons();
            hideInputFields();
            //setButton.Hide();
            editOfficeHrsButton.Hide();
            editRadioButton.Hide();
        }

        private void OfficeHrsControl_Load(object sender, EventArgs e)
        {
            if(Form1.isDoctor) // jeśli zalogowany lekarz
            {
                setButton.Hide();
                editOfficeHrsButton.Hide();
                deleteOfficeHrsButton.Hide();
                addRadioButton.Hide();
                editRadioButton.Hide();
                deleteRadioButton.Hide();
                filterRadioButton.Hide();
                filterButton.Enabled = true;
                showInputFiltersAndEditing();
                hideNonDoctorControlls();
            }
            else if (Form1.isReceptionist) // jeśli zalogowaniy recepcjonista
            {
                setButton.Hide();
                editOfficeHrsButton.Hide();
                deleteOfficeHrsButton.Hide();
                addRadioButton.Hide();
                editRadioButton.Hide();
                deleteRadioButton.Hide();
                filterRadioButton.Hide();
                filterButton.Enabled = true;
                showInputFiltersAndEditing();
            }
        }

        private void setButton_Click(object sender, EventArgs e) // dodanie dyżuru (przycisk)
        {
            errorMessage.Hide();
            if (isOfficeAvaliable() && isDoctorAvaliable())
            {
                AddOfficeHours();
                errorMessage.Show();
                errorMessage.Text = "Dodano dyzur pomyslnie";
                errorMessage.BackColor = Color.Green;
            }
            else
            {
                errorMessage.Show();
                errorMessage.BackColor = Color.Red;
                errorMessage.Text = "Blad";
                conn.Close();
            }
        }

        private bool isOfficeAvaliable() // sprawdzenie czy podany gabinet jest wolny w wyznaczonym czasie
        {
            getTextBoxes();

            conn.Open(); 
            string select = "SELECT Begin, End FROM sql7313340.Offices WHERE Office='" + office + "' AND (('" + begin + "' BETWEEN Begin AND End) OR ('" + end + "' BETWEEN Begin AND End)) AND DATE(Date)='" + date + "'";
            command = new MySqlCommand(select, conn);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                conn.Close();
                return false;
            }
            else
            {
                reader.Close();
                conn.Close();
                return true;
            }
        }

        private bool isDoctorAvaliable() // sprawdzenie czy podany lekarz jest wolny w wyznaczonym czasie
        {
            getTextBoxes();

            conn.Open();
            string select = "SELECT Begin, End FROM(sql7313340.Accounts a JOIN sql7313340.Doctors d ON a.Id = d.Id_account JOIN sql7313340.Offices o ON d.Id = o.Id_doctor) WHERE a.Login='" + doctor + "' AND (('" + begin + "' BETWEEN o.Begin AND o.End) OR ('" + end + "' BETWEEN o.Begin AND o.End)) AND DATE(o.Date)='" + date + "'";
            command = new MySqlCommand(select, conn);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                conn.Close();
                return false;
            }
            else
            {
                reader.Close();
                conn.Close();
                return true;
            }
        }

        private void AddOfficeHours() // dodanie dyżuru
        {
            getTextBoxes();

            conn.Open();
            string select = "SELECT d.Id FROM (sql7313340.Accounts a JOIN sql7313340.Doctors d ON a.Id = d.Id_account) WHERE a.Login='" + doctor + "'";
            command = new MySqlCommand(select, conn);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                doctorId = reader.GetInt32(0);
            }
            reader.Close();

            string insertOfficeHrs = "INSERT INTO sql7313340.Offices (Office, Date, Begin, End, Id_doctor) VALUES ('" + office + "','" + date + "','" + begin + "','" + end + "','" + doctorId + "')";
            command = new MySqlCommand(insertOfficeHrs, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void getTextBoxes() // pobranie danych z pól tekstowych
        {
            office = officeTextBox.Text;
            begin = timePickerBegin.Value.TimeOfDay.Hours.ToString() + ":" + timePickerBegin.Value.TimeOfDay.Minutes.ToString() + ":00";
            end = timePickerEnd.Value.TimeOfDay.Hours.ToString() + ":" + timePickerEnd.Value.TimeOfDay.Minutes.ToString() + ":00";
            doctor = doctorTextBox.Text;
            date = datePicker.Value.Year.ToString() + "-" + datePicker.Value.Month.ToString() + "-" + datePicker.Value.Day.ToString();
        }

        private void filterButton_Click(object sender, EventArgs e) // wyświetlenie filtrowanych dyżurów
        {
            errorMessage.Hide();

            getTextBoxes();
            specialization = specialization_TextBox.Text;
            name = fname_textBox.Text;
            surname = sname_textBox.Text;

            richTextBox1.Clear();

            if (Form1.isDoctor)
                doctor = Form1.login;

            conn.Open();
            string select = findWithFilters();
            if (select != " ")
            {
                command = new MySqlCommand(select, conn);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        richTextBox1.AppendText(reader.GetString(0) + ", " + reader.GetString(1) + ", " + reader.GetString(2) + ", " + reader.GetString(3).Split()[0] + ", " + reader.GetString(4).Split(':')[0] + ":" + reader.GetString(4).Split(':')[1] + "-" + reader.GetString(5).Split(':')[0] + ":" + reader.GetString(5).Split(':')[1] + ", " + reader.GetString(6) + "\n");
                    }
                }
                reader.Close();
                conn.Close();
            }
            else
            {
                errorMessage.Show();
                errorMessage.BackColor = Color.Red;
                errorMessage.Text = "Nie wybrano filtra";
                conn.Close();
            }
        }

        private string findWithFilters() // filtrowanie dyżurów
        {
            string select;

            if (office.Length != 0) // do refaktoryzacji (redundantne części selectów)
                select = "SELECT d.SecondName, d.FirstName, o.Office, o.Date, o.Begin, o.End, d.Specialization FROM (sql7313340.Accounts a JOIN sql7313340.Doctors d ON a.Id = d.Id_account JOIN sql7313340.Offices o ON d.Id = o.Id_doctor) WHERE DATEDIFF(o.Date,'" + DateTime.Today.ToString("yyyy-MM-dd") + "') >= 0 AND o.Office='" + office + "'";
            else if (doctor.Length != 0)
                select = "SELECT d.SecondName, d.FirstName, o.Office, o.Date, o.Begin, o.End, d.Specialization FROM (sql7313340.Accounts a JOIN sql7313340.Doctors d ON a.Id = d.Id_account JOIN sql7313340.Offices o ON d.Id = o.Id_doctor) WHERE DATEDIFF(o.Date,'" + DateTime.Today.ToString("yyyy-MM-dd") + "') >= 0 AND a.Login='" + doctor + "'";
            else if (begin != end)
                select = "SELECT d.SecondName, d.FirstName, o.Office, o.Date, o.Begin, o.End, d.Specialization FROM (sql7313340.Accounts a JOIN sql7313340.Doctors d ON a.Id = d.Id_account JOIN sql7313340.Offices o ON d.Id = o.Id_doctor) WHERE DATEDIFF(o.Date,'" + DateTime.Today.ToString("yyyy-MM-dd") + "') >= 0 AND o.Begin>='" + begin + "' AND o.End<='" + end + "'";
            else if(specialization.Length != 0)
                select = "SELECT d.SecondName, d.FirstName, o.Office, o.Date, o.Begin, o.End, d.Specialization FROM (sql7313340.Accounts a JOIN sql7313340.Doctors d ON a.Id = d.Id_account JOIN sql7313340.Offices o ON d.Id = o.Id_doctor) WHERE DATEDIFF(o.Date,'" + DateTime.Today.ToString("yyyy-MM-dd") + "') >= 0 AND d.Specialization='" + specialization + "'";
            else if(name.Length != 0)
                select = "SELECT d.SecondName, d.FirstName, o.Office, o.Date, o.Begin, o.End, d.Specialization FROM (sql7313340.Accounts a JOIN sql7313340.Doctors d ON a.Id = d.Id_account JOIN sql7313340.Offices o ON d.Id = o.Id_doctor) WHERE DATEDIFF(o.Date,'" + DateTime.Today.ToString("yyyy-MM-dd") + "') >= 0 AND d.FirstName='" + name + "'";
            else if (surname.Length != 0)
                select = "SELECT d.SecondName, d.FirstName, o.Office, o.Date, o.Begin, o.End, d.Specialization FROM (sql7313340.Accounts a JOIN sql7313340.Doctors d ON a.Id = d.Id_account JOIN sql7313340.Offices o ON d.Id = o.Id_doctor) WHERE DATEDIFF(o.Date,'" + DateTime.Today.ToString("yyyy-MM-dd") + "') >= 0 AND d.SecondName='" + surname + "'";
            else if (datePicker.CustomFormat == "dd/MM/yyyy")
                select = "SELECT d.SecondName, d.FirstName, o.Office, o.Date, o.Begin, o.End, d.Specialization FROM (sql7313340.Accounts a JOIN sql7313340.Doctors d ON a.Id = d.Id_account JOIN sql7313340.Offices o ON d.Id = o.Id_doctor) WHERE DATE(o.Date)='" + date + "'";
            else
                select = " ";

            if(select!=" ")
            {
                if (office.Length != 0)
                    select += " AND o.Office='" + office + "'";
                if (doctor.Length != 0)
                    select += " AND a.Login='" + doctor + "'";
                if (begin != end)
                    select += "AND o.Begin >= '" + begin + "' AND o.End <= '" + end + "'";
                if (specialization.Length != 0)
                    select += " AND d.Specialization='" + specialization + "'";
                if (name.Length != 0)
                    select += " AND d.FirstName='" + name + "'";
                if (surname.Length != 0)
                    select += " AND d.SecondName='" + surname + "'";
                if (datePicker.CustomFormat == "dd/MM/yyyy")
                    select += " AND DATE(o.Date)='" + date + "'";
            }
            
            return select;
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.CustomFormat = "dd/MM/yyyy";
        }

        private void timePickerBegin_ValueChanged(object sender, EventArgs e)
        {
            timePickerBegin.Format = DateTimePickerFormat.Custom;
            timePickerBegin.CustomFormat = "HH:mm";
            timePickerBegin.ShowUpDown = true;
        }

        private void timePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            timePickerEnd.Format = DateTimePickerFormat.Custom;
            timePickerEnd.CustomFormat = "HH:mm";
            timePickerEnd.ShowUpDown = true;
        }

        public void showSetButton()
        {
            setButton.Show();
        }

        public void hideNonDoctorControlls() // ukrycie pól zbędnych dla lekarza (lekarz widzi tylko własne dyżury)
        {
            fname_label.Hide();
            fname_textBox.Hide();
            sname_label.Hide();
            sname_textBox.Hide();
            specialization_Label.Hide();
            specialization_TextBox.Hide();
            doctorLabel.Hide();
            doctorTextBox.Hide();
        }

        public void showAllDoctorData(bool ifHistory) // wyświetlanie dyżurów aktualnych oraz historii
        {
            richTextBox1.Clear();

            string select;

            if (ifHistory)
            {
                select = "SELECT d.SecondName, d.FirstName, o.Office, o.Date, o.Begin, o.End, d.Specialization FROM (sql7313340.Accounts a JOIN sql7313340.Doctors d ON a.Id = d.Id_account JOIN sql7313340.Offices o ON d.Id = o.Id_doctor) WHERE DATEDIFF(o.Date,'" + DateTime.Today.ToString("yyyy-MM-dd") + "') >= 0";
            }
            else
            {
                select = "SELECT d.SecondName, d.FirstName, o.Office, o.Date, o.Begin, o.End, d.Specialization FROM (sql7313340.Accounts a JOIN sql7313340.Doctors d ON a.Id = d.Id_account JOIN sql7313340.Offices o ON d.Id = o.Id_doctor) WHERE DATEDIFF(o.Date,'" + DateTime.Today.ToString("yyyy-MM-dd") + "') < 0";
            }

            if (Form1.isDoctor)
            {
                doctor = Form1.login;
                select += " AND a.Login='" + Form1.login + "'";
            }

            conn.Open();
            
            command = new MySqlCommand(select, conn);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    richTextBox1.AppendText(reader.GetString(0) + ", " + reader.GetString(1) + ", " + reader.GetString(2) + ", " + reader.GetString(3).Split()[0] + ", " + reader.GetString(4).Split(':')[0] + ":" + reader.GetString(4).Split(':')[1] + "-" + reader.GetString(5).Split(':')[0] + ":" + reader.GetString(5).Split(':')[1] + ", " + reader.GetString(6) + "\n");
                }
            }

            reader.Close();
            conn.Close();
        }

        public void clearResults() // czyszczenie pól z filtrami dyżurów
        {
            officeTextBox.Clear();
            doctorTextBox.Clear();
            fname_textBox.Clear();
            sname_textBox.Clear();
            specialization_TextBox.Clear();
            //richTextBox1.Clear();
        }

        private void hideInputFields() // chowanie pól do filtrowania dyżurów
        {
            doctorLabel.Hide();
            doctorTextBox.Hide();
            officeLabel.Hide();
            officeTextBox.Hide();
            dateLabel.Hide();
            datePicker.Hide();
            beginLabel.Hide();
            timePickerBegin.Hide();
            endLabel.Hide();
            timePickerEnd.Hide();
            fname_label.Hide();
            fname_textBox.Hide();
            sname_label.Hide();
            sname_textBox.Hide();
            specialization_Label.Hide();
            specialization_TextBox.Hide();
        }

        private void showInputFiltersAndEditing() // pokazanie pól dla filtrowania oraz edycji dyżurów (edycja na razie nie działa)
        {
            showInputSetting();
            fname_label.Show();
            fname_textBox.Show();
            sname_label.Show();
            sname_textBox.Show();
            specialization_Label.Show();
            specialization_TextBox.Show();
        }

        private void showInputSetting() // pokazanie pól dla tworzenia dyżurów
        {
            officeLabel.Show();
            officeTextBox.Show();
            dateLabel.Show();
            datePicker.Show();
            beginLabel.Show();
            timePickerBegin.Show();
            endLabel.Show();
            timePickerEnd.Show();
        }

        private void showInputDeleting() // pokazanie pól dla usuwania dyżurów
        {
            doctorLabel.Show();
            doctorTextBox.Show();
            dateLabel.Show();
            datePicker.Show();
            beginLabel.Show();
            timePickerBegin.Show();
            endLabel.Show();
            timePickerEnd.Show();
        }

        private void disableButtons() // dezaktywacja przycisków
        {
            filterButton.Enabled = false;
            setButton.Enabled = false;
            deleteOfficeHrsButton.Enabled = false;
            editOfficeHrsButton.Enabled = false;
        }

        private void filterRadioButton_CheckedChanged(object sender, EventArgs e) // wybór filtrowania dyżurów
        {
            disableButtons();
            filterButton.Enabled = true;
            hideInputFields();
            clearResults();
            showInputFiltersAndEditing();
        }

        private void addRadioButton_CheckedChanged(object sender, EventArgs e) // wybór dodawania dyżurów
        {
            disableButtons();
            setButton.Enabled = true;
            hideInputFields();
            clearResults();
            showInputSetting();
            showInputDeleting();
        }

        private void deleteRadioButton_CheckedChanged(object sender, EventArgs e) // wybór usuwania dyżurów
        {
            disableButtons();
            deleteOfficeHrsButton.Enabled = true;
            hideInputFields();
            clearResults();
            showInputDeleting();
        }

        private void editRadioButton_CheckedChanged(object sender, EventArgs e) // wybór edycji dyżurów (edycja nie działa)
        {
            disableButtons();
            editOfficeHrsButton.Enabled = true;
            hideInputFields();
            clearResults();
            showInputFiltersAndEditing();
        }

        public void uncheckAll() // resetowanie możliwości wyboru między dodawaniem, filtrowaniem i usuwaniem dyżurów
        {
            if(filterRadioButton.Checked)
                filterRadioButton.Checked = false;
            if (addRadioButton.Checked)
                addRadioButton.Checked = false;
            if (deleteRadioButton.Checked)
                deleteRadioButton.Checked = false;
            if (editRadioButton.Checked)
                editRadioButton.Checked = false;
            clearResults();
            hideInputFields();
            disableButtons();
        }

        private void clearFilterButton_Click(object sender, EventArgs e) // wyczyszczenie filtrów (okno aplikacji wraca do stanu domyślego, pokazuje wszystkie dyżury)
        {
            richTextBox1.Clear();
            showAllDoctorData(true);
        }
    }
}
