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
    public partial class AddPackage : Form
    {
        /// <summary>
        /// Windows form to Add package to database
        /// Created by Darren Uong
        /// </summary>
        ITravelAdmin _parent;

        public AddPackage()
        {
            Application.EnableVisualStyles();

            InitializeComponent();
        }

        public AddPackage(ITravelAdmin parent)
        {
            Application.EnableVisualStyles();

            InitializeComponent();

            _parent = parent;
        }

        private void AddPackage_Load(object sender, EventArgs e)
        {
            List<Package> list = new List<Package>();
            list = PackagesDB.GetPackageList();


            //Get list of packages
            GetPackages();
        }

        public void GetPackages()
        {
            //Initalize list to store packages

            List<Package> packageList = PackagesDB.GetPackageList();

            //Format datagridview
            dgvPackages.Rows.Clear();
            dgvPackages.ColumnCount = 2;
            dgvPackages.ColumnHeadersVisible = true;
            dgvPackages.Columns[0].Name = "Package ID";
            dgvPackages.Columns[1].Name = "Package Name";
            dgvPackages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPackages.Columns["Package ID"].ReadOnly = true;
            dgvPackages.Columns["Package Name"].ReadOnly = true;



            foreach (Package row in packageList)
            {
                int col1 = row.PackageId;
                string col2 = row.PkgName;
                dgvPackages.Rows.Add(col1, col2);
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Create package object on click
            Package newPackage = new Package();

            //Validate form fields
            

            if (Validator.IsPresent(txtPkgName) && Validator.IsPresent(txtPkgBasePrice) && Validator.IsDecimal(txtPkgBasePrice) && Validator.CheckCommission(txtPkgAgencyCommission, txtPkgBasePrice) 
                && Validator.CheckDates(dtpPkgStartDate, dtpPkgEndDate))
            {
                newPackage.PkgName = txtPkgName.Text;
                newPackage.PkgBasePrice = Convert.ToDecimal(txtPkgBasePrice.Text);

                newPackage.PkgDesc = txtPkgDesc.Text;

                if (dtpPkgStartDate.Text == " ")
                {
                    newPackage.PkgStartDate = null;
                }
                else newPackage.PkgStartDate = DateTime.Parse(dtpPkgStartDate.Text);

                if (dtpPkgEndDate.Text == " ")
                {
                    newPackage.PkgEndDate = null;
                }
                else newPackage.PkgEndDate = DateTime.Parse(dtpPkgEndDate.Text);

                if (txtPkgAgencyCommission.Text == "")
                {
                    newPackage.PkgAgencyCommission = null;
                }
                else newPackage.PkgAgencyCommission = Convert.ToDecimal(txtPkgAgencyCommission.Text);

                //Store new object in _parent property
                _parent.NewPackage = newPackage;

                this.Close();

            }



            
 
        }

        private void dgvPackages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            dtpPkgStartDate.Format = DateTimePickerFormat.Custom;
            dtpPkgStartDate.CustomFormat = " ";
            dtpPkgStartDate.Text = "";
            dtpPkgEndDate.Format = DateTimePickerFormat.Custom;
            dtpPkgEndDate.CustomFormat = " ";
            dtpPkgEndDate.Text = "";

        }

        private void dtpPkgStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpPkgEndDate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtpPkgStartDate.CustomFormat = "MMM dd yyyy";
            dtpPkgEndDate.CustomFormat = "MMM dd yyyy";

        }
    }
}
