using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CRUD_C_
{
    public partial class Form4 : Form
    {

        Form2 form2;
        public Form4(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Exit?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                this.CenterToScreen();

            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Add("Accountancy");
            comboBox1.Items.Add("Financial Management");
            comboBox1.Items.Add("Human Resource Management");
            comboBox1.Items.Add("Marketing Management");
            comboBox1.Items.Add("Office Administration");
            comboBox1.Items.Add("Information Systems");
            comboBox1.Items.Add("Information Technology");
            comboBox2.Items.Add("1st Year");
            comboBox2.Items.Add("2nd Year");
            comboBox2.Items.Add("3rd Year");
            comboBox2.Items.Add("4th Year");
        }

        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == ""
                    || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill all required fields!");
                    return;
                }

                string connectionString = "Server=localhost;user id=root;password=NewGenericPassword123;database=practicedb;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "INSERT INTO student_info (`Student No`, `Student Name`, `Year Level`, Course, Email) " +
                        "VALUES (@no, @name, @yearlevel, @course, @email)";

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@no", textBox1.Text);
                    cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@yearlevel", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@course", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@email", textBox4.Text);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Student Added Successfully!");
                    Clear();
                    form2.LoadDataGridView();



                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();

           
        }
    }
}
