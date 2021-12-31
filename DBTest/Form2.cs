using ClassLibrary;
using ClassLibrary.Enums;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DBTest
{
    /// <summary>
    /// Class to test transaction class
    /// Author: James Defant
    /// Date: Aug 5 2019
    /// </summary>
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        #region Product_Supplier
        private void uxAddNewProd_NewSupp_Click(object sender, EventArgs e)
        {
            Product p = new Product()
            {
                ProdName = "Big Turk Chocolate Bar"
            };

            Supplier s = new Supplier()
            {
                SupplierId = 2,
                SupName = "MARYS CORNER STORE"
            };

            if (Transactions.Product_SupplierTransaction(p, s, Prod_SuppTransactionType.NewProduct_NewSupplier))
                Console.WriteLine("New Product & New Supplier written to database");

        }

        private void uxAddNewProd_OldSupp_Click(object sender, EventArgs e)
        {
            Product p = new Product()
            {
                ProdName = "Milka Alpenmilch"
            };

            Supplier s = new Supplier()
            {
                SupplierId = 2,
                SupName = "MARYS CORNER STORE"
            };

            if (Transactions.Product_SupplierTransaction(p, s, Prod_SuppTransactionType.NewProduct_OldSupplier))
                Console.WriteLine("New Product & Old Supplier written to database");
        }

        private void uxOldProd_NewSupp_Click(object sender, EventArgs e)
        {
            Product p = new Product()
            {
                ProductId = 18,
                ProdName = "Milka Alpenmilch"
            };

            Supplier s = new Supplier()
            {
                SupplierId = 3,
                SupName = "7-11"
            };

            if (Transactions.Product_SupplierTransaction(p, s, Prod_SuppTransactionType.OldProduct_NewSupplier))
                Console.WriteLine("Old Product & New Supplier written to database");

        }

        private void uxAddOldProd_OldSupp_Click(object sender, EventArgs e)
        {
            Product p = new Product()
            {
                ProductId = 18,
                ProdName = "Milka Alpenmilch"
            };

            Supplier s = new Supplier()
            {
                SupplierId = 3,
                SupName = "7-11"
            };

            if (Transactions.Product_SupplierTransaction(p, s, Prod_SuppTransactionType.OldProduct_OldSupplier))
                Console.WriteLine("Old Product & Old Supplier written to database");

        }

        #endregion

        #region Package_Product_Supplier

        private void uxAddNewPkg_NewProd_NewSupp_Click(object sender, EventArgs e)
        {
            Package pkg = new Package()
            {
                PkgName = "S American Tour",
                PkgDesc = "South America at it's best",
                PkgStartDate = new DateTime(2019, 10, 21),
                PkgEndDate = new DateTime(2019, 10, 30),
                PkgBasePrice = 4000m,
                PkgAgencyCommission = 400m
            };

            Product p = new Product()
            {
                ProdName = "Lays Potato Chips"
            };

            Supplier s = new Supplier()
            {
                SupplierId = 5,
                SupName = "SAFEWAY SUPERMARKET"
            };

            if (Transactions.Pkg_Prod_SuppTransaction(pkg, p, s, Pkg_Prod_SuppTransactionType.NewPkg_NewProd_NewSupp))
                Console.WriteLine("New Package, New Product & New Supplier written to database");

        }

        private void uxAddNewPkg_NewProd_OldSupp_Click(object sender, EventArgs e)
        {
            Package pkg = new Package()
            {
                PkgName = "West Indies",
                PkgDesc = "Central America like you've never seen before",
                PkgStartDate = new DateTime(2019, 5, 21),
                PkgEndDate = new DateTime(2019, 5, 30),
                PkgBasePrice = 2000m,
                PkgAgencyCommission = 200m
            };

            Product p = new Product()
            {
                ProdName = "Doritos Potato Chips"
            };

            Supplier s = new Supplier()
            {
                SupplierId = 5,
                SupName = "SAFEWAY SUPERMARKET"
            };

            if (Transactions.Pkg_Prod_SuppTransaction(pkg, p, s, Pkg_Prod_SuppTransactionType.NewPkg_NewProd_OldSupp))
                Console.WriteLine("New Package, New Product & Old Supplier written to database");

        }

        private void uxAddNewPkg_OldProd_NewSupp_Click(object sender, EventArgs e)
        {
            Package pkg = new Package()
            {
                PkgName = "Jamaica",
                PkgDesc = "Jerk your way to reaggae",
                PkgStartDate = new DateTime(2019, 2, 21),
                PkgEndDate = new DateTime(2019, 2, 28),
                PkgBasePrice = 1500m,
                PkgAgencyCommission = 150m
            };

            Product p = new Product()
            {
                ProductId = 25,
                ProdName = "Doritos Potato Chips"
            };

            Supplier s = new Supplier()
            {
                SupplierId = 6,
                SupName = "SUPERSTORE SUPERMARKET"
            };

            if (Transactions.Pkg_Prod_SuppTransaction(pkg, p, s, Pkg_Prod_SuppTransactionType.NewPkg_OldProd_NewSupp))
                Console.WriteLine("New Package, Old Product & New Supplier written to database");

        }


        private void usAddNewPkg_OldProd_OldSupp_Click(object sender, EventArgs e)
        {
            Package pkg = new Package()
            {
                PkgName = "West Africa",
                PkgDesc = "Feel the heat of west African rhythms",
                PkgStartDate = new DateTime(2019, 6, 21),
                PkgEndDate = new DateTime(2019, 6, 30),
                PkgBasePrice = 7000m,
                PkgAgencyCommission = 700m
            };

            Product p = new Product()
            {
                ProductId = 25,
                ProdName = "Doritos Potato Chips"
            };

            Supplier s = new Supplier()
            {
                SupplierId = 5,
                SupName = "SAFEWAY SUPERMARKET"
            };

            if (Transactions.Pkg_Prod_SuppTransaction(pkg, p, s, Pkg_Prod_SuppTransactionType.NewPkg_OldProd_OldSupp))
                Console.WriteLine("New Package, Old Product & Old Supplier written to database");

        }


        private void uxAddOldPkg_NewProd_NewSupp_Click(object sender, EventArgs e)
        {
            Package pkg = new Package()
            {
                PackageId = 12,
                PkgName = "West Africa",
                PkgDesc = "Feel the heat of west African rhythms",
                PkgStartDate = new DateTime(2019, 6, 21),
                PkgEndDate = new DateTime(2019, 6, 30),
                PkgBasePrice = 7000m,
                PkgAgencyCommission = 700m
            };

            Product p = new Product()
            {
                ProdName = "Cheetos Cheezies"
            };

            Supplier s = new Supplier()
            {
                SupplierId = 7,
                SupName = "K-Mart"
            };

            if (Transactions.Pkg_Prod_SuppTransaction(pkg, p, s, Pkg_Prod_SuppTransactionType.OldPkg_NewProd_NewSupp))
                Console.WriteLine("Old Package, New Product & New Supplier written to database");
        }

        private void uxAddOldPkg_NewProd_OldSupp_Click(object sender, EventArgs e)
        {
            Package pkg = new Package()
            {
                PackageId = 12,
                PkgName = "West Africa",
                PkgDesc = "Feel the heat of west African rhythms",
                PkgStartDate = new DateTime(2019, 6, 21),
                PkgEndDate = new DateTime(2019, 6, 30),
                PkgBasePrice = 7000m,
                PkgAgencyCommission = 700m
            };

            Product p = new Product()
            {
                ProdName = "Cracker Jack"
            };

            Supplier s = new Supplier()
            {
                SupplierId = 7,
                SupName = "K-Mart"
            };

            if (Transactions.Pkg_Prod_SuppTransaction(pkg, p, s, Pkg_Prod_SuppTransactionType.OldPkg_NewProd_OldSupp))
                Console.WriteLine("Old Package, New Product & Old Supplier written to database");
        }

        private void uxAddOldPkg_OldProd_NewSupp_Click(object sender, EventArgs e)
        {
            Package pkg = new Package()
            {
                PackageId = 12,
                PkgName = "West Africa",
                PkgDesc = "Feel the heat of west African rhythms",
                PkgStartDate = new DateTime(2019, 6, 21),
                PkgEndDate = new DateTime(2019, 6, 30),
                PkgBasePrice = 7000m,
                PkgAgencyCommission = 700m
            };

            Product p = new Product()
            {
                ProductId = 28,
                ProdName = "Cracker Jack"
            };

            Supplier s = new Supplier()
            {
                SupplierId = 8,
                SupName = "Wal-Mart"
            };

            if (Transactions.Pkg_Prod_SuppTransaction(pkg, p, s, Pkg_Prod_SuppTransactionType.OldPkg_OldProd_NewSupp))
                Console.WriteLine("Old Package, Old Product & New Supplier written to database");
        }

        private void uxAddOldPkg_OldProd_OldSupp_Click(object sender, EventArgs e)
        {
            Package pkg = new Package()
            {
                PackageId = 12,
                PkgName = "West Africa",
                PkgDesc = "Feel the heat of west African rhythms",
                PkgStartDate = new DateTime(2019, 6, 21),
                PkgEndDate = new DateTime(2019, 6, 30),
                PkgBasePrice = 7000m,
                PkgAgencyCommission = 700m
            };

            Product p = new Product()
            {
                ProductId = 28,
                ProdName = "Cracker Jack"
            };

            Supplier s = new Supplier()
            {
                SupplierId = 8,
                SupName = "Wal-Mart"
            };

            if (Transactions.Pkg_Prod_SuppTransaction(pkg, p, s, Pkg_Prod_SuppTransactionType.OldPkg_OldProd_OldSupp))
                Console.WriteLine("Old Package, Old Product & Old Supplier written to database");
        }

        #endregion

        #region UPDATEs

        private void uxGetProduct_Supplier_Click(object sender, EventArgs e)
        {
            var p_S = Products_SuppliersDB.GetProduct_Supplier(117);
            if (p_S != null)
                Debug.WriteLine(p_S);

        }

        private void uxUpdateProd_Supp_Click(object sender, EventArgs e)
        {
            var oldP_S = Products_SuppliersDB.GetProduct_Supplier(117);
            var newP_S = new Product_Supplier()
            {
                ProductSupplierId = 117,
                ProductId = 23,
                SupplierId = 5
            };

            if (oldP_S != null)
            {
                if (Products_SuppliersDB.UpdateProducts_Suppliers(oldP_S, newP_S))
                    Debug.WriteLine("Product_Supplier updated successfully");
            }
        }

        private void uxGetPkg_Prod_Supp_Click(object sender, EventArgs e)
        {
            var p_P_S = Packages_Products_SuppliersDB.GetPackage_Product_Supplier(12, 117);
            if (p_P_S != null)
                Debug.WriteLine(p_P_S);
        }

        private void uxPkg_Prod_Supp_Click(object sender, EventArgs e)
        {
            var oldP_P_S = Packages_Products_SuppliersDB.GetPackage_Product_Supplier(12, 117);
            var newP_P_S = new Package_Product_Supplier()
            {
                PackageId = 11,
                ProductSupplierId = 117
            };

            if(oldP_P_S != null)
            {
                if(Packages_Products_SuppliersDB.UpdatePackages_Products_Suppliers(oldP_P_S, newP_P_S))
                    Debug.WriteLine("Package_Product_Supplier updated successfully");

            }
        }

        #endregion

    }
}
