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
    public partial class DepoStokEkle : Form
    {
        public DepoStokEkle()
        {
            InitializeComponent();
        }
        private void DepoStokEkle_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-8LVVI2Q;Initial Catalog=EczaneStokSistemi;Integrated Security=True";
            SqlCommand com = new SqlCommand();
            com.CommandText = "Select * from medicTable";
            com.Connection = con;
            com.CommandType = CommandType.Text;

            SqlDataReader dr;
            con.Open();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["ilacAdi"]);
                comboBox2.Items.Add(dr["mg"]);

            }
            con.Close();


            SqlConnection conn = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-8LVVI2Q;Initial Catalog=EczaneStokSistemi;Integrated Security=True";
            SqlCommand comm = new SqlCommand();
            com.CommandText = "select serialnumber from medicTable";
            com.Connection = con;
            com.CommandType = CommandType.Text;

            SqlDataReader drr;
            con.Open();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["serialnumber"]);
                

            }
            con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "" && comboBox3.Text != "")
            {
                SqlConnection sc = new SqlConnection();
                SqlCommand com = new SqlCommand();
                sc.ConnectionString = ("Data Source=DESKTOP-8LVVI2Q;Initial Catalog=EczaneStokSistemi;Integrated Security=True");
                sc.Open();
                com.Connection = sc;
                com.CommandText = "INSERT INTO depoStockAdd (ilacAdi,mg,serialnumber,depoStockPiece,kayitTarih) VALUES (@ilacAdi,@mg,@serialnumber,@depoStockPiece,@kayitTarih)";
                com.Parameters.AddWithValue("@ilacAdi", comboBox1.Text);
                com.Parameters.AddWithValue("@mg", comboBox2.Text);
                com.Parameters.AddWithValue("@serialnumber", comboBox3.Text);
                com.Parameters.AddWithValue("@depoStockPiece", textBox1.Text);
                com.Parameters.AddWithValue("@kayitTarih", DateTime.Now);
                

                MessageBox.Show("Depo Stok verisi başarı ile kaydedildi !");
                com.ExecuteNonQuery();
                sc.Close();
            }
            else
            {
                MessageBox.Show("Lütfen eksik alanları doldurun !");

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UserPanel UserPanel = new UserPanel();
            UserPanel.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
