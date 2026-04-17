using MySql.Data.MySqlClient;
using System.Data;  

namespace CRUD_C_
{
    public partial class Form1 : Form

    {
        string admin = "administrator";
        string personStaff = "staff";
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Exit?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }

            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {

                button4.Enabled = true;

            }

            else
            {
                button4.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {

                button4.Enabled = true;

            }

            else
            {
                button4.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //administrator login

                string connstring = "Server=localhost; database=practicedb; Uid=root; Pwd=NewGenericPassword123;";
                MySqlConnection connection = new MySqlConnection(connstring);

                string sqlcommand = "SELECT * FROM midtermdb WHERE username = @username AND password = @password AND usertype = @usertype";
                MySqlCommand command = new MySqlCommand(sqlcommand, connection);

                command.Parameters.AddWithValue("@username", textBox1.Text);
                command.Parameters.AddWithValue("@password", textBox2.Text);
                command.Parameters.AddWithValue("@usertype", admin);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();


                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();






                    return;
                }





                //staff login
                string connstring2 = "Server=localhost; database=practicedb; Uid=root; Pwd=NewGenericPassword123;";
                MySqlConnection connection2 = new MySqlConnection(connstring2);

                string sqlcommand2 = "SELECT * FROM midtermdb WHERE username = @username AND password = @password AND usertype = @usertype";
                MySqlCommand command2 = new MySqlCommand(sqlcommand2, connection2);


                command2.Parameters.AddWithValue("@username", textBox1.Text);
                command2.Parameters.AddWithValue("@password", textBox2.Text);
                command2.Parameters.AddWithValue("@usertype", personStaff);

                MySqlDataAdapter adapter2 = new MySqlDataAdapter(command2);
                DataTable table2 = new DataTable();

                adapter2.Fill(table2);

                if (table2.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 1. Create ONE instance of the form
                    Form3 form3 = new Form3();

                    // 2. Set the label text (Make sure label3 Modifiers is set to Public in Form3 design!)
                    // Also, verify if you meant 'table' or 'table2' here


                    // 3. Show the form
                    form3.Show();

                    // 4. Hide the current login form
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (MySqlException ex)
            {
                // This will tell you EXACTLY why the connection failed (e.g., wrong password or server down)
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}
