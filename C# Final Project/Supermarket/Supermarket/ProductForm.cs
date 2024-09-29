using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Supermarket
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=TALHA;Initial Catalog=smarketdb;Integrated Security=True;TrustServerCertificate=True");

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fillcombo()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CatName from CategoryTbl", Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(rdr);
            CatCb.ValueMember = "CatName";
            CatCb.DataSource = dt;
            Con.Close();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            fillcombo();
            poupulate(); // Populate DataGridView when the form loads
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "INSERT INTO ProductTbl (ProdId, ProdName, ProdQty, ProdPrice, ProdCat) " +
                               "VALUES (@ProdId, @ProdName, @ProdQty, @ProdPrice, @ProdCat)";
                SqlCommand cmd = new SqlCommand(query, Con);

                // Adding parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@ProdId", ProdId.Text);
                cmd.Parameters.AddWithValue("@ProdName", ProdName.Text);
                cmd.Parameters.AddWithValue("@ProdQty", ProdQty.Text);
                cmd.Parameters.AddWithValue("@ProdPrice", ProdPrice.Text);
                cmd.Parameters.AddWithValue("@ProdCat", CatCb.SelectedValue.ToString());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Added Successfully");

                Con.Close();
                poupulate(); // Repopulate DataGridView after insertion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void poupulate()
        {
            Con.Open();
            string query = "SELECT * FROM ProductTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV.DataSource = ds.Tables[0]; // Binding DataGridView to DataSet
            Con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex >= 0) // Ensure the clicked row index is valid
                {
                    DataGridViewRow row = ProdDGV.Rows[e.RowIndex]; // Get the clicked row
                    ProdId.Text = row.Cells[0].Value.ToString();
                    ProdName.Text = row.Cells[1].Value.ToString();
                    ProdQty.Text = row.Cells[2].Value.ToString();
                    ProdPrice.Text = row.Cells[3].Value.ToString();
                    CatCb.SelectedValue = row.Cells[4].Value.ToString(); // Assuming CatCb is a ComboBox for Category

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                if (ProdId.Text == "")
                {
                    MessageBox.Show("Select The Product to Delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from ProductTbl where ProdId= " + ProdId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Successfully");
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
                if (ProdId.Text == "" || ProdName.Text == "" || ProdQty.Text == "" || ProdPrice.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update ProductTbl set ProdName='" + ProdName.Text + "',ProdQty='" + ProdQty.Text + "',ProdPrice='" + ProdPrice.Text + "'where ProdId=" + ProdId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Successfully Updated");
                    Con.Close();
                    poupulate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                SellerForm seller = new SellerForm();
                seller.Show();
                this.Hide();
            }
        }

        private void SearchCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Con.Open();
            String query = "Select * From ProductTbl where ProdCat= '" + SearchCb.SelectedValue.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Login = new Form1();
            Login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SellingForm Selling = new SellingForm();
            Selling.Show();
        }
    }
}
