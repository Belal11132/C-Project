using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progekt_Berber_belal
{
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
        }

        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\belal\OneDrive\المستندات\Berber belal.mdf"";Integrated Security=True;Connect Timeout=30");
        private void DisplayDoctor()
        {
            try
            {
                Con.Open();
                string Query = "select * from Berber";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }
        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();  
            
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text=="" || textBox2.Text== "" || comboBox1.Text== "" || textBox3.Text== "" || textBox4.Text== "")
                {
                    MessageBox.Show("Missing Information") ;
                }
                else
                {
                    Con.Open() ;
                    string query = "insert into Berber Values ('" + textBox1.Text.ToString() + "', '" + textBox2.Text + "', '" + comboBox1.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Entered Successfully");
                    DisplayDoctor();
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                Con.Close();
            }
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            DisplayDoctor();
            dataGridView1.AutoGenerateColumns = true;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            comboBox1.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Get the ID of the selected row
                    string selectedId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                    // Confirm deletion
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // Open the connection
                        Con.Open();

                        // Create the delete query
                        string query = "DELETE FROM Berber WHERE BerberId = @BerberId";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.Parameters.AddWithValue("@BerberId", selectedId);

                        // Execute the query
                        cmd.ExecuteNonQuery();

                        // Close the connection
                        Con.Close();

                        // Refresh the DataGridView
                        MessageBox.Show("Record Deleted Successfully");
                        DisplayDoctor();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Ensure the connection is closed
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
                try
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        // Get the ID of the selected row
                        string selectedId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();


                            // Open the connection
                            Con.Open();

                            // Create the delete query
                            string query = "DELETE FROM Berber WHERE BerberId = @BerberId";
                            SqlCommand cmd = new SqlCommand(query, Con);
                            cmd.Parameters.AddWithValue("@BerberId", selectedId);

                            // Execute the query
                            cmd.ExecuteNonQuery();

                            // Close the connection
                            Con.Close();

                            DisplayDoctor();
                   
                    }
                    else
                    {
                        MessageBox.Show("Please select a row to delete");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed
                    if (Con.State == ConnectionState.Open)
                    {
                        Con.Close();
                    }
                }

                try
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                    {
                        MessageBox.Show("Missing Information");
                    }
                    else
                    {
                        Con.Open();
                        string query = "insert into Berber Values ('" + textBox1.Text.ToString() + "', '" + textBox2.Text + "', '" + comboBox1.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        Con.Close();
                        DisplayDoctor();
                        MessageBox.Show("Record Entered Successfully");
                    
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Con.Close();
                }
        }

        // Method to clear the input fields
        private void ClearFields()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            comboBox1.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();


            }
            catch( Exception ex ) 
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                Con.Close();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
