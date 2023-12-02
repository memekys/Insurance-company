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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source = law.db; Version =3"))
            {
                conn.Open();
                string comText = "INSERT INTO Orders (Client, Amount, Description, Date) VALUES (@name,@amount, @descript, @date)";
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = conn;
                command.CommandText = comText;
                command.Parameters.AddWithValue("@name", textBox1.Text);
                command.Parameters.AddWithValue("@descript", textBox2.Text);
                command.Parameters.AddWithValue("@date", maskedTextBox1.Text);
                command.Parameters.AddWithValue("@amount", maskedTextBox2.Text);
                textBox1.Clear();
                textBox2.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Заказ добавлен");
                conn.Open();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
        }
    }
}
