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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source = law.db; Version =3"))
            {
                conn.Open();
                string comText = "INSERT INTO Users (Name, pass) VALUES (@login, @pass)";
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = conn;
                command.CommandText = comText;
                command.Parameters.AddWithValue("@login", textBox1.Text);
                command.Parameters.AddWithValue("@pass", textBox2.Text);
                textBox1.Clear();
                textBox2.Clear();
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Пользователь зарегестрирован");
                conn.Open();

            }
            this.Hide();
            Form3 Form3 = new Form3();
            Form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
