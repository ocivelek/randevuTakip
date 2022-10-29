using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
         OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=randev.accdb");
        OleDbCommand komut = new OleDbCommand();
        DataSet st = new DataSet();
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            //textBox6.Text = DateTime.Now.ToShortDateString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {  
            timer1.Start();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || radioButton1.Checked == false && radioButton2.Checked == false)
            {
                if (comboBox1.Text == "")
                {
                    errorProvider1.SetError(comboBox1, "Boş Alan!");
                    errorProvider1.BlinkRate = 600;
                }
                else
                    errorProvider1.Clear();
                if (textBox2.Text == "")
                {
                    errorProvider2.SetError(textBox2, "Boş Alan!");
                    errorProvider2.BlinkRate = 600;
                }
                else
                    errorProvider2.Clear();
                if (textBox3.Text == "")
                {
                    errorProvider3.SetError(textBox3, "Boş Alan!");
                    errorProvider3.BlinkRate = 600;
                }
                else
                    errorProvider3.Clear();
                if (textBox4.Text == "")
                {
                    errorProvider4.SetError(textBox4, "Boş Alan!");
                    errorProvider4.BlinkRate = 600;
                }
                else
                    errorProvider4.Clear();
                if (textBox5.Text == "")
                {
                    errorProvider5.SetError(textBox5, "Boş Alan!");
                    errorProvider5.BlinkRate = 600;
                }
                else
                    errorProvider5.Clear();
                if (radioButton1.Checked == false)
                {
                    errorProvider6.SetError(radioButton1, "İşaretlenmemiş!");
                    errorProvider6.BlinkRate = 600;
                }
                if (radioButton2.Checked == false)
                {
                    errorProvider7.SetError(radioButton2, "İşaretlenmemiş!");
                    errorProvider7.BlinkRate = 600;
                }
                if (radioButton1.Checked == true)
                {
                    errorProvider6.Clear();
                    errorProvider7.Clear();
                }
                if (radioButton2.Checked == true)
                {
                    errorProvider6.Clear();
                    errorProvider7.Clear();
                }
                /* if (radioButton1.Checked == false)
                 {
                     errorProvider6.SetError(radioButton1, "İşaretlenmemiş!");
                     errorProvider6.BlinkRate = 600;
                 }
                 else
                     errorProvider6.Clear();
                 if (radioButton2.Checked == false)
                 {
                     errorProvider7.SetError(radioButton2, "İşaretlenmemiş!");
                     errorProvider7.BlinkRate = 600;
                 }
                 else
                     errorProvider7.Clear();*/


            }
            else if (radioButton1.Checked)
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "Insert Into kayit(kisim, ad, soyad, tc, tel_no, tarih, saat, cinsiyet,doktor) values('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "','" + maskedTextBox2.Text + "','" + radioButton1.Text + "','" + comboBox2.Text + "')";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                st.Clear();
                
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                maskedTextBox2.Clear();
                comboBox1.Text = null;
                comboBox2.Text = null;
                dateTimePicker1.Text = DateTime.Now.ToString();
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider3.Clear();
                errorProvider4.Clear();
                errorProvider5.Clear();
                errorProvider6.Clear();
                errorProvider7.Clear();
            }
            else if (radioButton2.Checked)
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "Insert Into kayit(kisim, ad, soyad, tc, tel_no, tarih, saat, cinsiyet,doktor) values('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "','" + maskedTextBox2.Text + "','" + radioButton2.Text + "','" + comboBox2.Text + "')";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                st.Clear();
                
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                maskedTextBox2.Clear();
                comboBox1.Text = null;
                comboBox2.Text = null;
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider3.Clear();
                errorProvider4.Clear();
                errorProvider5.Clear();
                errorProvider6.Clear();
                errorProvider7.Clear();
            }   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider8.SetError(textBox1, "Boş Alan!");
                errorProvider8.BlinkRate = 600;

            }
            else
            {
                errorProvider8.Clear();
                baglanti.Open();
                OleDbDataReader dr;
                komut.Connection = baglanti;
                komut.CommandText = "select * from kayit";
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (dr["tc"].ToString() == textBox1.Text)
                    {
                        comboBox1.Text = dr["kisim"].ToString();
                        textBox2.Text = dr["ad"].ToString();
                        textBox3.Text = dr["soyad"].ToString();
                        textBox4.Text = dr["tc"].ToString();
                        textBox5.Text = dr["tel_no"].ToString();
                        dateTimePicker1.Text = dr["tarih"].ToString();
                        maskedTextBox2.Text = dr["saat"].ToString();
                        i = 1;
                        break;
                    }
                }
                if (i == 0) MessageBox.Show("Böyle Bir Kayıt Yok.");
                {
                    textBox1.Clear();
                }
                baglanti.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Text = "Emre DURAN";
            }
            else if (comboBox1.SelectedIndex == 1)
                comboBox2.Text = "Yusuf KURT";
            else if (comboBox1.SelectedIndex == 2)
                comboBox2.Text = "Bilal Yahya ALBAYRAK";
            else if (comboBox1.SelectedIndex == 3)
                comboBox2.Text = "Onur CİVELEK";
            else if (comboBox1.SelectedIndex == 4)
                comboBox2.Text = "Kadir ALDOĞAN";
            else if (comboBox1.SelectedIndex == 5)
                comboBox2.Text = "Enes SARAÇOĞLU";
            else if (comboBox1.SelectedIndex == 6)
                comboBox2.Text = "Musab ÖGEL";
            else if (comboBox1.SelectedIndex == 7)
                comboBox2.Text = "Alican YAMAN";
            else if (comboBox1.SelectedIndex == 8)
                comboBox2.Text = "Alpay KOÇ";
            else if (comboBox1.SelectedIndex == 9)
                comboBox2.Text = "Ceyhun KEÇE";
            else if (comboBox1.SelectedIndex == 10)
                comboBox2.Text = "Ebubekir YAĞCI";
            else if (comboBox1.SelectedIndex == 11)
                comboBox2.Text = "Yaser BAYKALDI";
            else if (comboBox1.SelectedIndex == 12)
                comboBox2.Text = "Rifat BAYRAM";
            else if (comboBox1.SelectedIndex == 13)
                comboBox2.Text = "Mustafa SARAÇOĞLU";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
