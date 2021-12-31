using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ClassLibrary
{
    /*
    * Select, Update and Add functionality in relate to Suppliers table in TravelExperts database
    * Author: Jaswinder Sangha
    * Date: July 2019
    */
    public static class SuppliersDB
    {
        /// <summary>
        /// Retrieves data of all the Suppliers
        /// </summary>
        /// <returns> list of Suppliers type </returns>
        public static List<Supplier> GetSuppliers()
        {
            List<Supplier> lstSupplier = new List<Supplier>();//creates empty list

            Supplier sup = null;
            SqlConnection connection = TravelExpertsDB.GetConnection(); //connect to the TravelExperts database
            string selectSupplier = "SELECT SupplierId, SupName FROM Suppliers ORDER BY SupplierId"; //query to pull records

            SqlCommand cmd = new SqlCommand(selectSupplier, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);//read all rows
                while (reader.Read())
                {
                    sup = new Supplier();
                    sup.SupplierId = Convert.ToInt32(reader["SupplierId"].ToString());
                    sup.SupName = reader["SupName"].ToString();
                    lstSupplier.Add(sup); //add Suppliers to the list
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
            return lstSupplier; //return the list of Suppliers
        }


        /// <summary>
        /// Update given Suppliers
        /// </summary>
        /// <param name="oldSup, newSup"> object of Suppliers</param>
        /// <returns> bool value - true or false</returns>
        public static bool UpdateSupplier(Supplier oldSup, Supplier newSup)
        {
            bool success = true;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateSupplier = "Update Suppliers SET " +
                                    "SupName = @newSupName " +
                                    "Where SupplierId = @oldSupId " +
                                    "AND SupName = @oldSupName "; //optimisitc concurrency

            SqlCommand cmd = new SqlCommand(updateSupplier, connection);
            cmd.Parameters.AddWithValue("@newSupName", newSup.SupName);
            cmd.Parameters.AddWithValue("@oldSupId", oldSup.SupplierId);
            cmd.Parameters.AddWithValue("@oldSupName", oldSup.SupName);
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
        /// Add new record in the Suppliers table
        /// </summary>
        /// <param name="sup"> object of Supplier </param>
        /// <returns> nothing </returns>
        public static void AddSupplier(Supplier sup)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string addStatement = "Insert into Suppliers VALUES(@SupplierId,@SupName)"; //insert sql statement

            SqlCommand cmd = new SqlCommand(addStatement, connection);
            cmd.Parameters.AddWithValue("@SupplierId", sup.SupplierId);
            cmd.Parameters.AddWithValue("@SupName", sup.SupName); //value of Suppliers name to be inserted
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
