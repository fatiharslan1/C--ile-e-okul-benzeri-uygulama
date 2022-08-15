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
    public partial class frm_sınavnotları : Form
    {
        public frm_sınavnotları()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.tbl_notlarTableAdapter ds = new DataSet1TableAdapters.tbl_notlarTableAdapter();

        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.notlistesi(int.Parse(txtid.Text));
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

        SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-5R80TPD;Initial Catalog=okulproje;Integrated Security=True");

        private void frm_sınavnotları_Load(object sender, EventArgs e)
        {
          
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_dersler", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "DERSAD";
            comboBox1.ValueMember = "DERSID";
            comboBox1.DataSource = dt;
            baglantı.Close();
        }

        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtortalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }

        int sinav1, sinav2, sinav3, proje;
        double ortalama;

        private void btnhesapla_Click(object sender, EventArgs e)
        {
            
            //string durum;
            sinav1 = Convert.ToInt16(txtsınav1.Text);
            sinav2 = Convert.ToInt16(txtsınav2.Text);
            sinav3 = Convert.ToInt16(txtsınav3.Text);
            proje = Convert.ToInt16(txtproje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            txtortalama.Text = ortalama.ToString();
            if(ortalama >= 50)
            {
                txtdurum.Text = "True";
            }
            else
            {
                txtdurum.Text = "False";
            }


        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.notgüncelle(byte.Parse(comboBox1.SelectedValue.ToString()), int.Parse(txtid.Text),byte.Parse(txtsınav1.Text), byte.Parse(txtsınav2.Text), byte.Parse(txtsınav3.Text) , byte.Parse(txtproje.Text), decimal.Parse(txtortalama.Text), bool.Parse(txtdurum.Text), notid );
            MessageBox.Show("Güncelleme İşlemi Yapıldı", "BİLGİ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
