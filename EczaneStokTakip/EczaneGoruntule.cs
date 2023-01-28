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
    public partial class EczaneGoruntule : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8LVVI2Q;Initial Catalog=EczaneStokSistemi;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        string serial;
        public EczaneGoruntule()
        {
            InitializeComponent();
        }
      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdminPanel adminpanel = new AdminPanel();
            adminpanel.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EczaneGoruntule_Load(object sender, EventArgs e)
        {
            griddoldur();
        }
        void griddoldur()
        {

            string sorgu = "select pharmname,pharmadress,pharmserialnumber,pharminsertdate from pharmacyTable where deleteRole=1";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "pharmacyTable");
            dataGridView1.DataSource = ds.Tables["pharmacyTable"];
            con.Close();
        }
        void MevcutEczaneler()
        {

            string sorgu = "select pharmname,pharmadress,pharmserialnumber,pharminsertdate from pharmacyTable where deleteRole=1";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "pharmacyTable");
            dataGridView1.DataSource = ds.Tables["pharmacyTable"];
            con.Close();
        }

        void SilinenEczaneler()
        {

            string sorgu = "select pharmname,pharmadress,pharmserialnumber,pharminsertdate from pharmacyTable where deleteRole=2";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "pharmacyTable");
            dataGridView1.DataSource = ds.Tables["pharmacyTable"];
            con.Close();
        }
        void Sil(string serial)
        {
            con.Open();
            string sql = "UPDATE pharmacyTable SET deleteRole = 2 where pharmserialnumber='" + serial + "'";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@pharmserialnumber", serial);
            com.ExecuteNonQuery();
            con.Close();
        }

        void GeriYukle(string serial)
        {
            con.Open();
            string sql = "UPDATE pharmacyTable SET deleteRole = 1 where pharmserialnumber='" + serial + "'";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@pharmserialnumber", serial);
            com.ExecuteNonQuery();
            con.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            MevcutEczaneler();
        }
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//farenin sağ tuşuna basılmışsa
            {

                int satir = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (satir > -1)
                {
                    dataGridView1.Rows[satir].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                    serial = dataGridView1.Rows[satir].Cells["pharmserialNumber"].Value.ToString();
                }
            }
        }





        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            Sil(serial);
            MevcutEczaneler();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            IlacDuzenle ilacDuzenle = new IlacDuzenle();
            ilacDuzenle.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SilinenEczaneler();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void geriYükleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GeriYukle(serial);
            SilinenEczaneler();
        }
    }
}


