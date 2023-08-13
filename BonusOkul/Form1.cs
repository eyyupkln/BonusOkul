using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusOkul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmoğrencinotlar frm = new frmoğrencinotlar();
            frm.numara = textBox1.Text;
             
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmöğretmen frm = new frmöğretmen ();
            frm.Show ();
            this.Hide ();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit ();
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Green;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }
    }
}
