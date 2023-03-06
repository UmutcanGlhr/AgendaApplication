using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace WorkApp
{
    public partial class Form1 : Form
    {

        object[] günler = new object[] { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" };
        object[] Dersler = new object[] { "Django", "Matematik", "Türkçe", "Arduino","İngilizce","Havacılık","UluslarArasıİlişkiler" };
        object[] konum = new object[] { "TheCompany(Ofis)", "Diğer"};
        object[] VeriTabani = new object[] { "berkeajanda", "umutajanda" };



        MySqlConnection con = new MySqlConnection("Server=localhost;Database=workapp;Uid=root;Pwd='mysql1234';");
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(günler);
            comboBox2.Items.AddRange(Dersler);
            comboBox3.Items.AddRange(konum);
            comboBox4.Items.AddRange(VeriTabani);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

           
            
       
            if (textBox1.Text!=""&& comboBox1.Text!=""&& comboBox2.Text!=""&textBox2.Text!=""&&comboBox3.Text!=""&&textBox3.Text!=""&&textBox4.Text!=""&&comboBox4.Text!="")
            {

                string tarih = textBox1.Text;
                string gün = comboBox1.Text;
                string ad = comboBox2.Text;
                double zaman = Convert.ToDouble(textBox2.Text);
                string konum = comboBox3.Text;
                int soru = Convert.ToInt32(textBox3.Text);
                string acıklama = textBox4.Text;
                string veriTabani = comboBox4.Text;


                con.Open();
                MySqlCommand cmd = new MySqlCommand("insert into " + veriTabani + "(tarih,gün,ders,zaman,konum,soru,acıklama) values ('" + tarih + "','" + gün + "','" + ad + "','" + zaman + "','" + konum + "','" + soru + "','" + acıklama + "');", con);


                MySqlDataReader reader = cmd.ExecuteReader();
               



                while (reader.Read())
                {

                }
                MessageBox.Show("Eklendi");
                


                reader.Close();
                cmd.Dispose();
                con.Close();

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;

                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox4.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız!!!!!!!");
            }

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text!="")
            {
                Form2 arsiv = new Form2();
                arsiv.veri(comboBox4.Text);
                arsiv.ShowDialog();
            }
            else
            {
                MessageBox.Show("Boş Bıraktınız!!!!1");
            }
            
            
        }



       

    }
}
