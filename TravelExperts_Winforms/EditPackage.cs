using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using ClassLibrary.Interfaces;

namespace TravelExperts_Winforms
{
    /// <summary>
    /// Windows form to edit existing Package from database
    /// Created by Darren Uong
    /// </summary>
    public partial class EditPackage : Form
    {
        int index;
        List<Package> list = new List<Package>();
        ITravelAdmin _parent;

        public EditPackage()
        {
            Application.EnableVisualStyles();

            InitializeComponent();
        }

        public EditPackage(ITravelAdmin parent)
        {
            Application.EnableVisualStyles();

            InitializeComponent();
            _parent = parent;
        }

        private void EditPackage_Load(object sender, EventArgs e)
        {
            //Initialize form properties
            index = 0;

            list = PackagesDB.GetPackageList();
//            list = DummyData.GetPackages();

            //Display current package
            DisplayPackage();

            //Get list of packages
            GetPackages();

        }

        public void DisplayPackage()
        {
            txtPackageId.Text = list[index].PackageId.ToString();
            txtPkgName.Text = list[index].PkgName.ToString();
            txtPkgBasePrice.Text = list[index].PkgBasePrice.ToString();
    
            if (list[index].PkgStartDate == null)
            {
                dtpPkgStartDate.Format = DateTimePickerFormat.Custom;
                dtpPkgStartDate.CustomFormat = " ";

            }
            else dtpPkgStartDate.Text = list[index].PkgStartDate.ToString();

            if (list[index].PkgEndDate == null)
            {
                dtpPkgEndDate.Format = DateTimePickerFormat.Custom;
                dtpPkgEndDate.CustomFormat = " ";

            }
            else dtpPkgEndDate.Text = list[index].PkgEndDate.ToString();

            if (list[index].PkgDesc == null)
            {
                txtPkgDesc.Text = "";
            }
            else txtPkgDesc.Text = list[index].PkgDesc.ToString();

            if (list[index].PkgAgencyCommission == null)
            {
                txtPkgAgencyCommission.Text = "";
            }
            else txtPkgAgencyCommission.Text = list[index].PkgAgencyCommission.ToString();

           
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                index = 0;
            }
            else
            {
                index -= 1;
            }

            DisplayPackage();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (index == list.Count() - 1)
            {
                index = list.Count() - 1;
            }
            else
            {
                index += 1;
            }

            DisplayPackage();
        }

        private void dgvPackages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgvPackages.CurrentCell.RowIndex;
            int pkgID = Convert.ToInt32(dgvPackages.Rows[rowIndex].Cells[0].Value);

            DisplayClickedPackage(pkgID);

        }

        public void GetPackages()
        {

            //Format datagridview
            dgvPackages.Rows.Clear();
            dgvPackages.ColumnCount = 2;
            dgvPackages.ColumnHeadersVisible = true;
            dgvPackages.Columns[0].Name = "Package ID";
            dgvPackages.Columns[1].Name = "Package Name";
            dgvPackages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPackages.Columns["Package ID"].ReadOnly = true;
            dgvPackages.Columns["Package Name"].ReadOnly = true;



            //Display package ID and name 
            foreach (Package row in list)
            {
                int col1 = row.PackageId;
                string col2 = row.PkgName;
                dgvPackages.Rows.Add(col1, col2);
            }

        }

        public void DisplayClickedPackage(int pkgID)
        {
            Package cellPackage = PackagesDB.GetPackage(pkgID);

            txtPackageId.Text = cellPackage.PackageId.ToString();
            txtPkgName.Text = cellPackage.PkgName;
            dtpPkgStartDate.Text = cellPackage.PkgStartDate.ToString();
            dtpPkgEndDate.Text = cellPackage.PkgEndDate.ToString();
            txtPkgDesc.Text = cellPackage.PkgDesc.ToString();
            txtPkgBasePrice.Text = cellPackage.PkgBasePrice.ToString();
            txtPkgAgencyCommission.Text = cellPackage.PkgAgencyCommission.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Package oldPackage = list[index]; //Get old customer information, stored in list.

            Package newPackage = new Package();



            if (Validator.IsPresent(txtPkgName) && Validator.IsPresent(txtPkgBasePrice) && Validator.IsDecimal(txtPkgBasePrice) && Validator.CheckCommission(txtPkgAgencyCommission, txtPkgBasePrice)
               && Validator.CheckDates(dtpPkgStartDate, dtpPkgEndDate))
            {
                newPackage.PkgName = txtPkgName.Text;
                newPackage.PkgBasePrice = Convert.ToDecimal(txtPkgBasePrice.Text);

                newPackage.PkgDesc = txtPkgDesc.Text;

                if (dtpPkgStartDate.CustomFormat == " ")
                {
                    newPackage.PkgStartDate = null;
                }
                else newPackage.PkgStartDate = dtpPkgStartDate.Value;

                if (dtpPkgEndDate.CustomFormat== " ")
                {
                    newPackage.PkgEndDate = null;
                }
                else newPackage.PkgEndDate = dtpPkgEndDate.Value;

                if (txtPkgAgencyCommission.Text == "")
                {
                    newPackage.PkgAgencyCommission = null;
                }
                else newPackage.PkgAgencyCommission = Convert.ToDecimal(txtPkgAgencyCommission.Text);
                bool updateStatus = PackagesDB.UpdatePackage(oldPackage, newPackage);

                if (updateStatus)
                {
                    list = PackagesDB.GetPackageList(); //refresh list
                    GetPackages();
                }

            }
        }
        private void btnClearDates_Click(object sender, EventArgs e)
        {
            dtpPkgStartDate.Format = DateTimePickerFormat.Custom;
            dtpPkgStartDate.CustomFormat = " ";
            dtpPkgStartDate.Text = "";


            dtpPkgEndDate.Format = DateTimePickerFormat.Custom;
            dtpPkgEndDate.CustomFormat = " ";
            dtpPkgEndDate.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtpPkgStartDate.CustomFormat = "MMM dd yyyy";
            dtpPkgEndDate.CustomFormat = "MMM dd yyyy";
        }
    }
}
