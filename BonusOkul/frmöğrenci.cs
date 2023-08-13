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
using System.Web;
using System.Diagnostics.Eventing.Reader;


namespace BonusOkul
{
    public partial class frmöğrenci : Form
    {
        public frmöğrenci()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Green;
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-AJM9AQ8\\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void frmöğrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.öğrenclistesi();

            baglantı.Open();
            SqlCommand komut = new SqlCommand(" select * from tblkulüpler  ", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulüp.DisplayMember = "kulüpad";
            cmbkulüp.ValueMember = "kulüpid";
            cmbkulüp.DataSource = dt;
            baglantı.Close();
           
            


        }
        string c = " ";
        

private void btnekle_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";

            }

            ds.ogrenciekle(txtad.Text, txtsoyad.Text, byte.Parse(cmbkulüp.SelectedValue .ToString ()), c );
            MessageBox.Show("Öğrenci Ekleme Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.öğrenclistesi();
        }

        private void cmbkulüp_SelectedIndexChanged(object sender, EventArgs e)
        {
           // txtid.Text = cmbkulüp.SelectedValue.ToString ();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            
            ds.ogrencisil (txtsoyad  .Text );
            MessageBox.Show("silme işlemi başarılı");
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "ERKEK")
                {
                    radioButton2.Checked = true;
                }
                
            
            

            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "KIZ")
            {
                radioButton1.Checked = true;
            }
            

            
            cmbkulüp.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";

            }
            ds.ogrencigüncelle(txtad.Text, txtsoyad.Text, byte.Parse(cmbkulüp.SelectedValue.ToString()),c, int.Parse(txtid.Text));
            MessageBox.Show("güncelleme işlemi başarılı");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
            if(radioButton2.Checked == true)
            {
                c = "ERKEK";
                    
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";
                   
            }
            if (radioButton1.Checked == true)
            { c = "KIZ";
            }
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogranciarama(txtara.Text);
        }
    }
}
