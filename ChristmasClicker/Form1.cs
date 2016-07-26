using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChristmasClicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.ClickButton_Hover;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.ClickButton_Norm;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Close_Hover;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Close_Norm;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            QuitDialoge qd = new QuitDialoge();
            qd.ShowDialog();
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.Store_Hover;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.Store_Norm;
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.Leaderboard_Hover;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.Leaderboard_Norm;
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.Stats_Hover;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.Stats_Norm;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ClickerSystem.AddClickViaPlayer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (50); 
            timer.Tick += new EventHandler(RefreshValues);
            timer.Start();
        }

        private void RefreshValues(object sender, EventArgs e)
        {
            label1.Text = String.Format("Total Delivered: {0}", ClickerSystem.totalDelivered);
            label2.Text = String.Format("Total Clicks: {0}", ClickerSystem.totalPlayerClicks);
            label3.Text = String.Format("Time Left: {1:00}:{0:00.00}",
                ClickerSystem.end.Subtract(DateTime.Now).TotalSeconds % 60,
                Math.Floor(ClickerSystem.end.Subtract(DateTime.Now).TotalSeconds / 60f) % 60);
                //ClickerSystem.timeInSecondsLeft % 60,
                //Math.Floor(ClickerSystem.timeInSecondsLeft / 60f) % 60);
            label4.Text = String.Format("Total Smiles: {0}", ClickerSystem.Smiles);
            label5.Text = String.Format("Worker click rate: {0}ms", ClickerSystem.ticksBeforeClick*10);
            label6.Text = String.Format("Click multiplier: {0}x", ClickerSystem.playerClickModifier);
        }

        private void pictureBox2_Click(object sender, MouseEventArgs e)
        {
            ClickerSystem.AddClickViaPlayer();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '=')
                ChEaT();

            if (!ClickerSystem.cheatMode)
                return;

            switch (e.KeyChar)
            {
                case 'c':
                case 'x':
                case 'z':
                case 'm':
                case 'n':
                case 'b':
                    ClickerSystem.AddClickViaPlayer();
                    break;
                default:
                    break;
            }
        }

        private void ChEaT()
        {
            CheatMode cmd = new CheatMode();
            cmd.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Store sd = new Store();
            sd.ShowDialog();
        }
    }
}
