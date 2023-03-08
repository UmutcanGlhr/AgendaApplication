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
    public partial class Form3 : Form
    {
        object[] VeriTabani = new object[] { "berkeajanda", "umutajanda" };
        int soru;
        int saat;

        MySqlConnection con = new MySqlConnection("Server=localhost;Database=workapp;Uid=root;Pwd='mysql1234';");
        public Form3()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(VeriTabani);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select SUM(soru) from " + comboBox1.Text + "", con);
            MySqlCommand cmd1 = new MySqlCommand("Select SUM(zaman) from " + comboBox1.Text + "", con);

            int SoruToplam = Convert.ToInt32(cmd.ExecuteScalar());
            int ZamanToplam = Convert.ToInt32(cmd1.ExecuteScalar());

            if (comboBox1.Text!="")
            {
                int soru = Convert.ToInt32(textBox1.Text);
                int zaman = Convert.ToInt32(textBox2.Text);
                if (soru > SoruToplam && zaman > ZamanToplam)
                {
                    MessageBox.Show("çok iyi");
                }
                else if (soru <= SoruToplam && zaman>ZamanToplam)
                {
                    MessageBox.Show("ideal");
                }
                else if (soru > SoruToplam && zaman <= ZamanToplam)
                {
                    MessageBox.Show("ideal");
                }
                else
                {
                    MessageBox.Show("yakışmadı");
                }

            }
            else
            {
                MessageBox.Show("Boş Alan!!!!!!!!");
            }

            con.Close();

        }
    }
}
