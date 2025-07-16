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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
            
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\belal\OneDrive\المستندات\Berber belal.mdf"";Integrated Security=True;Connect Timeout=30");
        private void DisplayPatient()
        {
            try
            {
                Con.Open();
                string Query = "select * from  Patient";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                Con.Close();
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
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox4.Text == " " || textBox5.Text == " " || comboBox1.Text==" " ||comboBox2.Text==" " ||textBox6.Text==" ")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "insert into Patient Values ('" + textBox1.Text.ToString() + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "' , '"+comboBox1.Text+"' , '"+comboBox2.Text+"' , '"+textBox6.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Entered Successfully");
                    DisplayPatient();
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

        private void Patient_Load(object sender, EventArgs e)
        {
            DisplayPatient();
        }

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    // Seçilen satırın ID'sini al
                    string selectedId = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();

                    // Veritabanı bağlantısını aç
                    Con.Open();

                    // Seçili satırı silme sorgusu
                    string deleteQuery = "DELETE FROM Patient WHERE MId = @MId";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, Con);
                    deleteCmd.Parameters.AddWithValue("@MId", selectedId);
                    deleteCmd.ExecuteNonQuery();

                    // Bağlantıyı kapat
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("Please select a row to delete");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                // Bağlantının kapalı olduğundan emin ol
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }

            // Yeni veriyi ekleme işlemi
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(comboBox2.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Missing Information");
                    return;
                }

                // Veritabanı bağlantısını aç
                Con.Open();

                // Yeni veri ekleme sorgusu@Saç Kesimi 
                string insertQuery = "INSERT INTO Patient (MId, MAdı, MADDR, MYaşı, MTelifonu, MCinsiyet, Saç_Kesimi_türü, Randevu_günü) VALUES (@MId, @MAdı, @MADDR, @MYaşı, @MTelifonu, @MCinsiyet, @Saç_Kesimi_türü, @Randevu_günü)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, Con);
                insertCmd.Parameters.AddWithValue("@MId", textBox1.Text);
                insertCmd.Parameters.AddWithValue("@MAdı", textBox2.Text);
                insertCmd.Parameters.AddWithValue("@MADDR", textBox3.Text);
                insertCmd.Parameters.AddWithValue("@MYaşı", textBox4.Text);
                insertCmd.Parameters.AddWithValue("@MTelifonu", textBox5.Text);
                insertCmd.Parameters.AddWithValue("@MCinsiyet", comboBox1.Text);
                insertCmd.Parameters.AddWithValue("@Saç_Kesimi_türü", comboBox2.Text);
                insertCmd.Parameters.AddWithValue("@Randevu_günü", textBox6.Text);
                insertCmd.ExecuteNonQuery();

                // Bağlantıyı kapat
                Con.Close();

                // DataGridView'i güncelle
                DisplayPatient();

                // Kullanıcıya geri bildirimde bulun
                MessageBox.Show("Record Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Bağlantının kapalı olduğundan emin ol
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }



        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    // Get the ID of the selected row
                    string selectedId = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();

                    // Confirm deletion
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // Open the connection
                        Con.Open();

                        // Create the delete query
                        string query = "DELETE FROM Patient WHERE MId = @MId";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.Parameters.AddWithValue("@MId", selectedId);

                        // Execute the query
                        cmd.ExecuteNonQuery();

                        // Close the connection
                        Con.Close();

                        // Refresh the DataGridView
                        MessageBox.Show("Record Deleted Successfully");
                        DisplayPatient();
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

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            comboBox1.Text = " ";
            comboBox2.Text = " ";
            textBox6.Text = " ";
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();   
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                textBox1.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
                comboBox1.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
                comboBox2.Text = dataGridView2.SelectedRows[0].Cells[6].Value.ToString();
                textBox6.Text = dataGridView2.SelectedRows[0].Cells[7].Value.ToString();


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
    }
}
