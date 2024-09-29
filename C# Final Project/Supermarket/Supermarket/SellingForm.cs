using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class SellingForm : Form
    {
        // Constructor
        public SellingForm()
        {
            InitializeComponent();
        }

        // SqlConnection string to connect to the database
        SqlConnection Con = new SqlConnection(@"Data Source=TALHA;Initial Catalog=smarketdb;Integrated Security=True;TrustServerCertificate=True");

        // SellingForm Load event
        private void SellingForm_Load(object sender, EventArgs e)
        {
            populate();       // Load product data
            populatebills();  // Load bill data
            fillcombo();
            SellerNamelbl.Text = Form1.sellername;
        }

        // Method to populate the DataGridView with data from the ProductTbl
        private void populate()
        {
            try
            {
                Con.Open();
                string query = "SELECT ProdName, ProdQty FROM ProductTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                ProdDGV1.DataSource = ds.Tables[0]; // Binding DataGridView to DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Show message in case of error
            }
            finally
            {
                Con.Close(); // Ensure the connection is closed
            }
        }

        // Method to populate the DataGridView with data from the BillTbl
        private void populatebills()
        {
            try
            {
                Con.Open();
                string query = "SELECT * FROM BillTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                BillsDGV.DataSource = ds.Tables[0]; // Binding DataGridView to DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Show message in case of error
            }
            finally
            {
                Con.Close(); // Ensure the connection is closed
            }
        }

        private void ProdDGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ProdDGV1.Rows[e.RowIndex];

                ProdName.Text = row.Cells[0].Value.ToString();
                ProdPrice.Text = row.Cells[1].Value.ToString();
    
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToString();
        }

        int Grdtotal = 0, n = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (ProdName.Text == "" || ProdQty.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                int total = Convert.ToInt32(ProdPrice.Text) * Convert.ToInt32(ProdQty.Text);

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(OrderedDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ProdName.Text;
                newRow.Cells[2].Value = ProdPrice.Text;
                newRow.Cells[3].Value = ProdQty.Text;
                newRow.Cells[4].Value = total; // Calculated total
                OrderedDGV.Rows.Add(newRow);
                n++;
                Grdtotal += total;
                Amtlbl.Text = "" + Grdtotal;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (BillId.Text == "")
            {
                MessageBox.Show("Missing Bill Id");
            }
            else
            {
                try
                {
                    Con.Open();
                    // Corrected SQL query to match the column names from the table structure
                    string query = "INSERT INTO BillTbl (BillId, SellerName, BillDate, TotAmt) " +
                                   "VALUES (@BillId, @SellerName, @BillDate, @TotAmt)";
                    SqlCommand cmd = new SqlCommand(query, Con);

                    // Adding parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@BillId", BillId.Text);  // BillId from form
                    cmd.Parameters.AddWithValue("@SellerName", SellerNamelbl.Text);  // SellerName from form
                    cmd.Parameters.AddWithValue("@BillDate", Datelbl.Text);  // BillDate from form
                    cmd.Parameters.AddWithValue("@TotAmt", Amtlbl.Text);  // Total amount from form

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order Added Successfully");

                    Con.Close();
                    populatebills(); // Repopulate DataGridView after insertion
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("FriEndsSUPERmarket", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(230));
            e.Graphics.DrawString("Bill ID: " + BillsDGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 70));
            e.Graphics.DrawString("Seller Name: " + BillsDGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 100));
            e.Graphics.DrawString("Date: " + BillsDGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 130));
            e.Graphics.DrawString("Total Amount: " + BillsDGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 160));
            e.Graphics.DrawString("Thank You!", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(230,230));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void SearchCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Con.Open();
            String query = "Select ProdName, ProdQty FROM ProductTbl where ProdCat= '" + SearchCb.SelectedValue.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BillsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void fillcombo()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CatName from CategoryTbl", Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(rdr);
            //CatCb.ValueMember = "CatName";
           // CatCb.DataSource = dt;
            Con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Login = new Form1();
            Login.Show ();
        }

        private void BillsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
