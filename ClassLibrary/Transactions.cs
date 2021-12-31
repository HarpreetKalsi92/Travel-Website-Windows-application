using System;
using System.Data.SqlClient;
using System.Diagnostics;
using ClassLibrary.Enums;

namespace ClassLibrary
{

    /// <summary>
    /// Class for adding data to a multitude of tables at once using transactions
    /// Author: James Defant
    /// Date: Aug 5 2019
    /// </summary>
    public static class Transactions
    {
        /// <summary>
        /// Generic method to Add Product/Supplier to database using a transaction
        /// </summary>
        /// <param name="product"></param>
        /// <param name="supplier"></param>
        /// <param name="transType">Define whether </param>
        /// <returns>Was the INSERT successful?</returns>
        public static bool Product_SupplierTransaction
            (Product product, Supplier supplier, Prod_SuppTransactionType transType)
        {

            bool isSuccess = false;

            // Scope the connection object
            using (SqlConnection conn = TravelExpertsDB.GetConnection())
            {
                // Build the query
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    SqlTransaction transaction;

                    // Start a local transaction
                    transaction = conn.BeginTransaction("NewProduct_NewSupplier");

                    cmd.Connection = conn;
                    cmd.Transaction = transaction;

                    try
                    {
                        int productID;
                        if (transType == Prod_SuppTransactionType.NewProduct_NewSupplier || 
                            transType == Prod_SuppTransactionType.NewProduct_OldSupplier)
                        {
                            // INSERT the Product
                            cmd.CommandText = "INSERT INTO Products (ProdName)" +
                                                "VALUES(@ProdName)";

                            // Add parameters to query
                            cmd.Parameters.AddWithValue("@ProdName", product.ProdName);

                            cmd.ExecuteNonQuery();

                            // Check if the Product was inserted...
                            string selectQuery = "SELECT IDENT_CURRENT('Products') FROM Products";
                            SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                            selectCmd.Transaction = transaction;

                            // ...and retrieve the new row's ID
                            productID = Convert.ToInt32(selectCmd.ExecuteScalar());
                            //---------------------------------
                        }
                        else
                        {
                            // If the product is an existing product, add it's id to the INSERT Products_Suppliers parameters
                            productID = product.ProductId;
                        }

                        if (transType == Prod_SuppTransactionType.NewProduct_NewSupplier || 
                            transType == Prod_SuppTransactionType.OldProduct_NewSupplier)
                        {
                            // INSERT the Supplier
                            cmd.CommandText = "INSERT INTO Suppliers (SupplierId, SupName)" +
                                                "VALUES(@SupplierId, @SupName)";

                            // Add parameters to query (handle null values)
                            cmd.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);

                            if (supplier.SupName == "")
                                cmd.Parameters.AddWithValue("@SupName", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@SupName", supplier.SupName);

                            cmd.ExecuteNonQuery();
                            //---------------------------------
                        }

                        // INSERT the Products_Suppliers
                        cmd.CommandText = "INSERT INTO Products_Suppliers (ProductId, SupplierId) " +
                                            "VALUES (@ProductId, @SuppId)";

                        cmd.Parameters.AddWithValue("@ProductId", productID);
                        cmd.Parameters.AddWithValue("@SuppId", supplier.SupplierId);

                        cmd.ExecuteNonQuery();
                        //---------------------------------


                        // Attempt to commit the transaction
                        transaction.Commit();
                        //                        Debug.WriteLine("Product & Supplier written to database");
                        isSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Commit Exception Type: {0}", ex.GetType());
                        Debug.WriteLine("  Message: {0}", ex.Message);

                        // Attempt to roll back the transaction. 
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            Debug.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                            Debug.WriteLine("  Message: {0}", ex2.Message);
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return isSuccess;
        }

        public static bool Pkg_Prod_SuppTransaction
            (Package package, Product product, Supplier supplier, Pkg_Prod_SuppTransactionType transType)
        {
            bool isSuccess = false;

            // Scope the connection object
            using (SqlConnection conn = TravelExpertsDB.GetConnection())
            {
                // Build the query
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    SqlTransaction transaction;

                    // Start a local transaction
                    transaction = conn.BeginTransaction("NewPkg_NewProd_NewSupp");

                    cmd.Connection = conn;
                    cmd.Transaction = transaction;

                    try
                    {
                        int packageID;
                        if (transType == Pkg_Prod_SuppTransactionType.NewPkg_NewProd_NewSupp ||
                            transType == Pkg_Prod_SuppTransactionType.NewPkg_NewProd_OldSupp ||
                            transType == Pkg_Prod_SuppTransactionType.NewPkg_OldProd_NewSupp ||
                            transType == Pkg_Prod_SuppTransactionType.NewPkg_OldProd_OldSupp)
                        {
                            // INSERT the Package
                            cmd.CommandText = "INSERT INTO Packages (PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                                                "VALUES (@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";

                            // Add parameters to query (handle null values)
                            cmd.Parameters.AddWithValue("@PkgName", package.PkgName);

                            if (package.PkgStartDate == null)
                                cmd.Parameters.AddWithValue("@PkgStartDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@PkgStartDate", package.PkgStartDate);

                            if (package.PkgEndDate == null)
                                cmd.Parameters.AddWithValue("@PkgEndDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@PkgEndDate", package.PkgEndDate);

                            cmd.Parameters.AddWithValue("@PkgDesc", package.PkgDesc);
                            cmd.Parameters.AddWithValue("@PkgBasePrice", package.PkgBasePrice);

                            if (package.PkgAgencyCommission == null)
                                cmd.Parameters.AddWithValue("@PkgAgencyCommission", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@PkgAgencyCommission", package.PkgAgencyCommission);

                            cmd.ExecuteNonQuery();

                            // Check if the Package was inserted...
                            string selectPkgIDQuery = "SELECT IDENT_CURRENT('Packages') FROM Packages";
                            SqlCommand selectPkgIDCmd = new SqlCommand(selectPkgIDQuery, conn);
                            selectPkgIDCmd.Transaction = transaction;

                            // ...and retrieve the new row's ID
                            packageID = Convert.ToInt32(selectPkgIDCmd.ExecuteScalar());
                        }
                        else
                        {
                            // Othrewise get the PackageId from the parameter
                            packageID = package.PackageId;
                        }
                        //---------------------------------

                        int productID;
                        if (transType == Pkg_Prod_SuppTransactionType.NewPkg_NewProd_NewSupp ||
                            transType == Pkg_Prod_SuppTransactionType.NewPkg_NewProd_OldSupp ||
                            transType == Pkg_Prod_SuppTransactionType.OldPkg_NewProd_NewSupp ||
                            transType == Pkg_Prod_SuppTransactionType.OldPkg_NewProd_OldSupp)
                        {
                            // INSERT the Product
                            cmd.CommandText = "INSERT INTO Products (ProdName)" +
                                                "VALUES(@ProdName)";
                            
                            // Add parameters to query
                            cmd.Parameters.AddWithValue("@ProdName", product.ProdName);
                            cmd.ExecuteNonQuery();

                            // Check if the Product was inserted...
                            string selectProdIDQuery = "SELECT IDENT_CURRENT('Products') FROM Products";
                            SqlCommand selectProdIDCmd = new SqlCommand(selectProdIDQuery, conn);
                            selectProdIDCmd.Transaction = transaction;

                            // ...and retrieve the new row's ID
                            productID = Convert.ToInt32(selectProdIDCmd.ExecuteScalar());
                        }
                        else
                        {
                            // ...Otherwise get the productID from the parameter
                            productID = product.ProductId;
                        }
                        //---------------------------------


                        if (transType == Pkg_Prod_SuppTransactionType.NewPkg_NewProd_NewSupp ||
                           transType == Pkg_Prod_SuppTransactionType.NewPkg_OldProd_NewSupp ||
                           transType == Pkg_Prod_SuppTransactionType.OldPkg_NewProd_NewSupp ||
                           transType == Pkg_Prod_SuppTransactionType.OldPkg_OldProd_NewSupp)
                        {
                            // INSERT the Supplier
                            cmd.CommandText = "INSERT INTO Suppliers (SupplierId, SupName)" +
                                                "VALUES(@SupplierId, @SupName)";

                            // Add parameters to query (handle null values)
                            cmd.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);

                            if (supplier.SupName == "")
                                cmd.Parameters.AddWithValue("@SupName", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@SupName", supplier.SupName);

                            cmd.ExecuteNonQuery();
                        }
                        //---------------------------------

                        // INSERT the Products_Suppliers
                        cmd.CommandText = "INSERT INTO Products_Suppliers (ProductId, SupplierId) " +
                                            "VALUES (@ProductId, @SuppId)";

                        // Add parameters to query
                        cmd.Parameters.AddWithValue("@ProductId", productID);
                        cmd.Parameters.AddWithValue("@SuppId", supplier.SupplierId);

                        cmd.ExecuteNonQuery();

                        // Check if the Product was inserted...
                        string selectProdSuppIDQuery = "SELECT IDENT_CURRENT('Products_Suppliers') FROM Products_Suppliers";
                        SqlCommand selectProdSuppIDCmd = new SqlCommand(selectProdSuppIDQuery, conn);
                        selectProdSuppIDCmd.Transaction = transaction;

                        // ...and retrieve the new row's ID
                        int productSupplierID = Convert.ToInt32(selectProdSuppIDCmd.ExecuteScalar());
                        //---------------------------------

                        // INSERT the Packages_Products_Suppliers
                        cmd.CommandText = "INSERT INTO Packages_Products_Suppliers (PackageId, ProductSupplierId) " +
                                            "VALUES (@PackageId, @ProductSupplierId)";

                        // Add parameters to query
                        cmd.Parameters.AddWithValue("@PackageId", packageID);
                        cmd.Parameters.AddWithValue("@ProductSupplierId", productSupplierID);

                        cmd.ExecuteNonQuery();
                        //---------------------------------

                        // Attempt to commit the transaction
                        transaction.Commit();

                        isSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Commit Exception Type: {0}", ex.GetType());
                        Debug.WriteLine("  Message: {0}", ex.Message);
                        Debug.WriteLine(ex.ToString());
                        // Attempt to roll back the transaction. 
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            Debug.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                            Debug.WriteLine("  Message: {0}", ex2.Message);
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return isSuccess;
        }
    }
}
