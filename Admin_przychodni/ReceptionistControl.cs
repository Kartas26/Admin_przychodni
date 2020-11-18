using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_przychodni
{
    public partial class ReceptionistControl : UserControl
    {
        public ReceptionistControl()
        {
            InitializeComponent();
            messeges1.Hide();
        }

        public void Inicialization()
        {
            officeHrsControl1.showAllDoctorData(true);
        }

        private void ReceptionistControl_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void logoutButton_Click(object sender, EventArgs e) // wylogowanie
        {
            this.Hide();
            officeHrsControl1.clearResults();
            stopBacgroundWorker();
        }

        private void mailButton_Click(object sender, EventArgs e) // wejście do skrzynki mailowej
        {
            //stopBacgroundWorker();

            messeges1.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) // zliczanie nieprzeczytanych wiadomości
        {
            for (; ;)
            {
                int msgsToRead = Messeges.CheckNewMsgs();
                if (mailButton.InvokeRequired)
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
