using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Страховая_фирма
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data source=law.db; Version=3");
            conn.Open();
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM Orders";
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SQLiteDataAdapter adap = new SQLiteDataAdapter(command);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data source=law.db; Version=3");
            conn.Open();
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM Orders";
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SQLiteDataAdapter adap = new SQLiteDataAdapter(command);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
    
}
