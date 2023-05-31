using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerChess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //start lan game
            FormGameLAN formGameLAN = new FormGameLAN();
            this.Hide();
            formGameLAN.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //start game vs ai
            FormGameAI formGameAI = new FormGameAI();
            this.Hide();
            formGameAI.ShowDialog();
            this.Close();
        }
    }
}
