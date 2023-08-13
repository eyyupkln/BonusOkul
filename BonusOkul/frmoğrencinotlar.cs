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


namespace BonusOkul
{
    public partial class frmoğrencinotlar : Form
    {
        public frmoğrencinotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-AJM9AQ8\\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;
        

        private void frmoğrencinotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select dersad , sınav1,sınav2,sınav3,proje,ortalama,durum from tblnotlar inner join tbldersler on tblnotlar.dersid = tbldersler.dersid   where ogrid=@p1", baglantı);
            komut.Parameters.AddWithValue("@p1", numara);
           // this.Text = numara .ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut );
            DataTable dt = new DataTable();
            da.Fill( dt );
            dataGridView1 .DataSource = dt;

            // öğrenci ismini forma yazdırma 
            baglantı .Open();
            SqlCommand komut2 = new SqlCommand(" select ograd, ogrsoyad from tblogrenciler  where ogrıd=@p1 ", baglantı);
            komut2.Parameters.AddWithValue("@p1",numara );
            SqlDataReader dt2 = komut2 .ExecuteReader();
            while (dt2.Read())
            {
                this.Text = dt2[0]+ " " + dt2[1];
            }
            baglantı.Close();
        }
    }
}
