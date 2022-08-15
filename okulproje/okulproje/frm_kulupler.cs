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
    public partial class frm_kulupler : Form
    {
        public frm_kulupler()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-5R80TPD;Initial Catalog=okulproje;Integrated Security=True");

        private void frm_kulupler_Load(object sender, EventArgs e)
        {
            listele();
        }

        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_klupler where durum=1", baglantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            listele();

        }
        string durum = "1";

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_klupler (klupad,durum) values (@p1,@p2)", baglantı);
            komut.Parameters.AddWithValue("@p1", txtklupad.Text);
            komut.Parameters.AddWithValue("@p2", durum);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kulüp Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtklupad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }
        
        private void btnsil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("update tbl_klupler set durum=0 where KLUPID=@p1", baglantı);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kulüp Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("update tbl_klupler set klupad=@p1 where KLUPID=@p2", baglantı);
            komut.Parameters.AddWithValue("@p1", txtklupad.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kulüp Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}
