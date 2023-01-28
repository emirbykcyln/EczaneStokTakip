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
    public partial class IlacDuzenle : Form

    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8LVVI2Q;Initial Catalog=EczaneStokSistemi;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds = new DataSet();
        SqlCommandBuilder cmdb;

        public IlacDuzenle()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Yaptığınız değişiklikler kaydedilmek üzere! Onaylıyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                cmdb = new SqlCommandBuilder(da);
                da.Update(ds,"medicTable");
                MessageBox.Show("Yaptığınız değişiklikler kaydedildi");
            }   
            else if(secenek == DialogResult.No)
            {
                MessageBox.Show("Yaptığınız değişiklikler kaydedilmedi");
            }
            

        }

        private void ilacDuzenle_Load(object sender, EventArgs e)
        {
            griddoldur();
        }
        void griddoldur()
        {
            con.Open();
            da = new SqlDataAdapter("select * from medicTable", con);
            da.Fill(ds, "medicTable");
            dataGridView1.DataSource = ds.Tables["medicTable"];
            con.Close();
        }
       
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            IlacGuncelle ilacGuncelle = new IlacGuncelle();
            ilacGuncelle.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
