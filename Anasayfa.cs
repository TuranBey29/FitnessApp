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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\keleb\OneDrive\Resimler\Belgeler\SporDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            //dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            //dataGridView1.ColumnCount = 2; //Kaç kolon olacağı belirleniyor…

            //dataGridView1.Columns[0].Name = "Adı";//Kolonların adı belirleniyor
            //dataGridView1.Columns[1].Name = "Soyadı";

            //dataGridView1.Columns[0].Width = 200;
            //dataGridView1.Columns[1].Width = 200; //belirlenen kolonların genişliği ayarlanıyor

            baglanti.Open();
            string query = "select * from Kullanici";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //{
            //    int Index = dataGridView1.CurrentCell.RowIndex;
            //    dataGridView1.Select();

            //    var x = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            //    var a = dataGridView1.SelectedCells[0];
            //    var b = dataGridView1.SelectedCells[0].Value;
            //    var c = dataGridView1.SelectedCells[0].Value;
            //    //var c = dataGridView1.SelectedCells[0].Cells[2].Value;


            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
