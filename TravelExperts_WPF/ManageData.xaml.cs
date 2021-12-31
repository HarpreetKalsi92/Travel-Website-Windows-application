using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TravelExperts_Winforms;
using ClassLibrary;
using ClassLibrary.Interfaces;
using ClassLibrary.Enums;
using System;
using System.Windows.Media;

namespace TravelExperts_WPF
{
    /// <summary>
    /// Main GUI for Travel Experts Data Management software
    /// Author: James Defant
    /// Date: Aug 9 2019
    /// </summary>
    public partial class ManageData : Window, ITravelAdmin
    {
        #region Fields

        // Variables to hold objects from sub-forms
        public Package NewPackage { private get; set; }
        public Product NewProduct { private get; set; }
        public Supplier NewSupplier { private get; set; }

        // Data values to commit appropriate transaction
        private DataType _pkgData = DataType.NotSet, 
            _prodData = DataType.NotSet, 
            _SuppData = DataType.NotSet;

        // Timer for error status bar
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;

        #endregion

        // Constructor
        public ManageData()
        {
            InitializeComponent();
        }
  
        #region Event Handlers

        // Initialize Window
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDisplay();

            SetStatus("Ready");
        }

        // Select Package from DataGrid
        private void PackageDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Cast the sender to a DataGrid object
            DataGrid grid = (DataGrid)sender;

