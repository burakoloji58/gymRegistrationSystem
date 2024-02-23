using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymKayıtları
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string kullanıcıAdı;
        string sifre;
        private void button1_Click(object sender, EventArgs e)
        {
            kullanıcıAdı = "gym";
            sifre = "123";
            if(textBox1.Text == kullanıcıAdı && textBox2.Text == sifre)
            {
                Form2 goster = new Form2();
                goster.Show();
                this.Hide();
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("kullanıcı adı veya şifre yanlış!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
