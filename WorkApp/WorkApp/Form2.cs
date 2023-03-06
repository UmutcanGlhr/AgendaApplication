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
    public partial class Form2 : Form
    {
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=workapp;Uid=root;Pwd='mysql1234';");

        Form1 form1 = new Form1();
        string veri1;
        public Form2()
        {
            InitializeComponent();
        }

     

        private void Form2_Load(object sender, EventArgs e)
        {
            
            
            con.Open();
            MySqlDataAdapter sqlda = new MySqlDataAdapter("select * from " + veri1 + "", con);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            con.Close();
            
        }
        public void veri(string vt)
        {

            veri1 = vt;

        }
        public override string ToString()
        {
            return veri1;
        }
    }
}
