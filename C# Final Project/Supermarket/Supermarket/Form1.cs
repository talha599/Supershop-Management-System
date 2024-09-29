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


namespace Supermarket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static String sellername = "";


        SqlConnection Con = new SqlConnection(@"Data Source=TALHA;Initial Catalog=smarketdb;Integrated Security=True;TrustServerCertificate=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            PassTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Enter the Username & Password");
            }
            else
            {
                if (RoleCb.SelectedIndex > -1)
                {


                    if (RoleCb.SelectedItem.ToString() == "ADMIN")
                    {
                        if (UnameTb.Text == "Admin" && PassTb.Text == "Admin")
                        {
                            ProductForm prod = new ProductForm();
                            prod.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If you are the Admin, Enter the Correct Username & Password");

                        }
                    }
                    else
                    {
                        // MessageBox.Show("You are in the Seller section");
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter ("Select count(8) from SellerTbl where SellerName='"+ UnameTb.Text+ "' and SellerPass= '" + PassTb.Text + "'",Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() =="1")
                        {
                            sellername = UnameTb.Text;
                            SellerForm sell = new SellerForm();
                            sell.Show();
                            this.Hide();
                            Con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong UserName or Password");
                        }
                        Con.Close();


                    }

                }
                else
                {
                    MessageBox.Show("Select a Role");
                }
            }
        }
        private void RoleCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void RoleCb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

    }
}