            // Check the selection
            if (grid.SelectedItem is Package)
            {
                // Assign the selected package to the NewPackage variable
                Package pkg = (Package)grid.SelectedItem;
                NewPackage = pkg;
                _pkgData = DataType.Old;
                uxSelectedPackage.Content = pkg.PkgName;
                uxSelectedPackage1.Content = pkg.PkgName;

                uxPkgName.Text = pkg.PkgName;

                RefreshDisplay(pkg);
            }
        }

        // Select Product from DataGrid
        private void ProductDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Cast the sender to a DataGrid object
            DataGrid grid = (DataGrid)sender;

            // Check the selection
            if (grid.SelectedItem is Product)
            {
                // Assign the selected product to the NewProduct variable
                Product prod = (Product)grid.SelectedItem;
                NewProduct = prod;
                _prodData = DataType.Old;
                uxSelectedProduct.Content = prod.ProdName;
                uxSelectedProduct1.Content = prod.ProdName;
                uxProdName.Text = prod.ProdName;

                RefreshDisplay(prod);
            }
        }

        // Select Supplier from DataGrid
        private void SupplierDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Cast the sender to a DataGrid object
            DataGrid grid = (DataGrid)sender;

            // Check the selection
            if (grid.SelectedItem is Supplier)
            {
                // Assign the selected supplier to the NewSupplier variable
                Supplier sup = (Supplier)grid.SelectedItem;
                NewSupplier = sup;
                _SuppData = DataType.Old;
                uxSelectedSupplier.Content = sup.SupName;
                uxSelectedSupplier1.Content = sup.SupName;
                uxSuppName.Text = sup.SupName;

                RefreshDisplay(sup);
            }
        }

        //--------------------------------------------------
        // ADD NEW BUTTONS

        // Show AddPackage form
        private void UxAddNewPackage_Click(object sender, RoutedEventArgs e)
        {
            AddPackage frmAddPkg = new AddPackage(this);
            frmAddPkg.ShowDialog(new WPFWindowWrapper(this));

            // Add object to textbox placeholder
            if (NewPackage != null)
            {
                uxPkgName.Text = NewPackage.PkgName;
                _pkgData = DataType.New;
            }

            RefreshDisplay();
            RefreshDisplay(NewPackage);
        }

        // Show frmProduct form
        private void UxAddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            frmProduct frmProd = new frmProduct(this);
            frmProd.ShowDialog(new WPFWindowWrapper(this));

            // Add object to textbox placeholder
            if (NewProduct != null)
            {
                uxProdName.Text = NewProduct.ProdName;
                _prodData = DataType.New;
            }

            RefreshDisplay();
            RefreshDisplay(NewProduct);

        }

        // Show frmSupplier form
        private void UxAddNewSupplier_Click(object sender, RoutedEventArgs e)
        {
            frmSupplier frmSupp = new frmSupplier(this);
            frmSupp.ShowDialog(new WPFWindowWrapper(this));

            // Add object to textbox placeholder
            if (NewSupplier != null)
            {
                uxSuppName.Text = NewSupplier.SupName;
                _SuppData = DataType.New;
            }

            RefreshDisplay();
            RefreshDisplay(NewSupplier);

        }

        //--------------------------------------------------
        // EDIT BUTTONS

        // Show EditPackage form
        private void uxEditPackages_Click(object sender, RoutedEventArgs e)
        {
            EditPackage frmEditPkg = new EditPackage(this);
            frmEditPkg.ShowDialog(new WPFWindowWrapper(this));

            RefreshDisplay();
            RefreshDisplay(NewPackage);
        }

        // Show frmProduct form
        private void uxEditProducts_Click(object sender, RoutedEventArgs e)
        {
            frmProduct frmProd = new frmProduct(this);
            frmProd.ShowDialog(new WPFWindowWrapper(this));

            RefreshDisplay();
            RefreshDisplay(NewProduct);
        }

        // Show frmSupplier form
        private void uxEditSuppliers_Click(object sender, RoutedEventArgs e)
        {
            frmSupplier frmSupp = new frmSupplier(this);
            frmSupp.ShowDialog(new WPFWindowWrapper(this));
        
            RefreshDisplay();
            RefreshDisplay(NewSupplier);
        }

        //--------------------------------------------------
        // CLEAR BUTTONS
        private void UxClearPkg_Click(object sender, RoutedEventArgs e)
        {
            NewPackage = null;
            uxPkgName.Text = "";
            _pkgData = DataType.NotSet;

            ValidateData();
        }

        private void UxClearProd_Click(object sender, RoutedEventArgs e)
        {
            NewProduct = null;
            uxProdName.Text = "";
            _prodData = DataType.NotSet;

            ValidateData();
        }

        private void UxClearSupp_Click(object sender, RoutedEventArgs e)
        {
            NewSupplier = null;
            uxSuppName.Text = "";
            _SuppData = DataType.NotSet;

            ValidateData();
        }

        // Save data to database
        private void UxSaveData_Click(object sender, RoutedEventArgs e)
        {
            bool isSaveSuccess = false;

            switch (_pkgData)
            {
                // Create a product/supplier (4 types)
                case DataType.NotSet:
                    if (_prodData == DataType.New && _SuppData == DataType.New)
                        isSaveSuccess = Transactions.Product_SupplierTransaction(NewProduct, NewSupplier, Prod_SuppTransactionType.NewProduct_NewSupplier);

                    else if (_prodData == DataType.New && _SuppData == DataType.Old)
                        isSaveSuccess = Transactions.Product_SupplierTransaction(NewProduct, NewSupplier, Prod_SuppTransactionType.NewProduct_OldSupplier);

                    else if (_prodData == DataType.Old && _SuppData == DataType.New)
                        isSaveSuccess = Transactions.Product_SupplierTransaction(NewProduct, NewSupplier, Prod_SuppTransactionType.OldProduct_NewSupplier);

                    else if (_prodData == DataType.Old && _SuppData == DataType.Old)
                        isSaveSuccess = Transactions.Product_SupplierTransaction(NewProduct, NewSupplier, Prod_SuppTransactionType.OldProduct_OldSupplier);

                    break;

                // Create package(new)/product/supplier
                case DataType.New:
                    if (_prodData == DataType.New && _SuppData == DataType.New)
                        isSaveSuccess = Transactions.Pkg_Prod_SuppTransaction(NewPackage, NewProduct, NewSupplier, Pkg_Prod_SuppTransactionType.NewPkg_NewProd_NewSupp);

                    else if (_prodData == DataType.New && _SuppData == DataType.Old)
                        isSaveSuccess = Transactions.Pkg_Prod_SuppTransaction(NewPackage, NewProduct, NewSupplier, Pkg_Prod_SuppTransactionType.NewPkg_NewProd_OldSupp);

                    else if (_prodData == DataType.Old && _SuppData == DataType.New)
                        isSaveSuccess = Transactions.Pkg_Prod_SuppTransaction(NewPackage, NewProduct, NewSupplier, Pkg_Prod_SuppTransactionType.NewPkg_OldProd_NewSupp);

                    else if (_prodData == DataType.Old && _SuppData == DataType.Old)
                        isSaveSuccess = Transactions.Pkg_Prod_SuppTransaction(NewPackage, NewProduct, NewSupplier, Pkg_Prod_SuppTransactionType.NewPkg_OldProd_OldSupp);

                    break;

                // Create package(old)/product/supplier
                case DataType.Old:
                    if (_prodData == DataType.New && _SuppData == DataType.New)
                        isSaveSuccess = Transactions.Pkg_Prod_SuppTransaction(NewPackage, NewProduct, NewSupplier, Pkg_Prod_SuppTransactionType.OldPkg_NewProd_NewSupp);

                    else if (_prodData == DataType.New && _SuppData == DataType.Old)
                        isSaveSuccess = Transactions.Pkg_Prod_SuppTransaction(NewPackage, NewProduct, NewSupplier, Pkg_Prod_SuppTransactionType.OldPkg_NewProd_OldSupp);

                    else if (_prodData == DataType.Old && _SuppData == DataType.New)
                        isSaveSuccess = Transactions.Pkg_Prod_SuppTransaction(NewPackage, NewProduct, NewSupplier, Pkg_Prod_SuppTransactionType.OldPkg_OldProd_NewSupp);

                    else if (_prodData == DataType.Old && _SuppData == DataType.Old)
                        isSaveSuccess = Transactions.Pkg_Prod_SuppTransaction(NewPackage, NewProduct, NewSupplier, Pkg_Prod_SuppTransactionType.OldPkg_OldProd_OldSupp);

                    break;
            }

            // Set StatusBar message depending on success of transaction
            if (isSaveSuccess)
            {
                System.Console.WriteLine("DB save successful");

                SetStatus("Data successfully saved in database", "#FFA5DCAF");
            }
            else
            {
                System.Console.WriteLine("DB save failed");

                SetStatus("Error saving data in database", "#FFDCA5A5");
            }

            StartTimer();

            RefreshDisplay();
        }

        // Event that resets the StatusBar message to "Ready" after timer completes
        private void dispatcherTimer_tick(object source, EventArgs e)
        {
            dispatcherTimer.Stop();
            SetStatus("Ready");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Enable the SAVE DATA button once there is enough data to save
        /// </summary>
        private void ValidateData()
        {
            if ((NewProduct != null && NewSupplier != null) ||
                (NewPackage != null && NewProduct != null && NewSupplier != null))
            {
                uxSaveData.IsEnabled = true;
            }
            else
            {
                uxSaveData.IsEnabled = false;
            }
        }

        // Refresh Primary DataGrids
        private void RefreshDisplay()
        {
            packages_PackageDataGrid.ItemsSource = PackagesDB.GetPackageList();
            packages_PackageDataGrid1.ItemsSource = PackagesDB.GetPackageList();

            products_ProductDataGrid.ItemsSource = ProductDB.GetProducts();
            products_ProductDataGrid1.ItemsSource = ProductDB.GetProducts();

            suppliers_SupplierDataGrid.ItemsSource = SuppliersDB.GetSuppliers();
            suppliers_SupplierDataGrid1.ItemsSource = SuppliersDB.GetSuppliers();

            uxNumPkgs.Content = PackagesDB.GetPackageList().Count;
            uxNumPkgs1.Content = PackagesDB.GetPackageList().Count;

            uxNumProds.Content = ProductDB.GetProducts().Count;
            uxNumProds1.Content = ProductDB.GetProducts().Count;

            uxNumSupps.Content = SuppliersDB.GetSuppliers().Count;
            uxNumSupp1.Content = SuppliersDB.GetSuppliers().Count;
            

            ValidateData();
        }

        // Refresh Filtered DataGrids
        private void RefreshDisplay(object dbObj)
        {

            switch (dbObj)
            {
                case Package package:
                    Package(package);
                    break;

                case Product product:
                    Product(product);
                    break;

                case Supplier supplier:
                    Supplier(supplier);
                    break;

                default:
                    break;
            }

            ValidateData();
        }

        // Populate secondary DataGrids with details of Primary
        private void Package(Package package)
        {
            // Prepare data
            var packageDetail = from packages in PackagesDB.GetPackageList()
                                join packages_Products_Suppliers in Packages_Products_SuppliersDB.GetPackages_Products_Suppliers()
                                    on packages.PackageId equals packages_Products_Suppliers.PackageId
                                join products_Suppliers in Products_SuppliersDB.GetProducts_Suppliers()
                                    on packages_Products_Suppliers.ProductSupplierId equals products_Suppliers.ProductSupplierId
                                join suppliers in SuppliersDB.GetSuppliers()
                                    on products_Suppliers.SupplierId equals suppliers.SupplierId
                                join products in ProductDB.GetProducts()
                                    on products_Suppliers.ProductId equals products.ProductId
                                where packages.PackageId == package.PackageId
                                select new
                                {
                                    suppliers.SupplierId
                                    ,
                                    suppliers.SupName
                                    ,
                                    products.ProductId
                                    ,
                                    products.ProdName
                                };

            // Assign data to DataGrid
            packages_SupplierDataGrid.ItemsSource = packageDetail;
        }

        // Populate secondary DataGrids with details of Primary
        private void Product(Product product)
        {
            // Prepare data
            var productDetail = from products in ProductDB.GetProducts()
                                join products_Suppliers in Products_SuppliersDB.GetProducts_Suppliers()
                                     on products.ProductId equals products_Suppliers.ProductId
                                join suppliers in SuppliersDB.GetSuppliers()
                                     on products_Suppliers.SupplierId equals suppliers.SupplierId
                                where products_Suppliers.ProductId == product.ProductId
                                select new
                                {
                                    ProductName = products.ProdName
                                    ,
                                    products_Suppliers.ProductSupplierId
                                    ,
                                    products_Suppliers.SupplierId
                                    ,
                                    SupplierName = suppliers.SupName
                                };

            var packageDetail = from suppliers in SuppliersDB.GetSuppliers()
                                join product_Suppliers in Products_SuppliersDB.GetProducts_Suppliers()
                                    on suppliers.SupplierId equals product_Suppliers.SupplierId
                                join packages_Products_Suppliers in Packages_Products_SuppliersDB.GetPackages_Products_Suppliers()
                                    on product_Suppliers.ProductSupplierId equals packages_Products_Suppliers.ProductSupplierId
                                join packages in PackagesDB.GetPackageList()
                                    on packages_Products_Suppliers.PackageId equals packages.PackageId
                                where product_Suppliers.ProductId == product.ProductId
                                select new
                                {
                                    suppliers.SupName
                                    ,
                                    packages.PackageId
                                    ,
                                    packages.PkgName
                                    ,
                                    packages.PkgStartDate
                                    ,
                                    packages.PkgEndDate
                                    ,
                                    packages.PkgBasePrice
                                    ,
                                    packages.PkgAgencyCommission
                                };

            // Assign data to DataGrids
            products_SupplierDataGrid.ItemsSource = productDetail;
            products_PackageDataGrid.ItemsSource = packageDetail;
        }

        // Populate secondary DataGrids with details of Primary
        private void Supplier(Supplier supplier)
        {
            // Prepare data
            var productSuppliers = from products in ProductDB.GetProducts()
                                   join products_Suppliers in Products_SuppliersDB.GetProducts_Suppliers()
                                        on products.ProductId equals products_Suppliers.ProductId
                                   where products_Suppliers.SupplierId == supplier.SupplierId
                                   select new
                                   {
                                       products.ProductId,
                                       products.ProdName,
                                       SupplierID = products_Suppliers.SupplierId
                                   };

            var packageDetail = from suppliers in SuppliersDB.GetSuppliers()
                                join product_Suppliers in Products_SuppliersDB.GetProducts_Suppliers()
                                    on suppliers.SupplierId equals product_Suppliers.SupplierId
                                join packages_Products_Suppliers in Packages_Products_SuppliersDB.GetPackages_Products_Suppliers()
                                    on product_Suppliers.ProductSupplierId equals packages_Products_Suppliers.ProductSupplierId
                                join packages in PackagesDB.GetPackageList()
                                    on packages_Products_Suppliers.PackageId equals packages.PackageId
                                where product_Suppliers.SupplierId == supplier.SupplierId
                                select new
                                {
                                    suppliers.SupName
                                    ,
                                    packages.PackageId
                                    ,
                                    packages.PkgName
                                    ,
                                    packages.PkgStartDate
                                    ,
                                    packages.PkgEndDate
                                    ,
                                    packages.PkgBasePrice
                                    ,
                                    packages.PkgAgencyCommission
                                };

            // Assign data to DataGrids
            suppliers_ProductDataGrid.ItemsSource = productSuppliers;
            suppliers_PackageDataGrid.ItemsSource = packageDetail;
        }


        // Timer to reset the StatusBar message
        private void StartTimer()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        // Set the status bar message, optional - set the status bar background color
        private void SetStatus(string msg, string color = "#FFD4DAFF")
        {
            uxStatus.Text = msg;

            var bc = new BrushConverter();

            uxStatusBar.Background = (Brush)bc.ConvertFrom(color);
        }


        #endregion

    }
}
