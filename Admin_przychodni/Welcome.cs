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
    public partial class Welcome : UserControl
    {
        public Welcome()
        {
            InitializeComponent();
            Animation();
            toolTip1.SetToolTip(welcomeLabel, "Kliknij aby pominąć.");
        }

        private void Animation()
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) // animowanie napisu początkowego
        {
            for (int i = 5; i < 73; i++)
            {
                if(welcomeLabel.InvokeRequired)
                {
                    welcomeLabel.Invoke(new Action(delegate() { welcomeLabel.Font = new Font("Segoe Print", i); }));
                }
                else
                {
                    welcomeLabel.Font = new Font("Segoe Print", i);
                }
                System.Threading.Thread.Sleep(5);
            }
        }

        private void welcomeLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
