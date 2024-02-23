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

namespace GymKayıtları
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-VMJIC736;Initial Catalog=GymKayitlari;Integrated Security=True");

        private void button6_Click(object sender, EventArgs e)
        {
            //gösterbutonu
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * From Kayitlar",baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["AdSoyad"].ToString();
                ekle.SubItems.Add(oku["yas"].ToString());
                ekle.SubItems.Add(oku["UyelikBaslangic"].ToString());
                ekle.SubItems.Add(oku["UyelikBitis"].ToString());
                ekle.SubItems.Add(oku["id"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 ekle = new Form3();
            ekle.Show();
            this.Hide();
            //kayıtEkle
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //kayıtgöster
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 sil = new Form4();
            sil.Show();
            this.Hide();
            //kayıtsil
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 guncelle = new Form5();
            guncelle.Show();
            this.Hide();
            //kayıtgüncelle
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            giris.Show();
            this.Hide();
        }
    }
}
