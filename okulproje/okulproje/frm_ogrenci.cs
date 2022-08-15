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
    public partial class frm_ogrenci : Form
    {
        public frm_ogrenci()
        {
            InitializeComponent();
        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();

        }


        SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-5R80TPD;Initial Catalog=okulproje;Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void frm_ogrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencilistesi();
           baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_klupler", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KLUPAD";
            comboBox1.ValueMember = "KLUPID";
            comboBox1.DataSource = dt;
            baglantı.Close();

        }
        string c = " ";
        private void btnekle_Click(object sender, EventArgs e)
        {
            
            if(radioButton1.Checked == true)
            {
                c = "KIZ";
            }
            if(radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
            ds.ogrenciekle(txtad.Text, txtsoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencilistesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // txtid.Text = comboBox1.SelectedValue.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.ogrencisil(int.Parse(txtid.Text)); 
            MessageBox.Show("Öğrenci silindi", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        string cinsiyet = " ";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (cinsiyet == "KIZ")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            if(cinsiyet == "ERKEK")
            {
                radioButton1.Checked=false;
                radioButton2.Checked=true;
            }
            
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.ogrenciguncelle(txtad.Text,txtsoyad.Text,byte.Parse(comboBox1.SelectedValue.ToString()),c,int.Parse(txtid.Text));
            MessageBox.Show("Güncelleme Yapıldı.", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        { 
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void btnara_Click(object sender, EventArgs e)
        {
          dataGridView1.DataSource =  ds.ogrencigetir(txtara.Text);
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }
    }
}
