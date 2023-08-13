using BonusOkul.DataSet1TableAdapters;
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
    public partial class frmöğretmenişlem : Form
    {
        public frmöğretmenişlem()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters .tblogretmenlerTableAdapter  ds = new DataSet1TableAdapters .tblogretmenlerTableAdapter  ();

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-AJM9AQ8\\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        private void frmöğretmenişlem_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.öğretmenlistesi();


            baglantı.Open();
            SqlCommand komut = new SqlCommand(" select * from tbldersler  ", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbbranş .DisplayMember = "dersad";
            cmbbranş .ValueMember = "dersid";
            cmbbranş .DataSource = dt;
            baglantı.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtadsoyad .Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbbranş .SelectedValue  = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide ();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Green;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.öğretmenlistesi();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.öğretmenekle( byte.Parse ( cmbbranş.SelectedValue  .ToString()), txtadsoyad.Text);
            MessageBox.Show("Öğretmen Ekleme Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.öğretemnsil (byte.Parse (txtid.Text ));
            MessageBox.Show("silme işlemi başarılı");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.öğretmengüncelle (byte.Parse (cmbbranş .SelectedValue .ToString ()),txtadsoyad .Text ,byte .Parse (txtid .Text ));
            MessageBox.Show("güncelleme işlemi başarılı");
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.öğretmenarama(txtara.Text);
        }
    }
}
