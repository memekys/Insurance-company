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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source = law.db; Version =3"))
            {
                conn.Open();
                string comText = "SELECT * FROM USERS WHERE Name=@login AND pass=@pass";
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = conn;
                command.CommandText = comText;
                command.Parameters.AddWithValue("@login", textBox1.Text);
                command.Parameters.AddWithValue("@pass", textBox2.Text);
                command.ExecuteNonQuery();
                DataTable a = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(a);
                if (a.Rows.Count > 0)
                {
                    this.Hide();
                    Form3 form3 = new Form3();
                    form3.Show();


                }
                else
                {
                    MessageBox.Show("не правильно введен логин или пароль");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
