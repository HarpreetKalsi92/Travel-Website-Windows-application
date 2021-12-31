using System.Collections.Generic;
using System.Data.SqlClient;

namespace ClassLibrary
{
    /// <summary>
    /// Class for getting data from the the Packages_Products_Suppliers table in the TravelExperts database
    /// Author: James Defant
    /// Date: July 25 2019
    /// </summary>
    public static class Packages_Products_SuppliersDB
    {
        /// <summary>
        /// Return list of all Packages_Products_Suppliers in database
        /// </summary>
        /// <returns>List of Package_Product_Supplier</returns>
        public static List<Package_Product_Supplier> GetPackages_Products_Suppliers()
        {
            // Initialize variables
            List<Package_Product_Supplier> pkgProdSupList = new List<Package_Product_Supplier>();
            Package_Product_Supplier p_P_S = new Package_Product_Supplier();

            // Scope the connection object
            using (SqlConnection conn = TravelExpertsDB.GetConnection())
            {
                // Build the query string
                string selectQuery = "SELECT PackageId," +
                                            "ProductSupplierId " +
                                     "FROM Packages_Products_Suppliers";

                // Scope the command object
                using(SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    // Open the connection
                    conn.Open();

                    // Scope the reader object
                    using(SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        // Read ALL the data
                        while (dr.Read())
                        {
                            // Create a new object
                            p_P_S = new Package_Product_Supplier()
                            {
                                PackageId = (int)dr["PackageId"],
                                ProductSupplierId = (int)dr["ProductSupplierId"]
                            };

                            // Add the object to the list
                            pkgProdSupList.Add(p_P_S);
                        }
                    }
                }
            }

            // Return the list
            return pkgProdSupList;
        }

        /// <summary>
        /// Return a single Package_Product_Supplier object from database
        /// </summary>
        /// <returns>List of Package_Product_Supplier</returns>
        public static Package_Product_Supplier GetPackage_Product_Supplier(int packageId, int productSupplierId)
        {
            // Initialize variables
            Package_Product_Supplier p_P_S = new Package_Product_Supplier();

            // Scope the connection object
            using (SqlConnection conn = TravelExpertsDB.GetConnection())
            {
                // Build the query string
                string selectQuery = "SELECT PackageId," +
                                            "ProductSupplierId " +
                                     "FROM Packages_Products_Suppliers " +
                                        "WHERE PackageId = @PackageId " +
                                            "AND ProductSupplierId = @ProductSupplierId";

                // Scope the command object
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    // Add the values from the parameter
                    cmd.Parameters.AddWithValue("@PackageId", packageId);
                    cmd.Parameters.AddWithValue("@productSupplierId", productSupplierId);

                    // Open the connection
                    conn.Open();

                    // Scope the reader object
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        // Read ALL the data
                        if (dr.Read())
                        {
                            // Create a new object
                            p_P_S = new Package_Product_Supplier()
                            {
                                PackageId = (int)dr["PackageId"],
                                ProductSupplierId = (int)dr["ProductSupplierId"]
                            };
                        }
                    }
                }
            }

            // Return the object
            return p_P_S;
        }

        /// <summary>
        /// Updates an existing Product_Supplier in the database
        /// </summary>
        /// <returns>Did it update?</returns>
        public static bool UpdatePackages_Products_Suppliers(Package_Product_Supplier oldPkg_Prod_Supp, Package_Product_Supplier newPkg_Prod_Supp)
        {
            bool isSuccess = true;

            // Scope the connection
            using(SqlConnection conn = TravelExpertsDB.GetConnection())
            {
                // Build the query string
                string updateQuery = "UPDATE Packages_Products_Suppliers " +
                                        "SET PackageId = @NewPackageId, " +
                                            "ProductSupplierId = @NewProductSupplierId " +
                                        "WHERE PackageId = @OldPackageId " +
                                            "AND ProductSupplierId = @OldProductSupplierId";

                // Scope the command object
                using(SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@NewPackageId", newPkg_Prod_Supp.PackageId);
                    cmd.Parameters.AddWithValue("@NewProductSupplierId", newPkg_Prod_Supp.ProductSupplierId);

                    cmd.Parameters.AddWithValue("@OldPackageId", oldPkg_Prod_Supp.PackageId);
                    cmd.Parameters.AddWithValue("@OldProductSupplierId", oldPkg_Prod_Supp.ProductSupplierId);

                    try
                    {
                        // Open the connection
                        conn.Open();

                        // Execute query
                        int rowsUpdated = cmd.ExecuteNonQuery();

                        // Check if update was successful
                        if (rowsUpdated == 0)
                            isSuccess = false;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        // Close the connection
                        conn.Close();
                    }
                }
            }
            return isSuccess;
        }
    }
}
