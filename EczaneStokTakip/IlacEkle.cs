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
    public partial class IlacEkle : Form
    {

        public IlacEkle()
        {
            InitializeComponent();
        }

        private void ilacEkle_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = ("Data Source=DESKTOP-8LVVI2Q;Initial Catalog=EczaneStokSistemi;Integrated Security=True");
            
            
                sc.Open();
                com.Connection = sc;
                com.CommandText = "INSERT INTO medicTable (ilacAdi,mg,serialnumber,kayitTarih,deleteRole) VALUES (@ilacadi,@mg,@serialnumber,@kayitTarih,@deleteRole)";
                com.Parameters.AddWithValue("@ilacadi", textBox1.Text.ToUpper());
                com.Parameters.AddWithValue("@mg", textBox2.Text);
                com.Parameters.AddWithValue("@serialNumber", textBox3.Text);
                com.Parameters.AddWithValue("@kayitTarih", DateTime.Now);
                com.Parameters.AddWithValue("@deleteRole", 1);
                com.ExecuteNonQuery();

                MessageBox.Show("İlaç verisi KAYDEDİLDİ !");
                sc.Close();
            
          
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            IlacGuncelle ilacGuncelle = new IlacGuncelle();
            ilacGuncelle.Show();
            this.Hide();
        }
    }
}
    
