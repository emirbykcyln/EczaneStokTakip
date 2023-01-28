using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneStokTakip
{
    public partial class UserPanel : Form
    {
        public UserPanel()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userPanel_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EczaneStokGiris EczaneStokGiris = new EczaneStokGiris();
            EczaneStokGiris.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EczaneMevcutStok EczaneMevcutStok = new EczaneMevcutStok();
            EczaneMevcutStok.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DepoStokEkle DepoStokEkle = new DepoStokEkle();
            DepoStokEkle.Show();
            this.Hide();
        }
    }
}
