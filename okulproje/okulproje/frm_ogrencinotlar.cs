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


namespace okulproje
{
    public partial class frm_ogrencinotlar : Form
    {
        public frm_ogrencinotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-5R80TPD;Initial Catalog=okulproje;Integrated Security=True");

        public string numara;

        private void frm_ogrencinotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA FROM tbl_notlar INNER JOIN tbl_dersler ON tbl_notlar.DERSID = tbl_dersler.DERSID WHERE OGRID = @p1", baglantı);
            komut.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara.ToString();  

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //ÖĞRENCİLERİN ADININ YAZDIRILMASI 
            baglantı.Open();
            SqlCommand komut1 = new SqlCommand("select OGRID,OGRAD,OGRSOYAD FROM tbl_ogrenciler where OGRID=@p1", baglantı);
            komut1.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                this.Text= dr[0] + "-" + dr[1] +" " + dr[2].ToString();
            }
            baglantı.Close();

        }
       

    }
}
