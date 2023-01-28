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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EczaneStokTakip
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void adminpanel_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EczaneEkle EczaneEkle = new EczaneEkle();
            EczaneEkle.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EczaneGoruntule EczaneGoruntule = new EczaneGoruntule();
            EczaneGoruntule.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IlacGuncelle ilacGuncelle = new IlacGuncelle();
            ilacGuncelle.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KullaniciEkle KullaniciEkle = new KullaniciEkle();
            KullaniciEkle.Show();
            this.Hide();
        }
    }
}
