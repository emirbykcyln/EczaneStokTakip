using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EczaneStokTakip
{
    public partial class EczaneMevcutStok : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8LVVI2Q;Initial Catalog=EczaneStokSistemi;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public EczaneMevcutStok()
        {
            InitializeComponent();
        }
        private void EczaneMevcutStok_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "select pharmname from stockAdd";
            komut.Connection = con;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            con.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["pharmname"]);
            }
            con.Close();

        }
      private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select pharmname,pharmadress,ilacAdi,mg,stockPiece from stockAdd where pharmname='" + comboBox1.Text +"'";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds,"stockAdd");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

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
    }
}

