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

namespace FitnessApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\keleb\OneDrive\Resimler\Belgeler\SporDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            //string query = "select * from User where kullaniciAdi = '" + textBox1.Text + "' and sifre= '" + textBox2.Text + "'";
            //string query = "select * from User";
            SqlCommand cmd = new SqlCommand("select * from Kullanici", baglanti);
            SqlDataReader rdr;
            using (rdr = cmd.ExecuteReader())
            {
                if (rdr.Read())
                {
                    if (rdr["kullaniciAdi"].ToString() == textBox1.Text && rdr["sifre"].ToString() == textBox2.Text)
                    {
                        Anasayfa frm = new Anasayfa();
                        this.Visible = false;
                        frm.ShowDialog();
                        baglanti.Close();

                    }
                    else
                    {
                        MessageBox.Show("veriler uyuşmadı");
                        baglanti.Close();

                    }
                }
            }

            //if (textBox1.Text != null || textBox2.Text != null)
            //{

            //    string query = "select * from User where kullaniciAdi = " + textBox1.Text + " and sifre= " + textBox2.Text;
            //    SqlCommand cmd = new SqlCommand(query, baglanti);
            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            if (reader.FieldCount == 0)
            //            {
            //                MessageBox.Show("Test");
            //            }
            //        }
            //    }
            //}


        }
    }
}
