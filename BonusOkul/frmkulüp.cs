using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web;

namespace BonusOkul
{
    public partial class frmkulüp : Form
    {
        public frmkulüp()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-AJM9AQ8\\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tblkulüpler where durum=1", baglantı);
        DataTable dt = new DataTable();
        da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        string durum = "1";
        private void frmkulüp_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand(" insert into tblkulüpler (kulüpad , durum ) values (@p1,@p2)", baglantı);
            komut.Parameters.AddWithValue("@p1", txtkulüpadı.Text);
            komut.Parameters.AddWithValue("@p2", durum);
            komut.ExecuteNonQuery ();
            baglantı .Close();
            MessageBox.Show("Kulüp Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide ();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.White;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulüpid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkulüpadı.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("update tblkulüpler set durum = 0 where kulüpid=@p1", baglantı);
            komut.Parameters.AddWithValue("@p1", txtkulüpid.Text);
            komut.ExecuteNonQuery ();
            baglantı .Close();
            MessageBox.Show("Silme İşlemi Gerçekleşti");
            liste ();

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglantı .Open();
            SqlCommand komut = new SqlCommand("update tblkulüpler set kulüpad=@p1 where kulüpid=@p2", baglantı);
            komut.Parameters.AddWithValue("@p1", txtkulüpadı.Text);
            komut.Parameters.AddWithValue("@p2", txtkulüpid.Text);
            komut.ExecuteNonQuery ();
            baglantı.Close();
            MessageBox.Show("Güncelleme İşlemi Yapılmıştır");
        }
    }
}
