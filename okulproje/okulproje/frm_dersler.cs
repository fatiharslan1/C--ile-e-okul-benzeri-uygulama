using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace okulproje
{
    public partial class frm_dersler : Form
    {
        public frm_dersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_derslerTableAdapter ds = new DataSet1TableAdapters.tbl_derslerTableAdapter();

        private void frm_dersler_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = ds.derslistesi();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.dersekle(txtdersad.Text);
            MessageBox.Show("Ders eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.derslistesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
     

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.derssil(byte.Parse(txtid.Text));
            

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.dersguncelle(txtdersad.Text, byte.Parse(txtid.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdersad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
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
