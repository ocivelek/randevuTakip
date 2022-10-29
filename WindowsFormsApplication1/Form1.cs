using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;//intro için

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(intro));//intro için
            t.Start();//intro için
            Thread.Sleep(5000);//intro için
            InitializeComponent();
            t.Abort();//intro için
        }
        public void intro()
        {
            Application.Run(new Form4());//public void den beli hepsi intro için
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Onur" || textBox1.Text == "ONUR" || textBox1.Text == "onur" && textBox2.Text == "19071907")
            {
                Form2 a = new Form2();
                this.Visible = false;
                a.ShowDialog();
                this.Visible = true;
            }
            else
                MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış!");
            textBox1.Clear();
            textBox2.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
                textBox2.UseSystemPasswordChar = true;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            this.Visible = false;
            a.ShowDialog();
            this.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult cvp;
            cvp = MessageBox.Show("Çıkmak İstediğinize Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cvp == DialogResult.Yes)
            {

            }
            else
                e.Cancel = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
