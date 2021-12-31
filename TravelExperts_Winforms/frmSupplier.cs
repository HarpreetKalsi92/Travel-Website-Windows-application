using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibrary;
using ClassLibrary.Interfaces;

namespace TravelExperts_Winforms
{

    /*
    * View all the suppliers. Add or update suppliers.
    * Author: Jaswinder Sangha
    * Date: July 2019
    */
    public partial class frmSupplier : Form
    {
        ITravelAdmin _parent;

        public frmSupplier()
        {
            Application.EnableVisualStyles();

            InitializeComponent();
        }
        public frmSupplier(ITravelAdmin parent)
        {
            Application.EnableVisualStyles();

            InitializeComponent();

            _parent = parent;
        }

        Supplier sup = new Supplier();
        List<Supplier> lstSup = new List<Supplier>(); //create empty list
        private void frmSupplier_Load(object sender, EventArgs e)
        {
            FillGrid(); // fill the grid with all the supplier id's and names
        }

        //Fill the grid with all the supplier id and supplier names
        private void FillGrid()
        {
            lstSup = SuppliersDB.GetSuppliers();
            dgvSuppliers.ColumnCount = 2;
            dgvSuppliers.Columns[0].Name = "Supplier ID";
            dgvSuppliers.Columns[1].Name = "Supplier Name";
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliers.Columns["Supplier ID"].ReadOnly = true;
            dgvSuppliers.Columns["Supplier Name"].ReadOnly = true;
            this.ActiveControl = txtSupplierId;
            foreach (Supplier s in lstSup)
                dgvSuppliers.Rows.Add(s.SupplierId, s.SupName);
        }

        private void dgvSuppliers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSuppliers.Rows[e.RowIndex];
                sup.SupplierId = Convert.ToInt32(row.Cells["Supplier ID"].Value);
                sup.SupName = row.Cells["Supplier Name"].Value.ToString();
                txtSupplierId.Text = sup.SupplierId.ToString();
                txtSupplierName.Text = sup.SupName;
            }
        }
        //Add the record in the suppliers table 
        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            if ((Validator.IsPresent(txtSupplierId, "Supplier Id") == true) &&
                 (Validator.IsPresent(txtSupplierName, "Supplier Name") == true))
            {
                bool isSimilar = false;
                lstSup = SuppliersDB.GetSuppliers();
                foreach (Supplier s in lstSup)
                {
                    if (Convert.ToInt32(txtSupplierId.Text) == s.SupplierId)//if not equal then add the record
                    {
                        isSimilar = true;
                        break;
                    }
                    if (txtSupplierName.Text == s.SupName)//if not equal then add the record
                    {
                        isSimilar = true;
                        break;
                    }
                }
                if (isSimilar == false)
                {
                    sup.SupplierId = Convert.ToInt32(txtSupplierId.Text);
                    sup.SupName = txtSupplierName.Text;

                    _parent.NewSupplier = sup;
                    Close();
/*
                    SuppliersDB.AddSupplier(sup);
                    dgvSuppliers.Rows.Clear();
                    FillGrid();
                    txtSupplierId.Text = "";
                    txtSupplierName.Text = "";
*/
                }
            }
        }
        // update the supplier table and the datagrid
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            bool isSimilar = true;
            lstSup = SuppliersDB.GetSuppliers();
            foreach (Supplier s in lstSup)
            {
                if (txtSupplierName.Text == s.SupName)//if not equal then add the record
                {
                    isSimilar = false;
                    break;
                }
            }
            if (isSimilar == true)
            {
                Supplier newSupplier = new Supplier();
                newSupplier.SupplierId = Convert.ToInt32(txtSupplierId.Text);
                newSupplier.SupName = txtSupplierName.Text;
                SuppliersDB.UpdateSupplier(sup, newSupplier);
                dgvSuppliers.Rows.Clear();
                FillGrid();             
                txtSupplierId.Text = "";
                txtSupplierName.Text = "";
            }
        }
    }
}
