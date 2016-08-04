using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery
{
    public partial class Form1 : Form
    {
        LotteryClass lottery = new LotteryClass();
        int num1, num2, num3, num4, num5, num6;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void jugadaManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void jugadaAutomaticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Lottery");
        }

        private void verTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TicketForm tForm = new TicketForm();
            tForm.ShowDialog();
        }

        public Form1()
        {
            InitializeComponent();
            lottery.PrepareStage();
        }


        //Prevent future exceptions
        private void prevent(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!string.IsNullOrWhiteSpace(textbox.Text))
            {
                if (int.Parse(textbox.Text) <= 0 || int.Parse(textbox.Text) >= 39)
                {
                    MessageBox.Show("El rango debe ser de 1-38", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textbox.Clear();
                    textbox.Focus();
                }
            }
        }

        private void preventError(object sender, KeyEventArgs e)
        {
            if ((!(e.KeyCode < Keys.D0 || e.KeyCode <= Keys.D9)) || (!(e.KeyCode < Keys.NumPad0 || e.KeyCode <= Keys.NumPad9)))
            {
                e.SuppressKeyPress = true;
            }
        }

        
        //Automatic Game
        private void button1_Click(object sender, EventArgs e)
        {
            int[] numbers = lottery.AutomaticGame();
            label1.Text = numbers[0].ToString("00");
            label2.Text = numbers[1].ToString("00");
            label3.Text = numbers[2].ToString("00");
            label4.Text = numbers[3].ToString("00");
            label5.Text = numbers[4].ToString("00");
            label6.Text = numbers[5].ToString("00");
        }


        //Manual Game
        private void button2_Click(object sender, EventArgs e)
        {
            if( !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                num1 = int.Parse(textBox1.Text);
                num2 = int.Parse(textBox2.Text);
                num3 = int.Parse(textBox3.Text);
                num4 = int.Parse(textBox4.Text);
                num5 = int.Parse(textBox5.Text);
                num6 = int.Parse(textBox6.Text);
                lottery.ManualGame(new int[] { num1, num2, num3, num4, num5, num6});

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else
            {
                MessageBox.Show("No puede haber campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
