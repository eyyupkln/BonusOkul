using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BonusOkul
{
    public partial class frmdersler : Form
    {
        public frmdersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tblderslerTableAdapter ds = new DataSet1TableAdapters.tblderslerTableAdapter();
        private void frmdersler_Load(object sender, EventArgs e)
        {
          
            dataGridView1.DataSource = ds.derslistesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide ();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6 .BackColor = Color.Green ;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.derseklee( txtdersadı .Text );

            MessageBox.Show("ekleme işlemi yapıldı");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.derslistesi();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.derssil(byte.Parse(txtdersid.Text));
            MessageBox.Show("Silme işlemi gerçekleşti");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.dersgüncelle(txtdersadı.Text, byte.Parse(txtdersid.Text));
            MessageBox.Show("güncelleme işlemi gerçekleşti");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdersadı.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
