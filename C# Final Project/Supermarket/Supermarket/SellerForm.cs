using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace Supermarket
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=TALHA;Initial Catalog=smarketdb;Integrated Security=True;TrustServerCertificate=True");
        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                ProductForm prod = new ProductForm();
                prod.Show();
                this.Hide();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "INSERT INTO SellerTbl (SellerId, SellerName, SellerAge, SellerPhone, SellerPassword) " +
                               "VALUES (@SellerId, @SellerName, @SellerAge, @SellerPhone, @SellerPassword)";
                SqlCommand cmd = new SqlCommand(query, Con);

                // Adding parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@SellerId", SellerId.Text);
                cmd.Parameters.AddWithValue("@SellerName", SellerName.Text);
                cmd.Parameters.AddWithValue("@SellerAge", SellerAge.Text);
                cmd.Parameters.AddWithValue("@SellerPhone", SellerPhone.Text);
                cmd.Parameters.AddWithValue("@SellerPassword", SellerPassword.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Seller Added Successfully");

                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void poupulate()
        {
            Con.Open();
            string query = "SELECT * FROM SellerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerDGV.DataSource = ds.Tables[0]; // Binding DataGridView to DataSet
            Con.Close();
        }
        private void CategoryForm_Load(object sender, EventArgs e)
        {
            poupulate();
        }

        private void SellerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = SellerDGV.Rows[e.RowIndex]; 
                SellerId.Text = row.Cells[0].Value.ToString();
                SellerName.Text = row.Cells[1].Value.ToString();
                SellerAge.Text = row.Cells[2].Value.ToString();
                SellerPhone.Text = row.Cells[3].Value.ToString();
                SellerPassword.Text = row.Cells[4].Value.ToString();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (SellerId.Text == "")
                {
                    MessageBox.Show("Select The Seller to Delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from SellerTbl where SellerId= " + SellerId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Deleted Successfully");
                    Con.Close();
                    poupulate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (SellerId.Text == "" || SellerName.Text == "" || SellerAge.Text == "" || SellerPhone.Text == "" || SellerPassword.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update SellerTbl set SellerName='" + SellerName.Text + "',SellerAge='" + SellerAge.Text + "',SellerPhone='" + SellerPhone.Text + "',SellerPassword='" + SellerPassword.Text + "'  where SellerId=" + SellerId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Successfully Updated");
                    Con.Close();
                    poupulate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Login = new Form1();
            Login.Show();
        }
    }
}
