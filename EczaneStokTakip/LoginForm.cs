using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

namespace EczaneStokTakip
{
    public partial class LoginAdmin : Form
    {
        SqlConnection con=new SqlConnection();
       
        SqlCommand cmd;
        SqlDataReader dr;
        public LoginAdmin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }   

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
 
        }
        string sifrele(string sifreledeger)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(sifreledeger);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(sifreledeger));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    sifreledeger = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            return sifreledeger;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text != "")
            {
           
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-8LVVI2Q;Initial Catalog=EczaneStokSistemi;Integrated Security=True");
                SqlDataReader dr;
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Users where username=@username and psw=@psw;", con);

               string sifre= sifrele(textBox2.Text);
               cmd.Parameters.AddWithValue("username", textBox1.Text);
               cmd.Parameters.AddWithValue("psw", sifre);
               dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["roleid"].ToString() == 1.ToString())
                    {
                        MessageBox.Show("Admin Hosgeldiniz !");
                        AdminPanel adminpanel = new AdminPanel();
                        adminpanel.Show();
                        this.Hide();
                    }
                    else if (dr["roleid"].ToString() == 2.ToString())
                    {
                        MessageBox.Show("User Hosgeldiniz !");
                        UserPanel userPanel = new UserPanel();
                        userPanel.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Kullanıcı Adı ve Şifre bilgilerinizi kontrol ediniz . !");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                con.Close();
            }
            else
            {

                MessageBox.Show("Kullanıcı adı veya şifre girmediniz . Lütfen Kullanıcı adı ve şifrenizi girip tekrar deneyiniz !");
                textBox1.Visible=true;
                textBox2.Visible = true;
            }
        }
            

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
