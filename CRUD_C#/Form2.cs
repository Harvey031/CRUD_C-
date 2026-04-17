using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRUD_C_
{
    public partial class Form2 : Form
    {
       
        DataTable dt = new DataTable();

        public Form2()
        {
            InitializeComponent();
            LoadDataGridView();
        }

     
        private void LoadDataGridView()
        {
            try
            {
                string connectionString = "Server=localhost;user id=root;password=NewGenericPassword123;database=practicedb;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM midtermdb";
                    

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                    dt.Clear(); 
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;

            dv.RowFilter = $"username LIKE '%{textBox1.Text}%'";

            dataGridView1.DataSource = dv;
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to Exit?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
        private void button5_Click(object sender, EventArgs e)
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

       
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      
        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Log Out Successfully!");
            this.Close();

            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}