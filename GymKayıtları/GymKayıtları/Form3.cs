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

namespace GymKayıtları
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-VMJIC736;Initial Catalog=GymKayitlari;Integrated Security=True");

        public void textboxTemizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //kaydetbutonu
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Lütfen Boş alanları doldurunuz!!!");
            }
            else
            {
                label1.Visible = true;
                baglan.Open();
                SqlCommand komut = new SqlCommand("Insert into Kayitlar (AdSoyad,Yas,UyelikBaslangic,UyelikBitis) Values ('" + textBox1.Text.ToString() + "', '" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "') ", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                textboxTemizle();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 goster = new Form2();
            goster.Show();
            this.Hide();
            //kayıtgöster
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //kayıtekle
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

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            giris.Show();
            this.Hide();
        }
    }
}
