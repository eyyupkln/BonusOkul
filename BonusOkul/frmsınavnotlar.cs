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
using System.Data.SqlClient;

namespace BonusOkul
{
    public partial class frmsınavnotlar : Form
    {
        public frmsınavnotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tblnotlarTableAdapter ds =  new DataSet1TableAdapters.tblnotlarTableAdapter();
        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.notlistesi(int.Parse(txtid.Text));
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-AJM9AQ8\\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        private void frmsınavnotlar_Load(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand(" select * from tbldersler  ", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1 .DisplayMember = "dersad";
            comboBox1 .ValueMember = "dersid";
            comboBox1 .DataSource = dt;
            baglantı.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this .Hide ();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Green;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }
        int notid;
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            notid =int.Parse ( dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsınav1 .Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
           txtsınav3 .Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtproje .Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtortalama .Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtdurum .Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            comboBox1.SelectedValue    = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
             
           
        }
        int sınav1, sınav2, sınav3, proje;

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtid.Text = " ";
            txtsınav1 .Text =" ";
            txtsınav2 .Text =" ";
            txtsınav3 .Text =" ";
            txtproje .Text=" ";
            txtortalama .Text=" ";
            txtdurum .Text=" ";
            
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
          
            ds.notekleme (byte.Parse(comboBox1.SelectedValue.ToString()), int.Parse(txtid.Text), byte.Parse(txtsınav1.Text), byte.Parse(txtsınav2.Text), byte.Parse(txtsınav3.Text), byte.Parse(txtproje.Text), decimal.Parse(txtortalama.Text), bool.Parse(txtdurum.Text));
            MessageBox.Show("Kayıt İşlemi Gerçekleşti");
        }

        double ortalama;
        private void btnhesapla_Click(object sender, EventArgs e)
        {
            
            //string durum;
            sınav1 = Convert.ToInt16(txtsınav1.Text);
            sınav2 = Convert.ToInt16(txtsınav2.Text);
            sınav3 = Convert.ToInt16(txtsınav3.Text);
            proje  = Convert.ToInt16(txtproje.Text);
            ortalama= (sınav1 + sınav2 + sınav3 + proje )/ 4;
            txtortalama .Text = ortalama .ToString ();
            if (ortalama >= 50)
            {
                txtdurum.Text = "true";
            }
            else
            {
                txtdurum.Text = "false";
            }
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.notgüncelleme(byte.Parse (comboBox1.SelectedValue.ToString ()), int.Parse(txtid.Text), byte.Parse (txtsınav1 .Text ), byte.Parse(txtsınav2.Text), byte.Parse(txtsınav3.Text), byte.Parse(txtproje .Text), decimal .Parse(txtortalama .Text) ,bool.Parse(txtdurum.Text), notid);
            MessageBox.Show("güncelleme işlemi yapılmıştır");
        }
    }
}
