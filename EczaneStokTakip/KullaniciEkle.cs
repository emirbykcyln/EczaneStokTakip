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
    public partial class KullaniciEkle : Form
    {
        public KullaniciEkle()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                SqlConnection sc = new SqlConnection();
                SqlCommand com = new SqlCommand();
                sc.ConnectionString = ("Data Source=DESKTOP-8LVVI2Q;Initial Catalog=EczaneStokSistemi;Integrated Security=True");
                sc.Open();
                com.Connection = sc;
                com.CommandText = "INSERT INTO Users (username,psw,Name,Surname,Adress,Phone,roleid) VALUES (@username,@psw,@Name,@Surname,@Adress,@Phone,@roleid)";
                com.Parameters.AddWithValue("@Name", textBox1.Text);
                com.Parameters.AddWithValue("@Surname", textBox2.Text);
                com.Parameters.AddWithValue("@Adress", textBox3.Text);
                com.Parameters.AddWithValue("@Phone", textBox4.Text);
                com.Parameters.AddWithValue("@username", textBox5.Text);
                com.Parameters.AddWithValue("@roleid", 2);
                byte[] data = UTF8Encoding.UTF8.GetBytes(textBox6.Text);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(textBox6.Text));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateEncryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        textBox6.Text = Convert.ToBase64String(results,0,results.Length);
                    }
                }
            
                com.Parameters.AddWithValue("@psw", textBox6.Text);

                

                MessageBox.Show("Kullanıcı verisi başarı ile kaydedildi !");
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
            AdminPanel adminpanel = new AdminPanel();
            adminpanel.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void KullaniciEkle_Load(object sender, EventArgs e)
        {

        }
    }
    }

