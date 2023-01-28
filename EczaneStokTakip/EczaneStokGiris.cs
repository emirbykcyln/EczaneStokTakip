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
    public partial class EczaneStokGiris : Form
    {

        SqlConnection con;
        SqlCommand comm;

     
        public EczaneStokGiris()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UserPanel userPanel = new UserPanel();
            userPanel.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && textBox1.Text != "")
            {
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = ("Data Source=DESKTOP-8LVVI2Q;Initial Catalog=EczaneStokSistemi;Integrated Security=True");
            sc.Open();
            com.Connection = sc;
            com.CommandText = "INSERT INTO stockAdd (ilacAdi,mg,pharmname,pharmadress,stockPiece,deleteRole) VALUES (@ilacAdi,@mg,@pharmname,@pharmadress,@stockPiece,@deleteRole)";
            com.Parameters.AddWithValue("@ilacAdi", comboBox1.Text);
            com.Parameters.AddWithValue("@mg", comboBox2.Text);
            com.Parameters.AddWithValue("@pharmname", comboBox3.Text);
            com.Parameters.AddWithValue("@pharmadress", comboBox4.Text);
            com.Parameters.AddWithValue("@stockPiece", float.Parse(textBox1.Text));
                com.Parameters.AddWithValue("@deleteRole",1);

                MessageBox.Show("Stok verisi başarı ile kaydedildi !");
                com.ExecuteNonQuery();
                sc.Close();
            }else{
                MessageBox.Show("Lütfen eksik alanları doldurun !");

                }
            }

        private void stokGiris_Load(object sender, EventArgs e)
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
            com.CommandText = "Select * from pharmacyTable";
            com.Connection = con;
            com.CommandType = CommandType.Text;

            SqlDataReader drr;
            con.Open();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["pharmname"]);
                comboBox4.Items.Add(dr["pharmadress"]);

            }
            con.Close();
        }

        
    }
}
