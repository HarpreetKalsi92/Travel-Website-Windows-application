using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ClassLibrary
{
    /// <summary>
    /// Class for getting data from the the Products_Suppliers table in the TravelExperts database
    /// Author: James Defant
    /// Date: July 25 2019
    /// </summary>
    public static class Products_SuppliersDB
    {
        /// <summary>
        /// Return list of all Product_Supplier in database
        /// </summary>
        /// <returns>List of Product_Supplier</returns>
        public static List<Product_Supplier> GetProducts_Suppliers()
        {
            // Initialize variables
            List<Product_Supplier> prodSupList = new List<Product_Supplier>();
            Product_Supplier p_S = new Product_Supplier();

            // Scope the connection object
            using (SqlConnection conn = TravelExpertsDB.GetConnection())
            {
                // Build the query string
                string selectQuery = "SELECT ProductSupplierId," +
                                            "ProductId, " +
                                            "SupplierId " +
                                     "FROM Products_Suppliers";

                // Scope the command object
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    // Open the connection
                    conn.Open();

                    // Scope the reader object
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        // Read ALL the data
                        while (dr.Read())
                        {
                            // Create a new object
                            p_S = new Product_Supplier()
                            {
                                ProductSupplierId = Convert.ToInt32(dr["ProductSupplierId"])
                            };

                            // Check for null values
                            int col = dr.GetOrdinal("ProductId");
                            if (dr.IsDBNull(col))
                                p_S.ProductId = null;
                            else
                                p_S.ProductId = Convert.ToInt32(dr["ProductId"]);

                            col = dr.GetOrdinal("SupplierId");
                            if (dr.IsDBNull(col))
                                p_S.SupplierId = null;
                            else
                                p_S.SupplierId = Convert.ToInt32(dr["SupplierId"]);

                            // Add the object to the list
                            prodSupList.Add(p_S);
                        }
                    }
                }
            }

            // Return the list
            return prodSupList;
        }

        /// <summary>
        /// Return a single Product_Supplier object from database
        /// </summary>
        /// <returns>Product_Supplier object OR null</returns>
        public static Product_Supplier GetProduct_Supplier(int productSupplierId)
        {
            // Initialize variables
            Product_Supplier p_S = null;

            // Scope the connection object
            using (SqlConnection conn = TravelExpertsDB.GetConnection())
            {
                // Build the query string
                string selectQuery = "SELECT ProductSupplierId," +
                                            "ProductId, " +
                                            "SupplierId " +
                                     "FROM Products_Suppliers " +
                                        "WHERE ProductSupplierId = @ProductSupplierId";

                // Scope the command object
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    // Add the value from the parameter
                    cmd.Parameters.AddWithValue("@ProductSupplierId", productSupplierId);

                    // Open the connection
                    conn.Open();

                    // Scope the reader object
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        // Read ALL the data
                        if (dr.Read())
                        {
                            // Create a new object
                            p_S = new Product_Supplier()
                            {
                                ProductSupplierId = Convert.ToInt32(dr["ProductSupplierId"])
                            };

                            // Check for null values
                            int col = dr.GetOrdinal("ProductId");
                            if (dr.IsDBNull(col))
                                p_S.ProductId = null;
                            else
                                p_S.ProductId = Convert.ToInt32(dr["ProductId"]);

                            col = dr.GetOrdinal("SupplierId");
                            if (dr.IsDBNull(col))
                                p_S.SupplierId = null;
                            else
                                p_S.SupplierId = Convert.ToInt32(dr["SupplierId"]);
                        }
                    }
                }
            }

            // Return the object
            return p_S;
        }

        /// <summary>
        /// Updates an existing Product_Supplier in the database
        /// </summary>
        /// <returns>Did it update?</returns>
        public static bool UpdateProducts_Suppliers (Product_Supplier oldProd_Supp, Product_Supplier newProd_Supp)
        {
            bool isSuccess = true;

            // Scope the connection object
            using(SqlConnection conn = TravelExpertsDB.GetConnection())
            {
                // Build the query string
                string updateQuery = "UPDATE Products_Suppliers " +
                                        "SET ProductId = @NewProductId, " +
                                            "SupplierId = @NewSupplierId " +
                                        "WHERE ProductSupplierId = @OldProductSupplierId " +
                                            "AND ProductId = @OldProductId " +
                                            "AND SupplierId = @OldSupplierId";

                // Scope the command object
                using(SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Account for null values
                    if(newProd_Supp.ProductId == null)
                        cmd.Parameters.AddWithValue("@NewProductId", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@NewProductId", newProd_Supp.ProductId);

                    if (newProd_Supp.SupplierId == null)
                        cmd.Parameters.AddWithValue("@NewSupplierId", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@NewSupplierId", newProd_Supp.SupplierId);

                    cmd.Parameters.AddWithValue("@OldProductSupplierId", oldProd_Supp.ProductSupplierId);

                    if (oldProd_Supp.ProductId == null)
                        cmd.Parameters.AddWithValue("@OldProductId", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OldProductId", oldProd_Supp.ProductId);

                    if (oldProd_Supp.SupplierId == null)
                        cmd.Parameters.AddWithValue("@OldSupplierId", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OldSupplierId", oldProd_Supp.SupplierId);

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
