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
    public partial class frm_ogretmen : Form
    {
        public frm_ogretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_kulupler fr = new frm_kulupler();
            fr.Show();
            
        }

        private void btnders_Click(object sender, EventArgs e)
        {
            frm_dersler frd = new frm_dersler();
            frd.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_ogrenci fr = new frm_ogrenci();
            fr.Show();
        }

        private void btnsinavnot_Click(object sender, EventArgs e)
        {
            frm_sınavnotları fr = new frm_sınavnotları();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
