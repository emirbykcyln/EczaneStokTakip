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

namespace EczaneStokTakip
{
    public partial class EczaneEkle : Form
    {
        public EczaneEkle()
        {
            InitializeComponent();
        }

        private void EczaneEkle_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = ("Data Source=DESKTOP-8LVVI2Q;Initial Catalog=EczaneStokSistemi;Integrated Security=True");
            sc.Open();

            com.Connection = sc;
            com.CommandText = "INSERT INTO pharmacyTable (pharmname,pharmadress,pharmserialnumber,pharminsertdate,deleteRole) VALUES (@pharmname,@pharmadress,@pharmserialnumber,@pharminsertdate,@deleteRole)";
            com.Parameters.AddWithValue("@pharmname",textBox1.Text.ToUpper());
            com.Parameters.AddWithValue("@pharmadress",textBox2.Text.ToUpper());
            com.Parameters.AddWithValue("@pharmserialnumber", textBox3.Text.ToUpper());
            com.Parameters.AddWithValue("@pharminsertdate", DateTime.Now);
            com.Parameters.AddWithValue("@deleteRole",1);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            com.ExecuteNonQuery();
            MessageBox.Show("Eczane verisi KAYDEDİLDİ !");

            sc.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminPanel adminpanel = new AdminPanel();
            adminpanel.Show();
            this.Hide();
        }
    }
}
