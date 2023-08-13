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
    public partial class frmöğretmen : Form
    {
        public frmöğretmen()
        {
            InitializeComponent();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            frmkulüp frm = new frmkulüp();
            frm.Show();
        }

        private void btndersişlem_Click(object sender, EventArgs e)
        {
            frmdersler frm = new frmdersler();
            frm.Show();
            this.Hide ();
        }

        private void btnçğrenciişlem_Click(object sender, EventArgs e)
        {
            frmöğrenci  fr = new frmöğrenci();
            fr .Show();
        }

        private void btnsınavnot_Click(object sender, EventArgs e)
        {
            frmsınavnotlar frm = new frmsınavnotlar ();
            frm .Show();
           
        }

        private void btnöğretmenişlem_Click(object sender, EventArgs e)
        {
            frmöğretmenişlem frm = new frmöğretmenişlem();
            frm .Show();
        }
    }
}
