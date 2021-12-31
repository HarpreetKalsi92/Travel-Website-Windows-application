using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ClassLibrary
{
    /*
    * Select, Update and Add functionality in relate to Products table in TravelExperts database
    * Author: Jaswinder Sangha
    * Date: July 2019
    */
    public static class ProductDB
    {
        /// <summary>
        /// Retrieves data of all the products
        /// </summary>
        /// <returns> list of Products type </returns>
        public static List<Product> GetProducts()
        {
            List<Product> lstProduct = new List<Product>();//creates empty list

            Product prod = null;
            SqlConnection connection = TravelExpertsDB.GetConnection(); //connect to the TravelExperts database
            string selectProduct = "SELECT ProductId, ProdName FROM Products ORDER BY ProductId"; //query to pull records

            SqlCommand cmd = new SqlCommand(selectProduct, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);//read all rows
                while (reader.Read())
                {
                    prod = new Product();
                    prod.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                    prod.ProdName = reader["ProdName"].ToString();
                    lstProduct.Add(prod); //add product to the list
                }
            }
            catch (Exception ex)
            {
//                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return lstProduct; //return the list of products
        }


        /// <summary>
        /// Update given product
        /// </summary>
        /// <param name="oldProd, newProd"> object of Product</param>
        /// <returns> bool value - true or false</returns>
        public static bool UpdateProduct(Product oldProd, Product newProd)
        {
            bool success = true;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateProduct = "Update Products SET " +
                                    "ProdName = @newProdName " +
                                    "Where ProductId = @oldProdId " +
                                    "AND ProdName = @oldProdName "; //optimisitc concurrency

            SqlCommand cmd = new SqlCommand(updateProduct, connection);
            cmd.Parameters.AddWithValue("@newProdName", newProd.ProdName);
            cmd.Parameters.AddWithValue("@oldProdId", oldProd.ProductId);
            cmd.Parameters.AddWithValue("@oldProdName", oldProd.ProdName);
            try
            {
                connection.Open();
                int rowUpdated = cmd.ExecuteNonQuery(); //run the update statement
                if (rowUpdated == 0)
                    success = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return success; //return true if successfull to update the record
        }
/*
        /// <summary>
        /// Add new record in the Products table
        /// </summary>
        /// <param name="prod"> object of Product </param>
        /// <returns> nothing </returns>
        public static void AddProduct(Product prod)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string addStatement = "Insert into Products VALUES(@ProdName)"; //insert sql statement

            SqlCommand cmd = new SqlCommand(addStatement, connection);
            cmd.Parameters.AddWithValue("@ProdName", prod.ProdName); //value of product name to be inserted
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery(); //execute the insert statement
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close(); //close the database connection
            }
        }
*/
    }
}
