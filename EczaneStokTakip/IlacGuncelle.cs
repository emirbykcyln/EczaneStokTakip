using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.OleDb;

namespace EczaneStokTakip
{
    public partial class IlacGuncelle : Form
    {
        public IlacGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8LVVI2Q;Initial Catalog=EczaneStokSistemi;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        string serial;


        private void ilacGuncelle_Load(object sender, EventArgs e)
        {
            mevcutilaclar();
        }
        void mevcutilaclar()
        {
            
            string sorgu = "select ilacAdi,mg,serialNumber,kayitTarih from medicTable where deleteRole=1";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "medicTable");
            dataGridView1.DataSource = ds.Tables["medicTable"];
            con.Close();
        }

        void silinenilaclar()
        {

            string sorgu = "select ilacAdi,mg,serialNumber,kayitTarih from medicTable where deleteRole=2";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "medicTable");
            dataGridView1.DataSource = ds.Tables["medicTable"];
            con.Close();
        }
        void Sil(string serial)
            {
                con.Open();
                string sql = "UPDATE medicTable SET deleteRole = 2 where serialnumber='"+serial+"'";
                SqlCommand com = new SqlCommand(sql, con);
                com.Parameters.AddWithValue("@serialnumber", serial);
                com.ExecuteNonQuery();
                con.Close();
            }

        void GeriYukle(string serial)
        {
            con.Open();
            string sql = "UPDATE medicTable SET deleteRole = 1 where serialnumber='" + serial + "'";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@serialnumber", serial);
            com.ExecuteNonQuery();
            con.Close();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdminPanel adminpanel = new AdminPanel();
            adminpanel.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            IlacEkle ilacEkle = new IlacEkle();
            ilacEkle.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            silinenilaclar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mevcutilaclar();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//farenin sağ tuşuna basılmışsa
                {

                    int satir = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                    if (satir > -1)
                    {
                        dataGridView1.Rows[satir].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                        serial = dataGridView1.Rows[satir].Cells["serialNumber"].Value.ToString();
                    }
                }
        }


   


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            Sil(serial);
            mevcutilaclar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void geriYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeriYukle(serial);
            silinenilaclar();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IlacDuzenle ilacDuzenle = new IlacDuzenle();
            ilacDuzenle.Show();
            this.Hide();
        }
    }
}
