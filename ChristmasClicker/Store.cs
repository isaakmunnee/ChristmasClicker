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
    public partial class Store : Form
    {
        public Store()
        {
            InitializeComponent();
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClickerSystem.Buy(0);
            RefreshButtons();
        }

        public void RefreshButtons()
        {
            button1.Text = String.Format("Parent [10☺, 5 per sec]  {0}/2", ClickerSystem.Parent);
            button2.Text = String.Format("Grandparent [25☺, 15 per sec] {0}/4", ClickerSystem.Grandparent);
            button4.Text = String.Format("Sugar Daddy [100☺, 50 per sec] {0}/10", ClickerSystem.SugarDaddy);
            button3.Text = String.Format("Credit Card [200☺, 100 per sec] {0}/5", ClickerSystem.CreditCard);
            button8.Text = String.Format("Elf [5k☺, 500 per sec] {0}/50", ClickerSystem.Elf);
            button7.Text = String.Format("Workshop [15k☺, 1k per sec] {0}/10", ClickerSystem.Workshop);
            button6.Text = String.Format("Reindeer team [25k☺, 5k per sec] {0}/10", ClickerSystem.ReindeerTeam);
            button5.Text = String.Format("Sugar Elven [250k☺, 50k per sec] {0}/10", ClickerSystem.SugarElven);
            button12.Text = String.Format("Sugar Reindeer? [1mil☺, 250k per sec] {0}/5", ClickerSystem.SugarReindeer);
            button11.Text = String.Format("Sugar. [10mil☺, 1mil per sec] {0}/25", ClickerSystem.Sugar);
            button10.Text = String.Format("Splendid [100mil☺, 5mil per sec] {0}/25", ClickerSystem.Splendid);
            button9.Text = String.Format("Literally f*cking Santa [500mil☺, 50mil per sec] {0}/2", ClickerSystem.Santa);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClickerSystem.Buy(1);
            RefreshButtons();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClickerSystem.Buy(2);
            RefreshButtons();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClickerSystem.Buy(3);
            RefreshButtons();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ClickerSystem.Buy(4);
            RefreshButtons();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClickerSystem.Buy(5);
            RefreshButtons();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClickerSystem.Buy(6);
            RefreshButtons();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClickerSystem.Buy(7);
            RefreshButtons();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ClickerSystem.Buy(8);
            RefreshButtons();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ClickerSystem.Buy(9);
            RefreshButtons();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ClickerSystem.Buy(10);
            RefreshButtons();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ClickerSystem.Buy(11);
            RefreshButtons();
        }

        private void Store_Load(object sender, EventArgs e)
        {
            RefreshButtons();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ClickerSystem.BuySpeedUpgrade();
        }
    }
}
