﻿using System;
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            gosterFonk();
        }
        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-VMJIC736;Initial Catalog=GymKayitlari;Integrated Security=True");
        int id = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            Form2 goster = new Form2();
            goster.Show();
            this.Hide();
            //göster
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 ekle = new Form3();
            ekle.Show();
            this.Hide();
            //ekle
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 sil = new Form4();
            sil.Show();
            this.Hide();
            //sil
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //güncelle
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //güncellebutonu
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Lütfen Boş alanları doldurunuz!!!");
            }
            else
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Update Kayitlar set AdSoyad='" + textBox1.Text.ToString() + "', Yas='" + textBox2.Text.ToString() + "', UyelikBaslangic='" + textBox3.Text.ToString() + "', UyelikBitis='" + textBox4.Text.ToString() + "' where id=" + id + " ", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();

                gosterFonk();
            }
        }

        public void gosterFonk()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * From Kayitlar", baglan);
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

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //çift tıklama
            id = int.Parse(listView1.SelectedItems[0].SubItems[4].Text);

            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            giris.Show();
            this.Hide();
        }
    }
}
