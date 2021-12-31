using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibrary;
using ClassLibrary.Interfaces;

namespace TravelExperts_Winforms
{
    /*
    * View all the products. Add or update products.
    * Author: Jaswinder Sangha
    * Date: July 2019
    */
    public partial class frmProduct : Form
    {
        ITravelAdmin _parent;

        public frmProduct()
        {
            Application.EnableVisualStyles();

            InitializeComponent();
        }

        public frmProduct(ITravelAdmin parent)
        {
            Application.EnableVisualStyles();

            InitializeComponent();
            _parent = parent;
        }

        Product prod = new Product();
        List<Product> lstProd = new List<Product>(); //create empty list

        private void frmProduct_Load(object sender, EventArgs e)
        {
            FillGrid(); // fill the grid with all the product id's and names
        }
        //Fill the grid with all the product id and product names
        private void FillGrid()
        {
            lstProd = ProductDB.GetProducts();
            dgvProducts.ColumnCount = 2;
            dgvProducts.Columns[0].Name = "Product ID";
            dgvProducts.Columns[1].Name = "Product Name";
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.Columns["Product ID"].ReadOnly = true;
            dgvProducts.Columns["Product Name"].ReadOnly = true;
            foreach (Product p in lstProd)
                dgvProducts.Rows.Add(p.ProductId, p.ProdName);
        }
        //Add the record in the products table 
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtProductName, "Product Name") == true)
            {
                bool isSimilar = false;
                lstProd = ProductDB.GetProducts();
                foreach (Product p in lstProd)
                {
                    if (txtProductName.Text == p.ProdName)//if match, then don't add the record
                    {
                        isSimilar = true;
                        break;
                    }
                }
                if (isSimilar == false)
                {
                    prod.ProdName = txtProductName.Text;

                    _parent.NewProduct = prod;

                    Close();
/*
                    ProductDB.AddProduct(prod);
                    dgvProducts.Rows.Clear();
                    FillGrid();
                    txtProductName.Text = "";
*/
                }
            }
        }
      
        // update the products table and the datagrid
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product();
            newProduct.ProdName = txtProductName.Text;
            ProductDB.UpdateProduct(prod, newProduct);
            dgvProducts.Rows.Clear();
            FillGrid();
            txtProductName.Text = "";
        }

        //Select the product name and enter the value to text box so that Agent can change it
        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvProducts.Rows[e.RowIndex];
                prod.ProductId = Convert.ToInt32(row.Cells["Product ID"].Value);
                prod.ProdName = row.Cells["Product Name"].Value.ToString();
                txtProductName.Text = prod.ProdName;
            }
        }
    }
}
