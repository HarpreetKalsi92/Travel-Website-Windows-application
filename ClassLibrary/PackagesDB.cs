using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClassLibrary
{
    /// <summary>
    /// PackageDB class written by Darren Uong
    /// Class that contains methods to communicate with Database
    /// </summary>
    public static class PackagesDB
    {

        public static Package GetPackage(int PkgID)
        {

            Package package = new Package();
            //Public method GetPackage, which returns a single package from TravelExperts database
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string selectQuery = "SELECT * FROM [Packages] WHERE PackageID = @PkgID"; //SQL query
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                cmd.Parameters.AddWithValue("@PkgID", PkgID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow)) //read single row of order details
                    {
                        if (reader.Read())
                        {
                            package.PackageId = (int)reader["PackageID"];
                            package.PkgName = (string)reader["PkgName"];
                            package.PkgStartDate = (DateTime)reader["PkgStartDate"];
                            package.PkgEndDate = (DateTime)reader["PkgEndDate"];
                            package.PkgDesc = (string)reader["PkgDesc"];
                            package.PkgBasePrice = (decimal)reader["PkgBasePrice"];
                            package.PkgAgencyCommission = (decimal)reader["PkgAgencyCommission"];
                        }
                    }
                }
                catch (Exception ex)
                {
//                    MessageBox.Show(ex.ToString(), "Error");

                }
                finally
                {
                    connection.Close();
                }
            } //end of using statement
            return package; //return Package from DB
        } //end of GetPackage

        public static List<Package> GetPackageList()
        {
            List<Package> allPackages = new List<Package>(); //List to store all current packages
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string selectString = "SELECT * FROM Packages";
                SqlCommand cmd = new SqlCommand(selectString, connection);
                allPackages.Clear();
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) //Loop through all packages
                        {
                            Package package = new Package();

                            package.PackageId = (int)reader["PackageId"];
                            package.PkgName = (string)reader["PkgName"];
                            package.PkgBasePrice = (decimal)reader["PkgBasePrice"];


                            //Set nullable fields
                            int col1 = reader.GetOrdinal("PkgStartDate");
                            if (reader.IsDBNull(col1))
                            {
                                package.PkgStartDate = null;
                            }
                            else package.PkgStartDate = (DateTime)reader["PkgStartDate"];

                            int col2 = reader.GetOrdinal("PkgEndDate");
                            if (reader.IsDBNull(col2))
                            {
                                package.PkgEndDate = null;
                            }
                            else package.PkgEndDate = (DateTime)reader["PkgEndDate"];

                            int col3 = reader.GetOrdinal("PkgDesc");
                            if (reader.IsDBNull(col3))
                            {
                                package.PkgDesc = "";
                            }
                            else package.PkgDesc = (string)reader["PkgDesc"];

                            int col4 = reader.GetOrdinal("PkgAgencyCommission");
                            if (reader.IsDBNull(col4))
                            {
                                package.PkgAgencyCommission = null;
                            }
                            else package.PkgAgencyCommission = (decimal)reader["PkgAgencyCommission"];

                            allPackages.Add(package);
                        }
                    }
                }
                catch (Exception ex)
                {
//                    MessageBox.Show(ex.ToString(), "Error");

                }
                finally
                {
                    connection.Close();
                }
            }
            return allPackages;
        }



        public static bool UpdatePackage(Package oldPackage, Package newPackage)
        {
            bool success = false;
            //Public static method to update package details for existing package
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string selectQuery = "UPDATE [Packages] SET PkgName = @NewPkgName, PkgStartDate  = @NewPkgStartDate, PkgEndDate = @NewPkgEndDate, " +
                    " PkgDesc = @NewPkgDesc, PkgBasePrice = @NewPkgBasePrice, PkgAgencyCommission = @NewPkgAgencyCommission " +
                    " WHERE PackageID = @OldPackageID ";

                //AND PkgStartDate = @OldPkgStartDate AND PkgEndDate = @OldPkgEndDate " +
                //" AND PkgDesc = @OldPkgDesc AND PkgBasePrice = @OldPkgBasePrice AND PkgAgencyCommission = @OldPkgAgencyCommission " +
                //" AND PkgName = @OldPkgName
                SqlCommand cmd = new SqlCommand(selectQuery, connection);                
                cmd.Parameters.AddWithValue("@NewPkgBasePrice", newPackage.PkgBasePrice);                
                cmd.Parameters.AddWithValue("@NewPkgName", newPackage.PkgName);
                if (newPackage.PkgDesc == "" || newPackage.PkgDesc == null)
                {
                    cmd.Parameters.AddWithValue("@NewPkgDesc", DBNull.Value);

                }
                else cmd.Parameters.AddWithValue("@NewPkgDesc", newPackage.PkgDesc);


                if (newPackage.PkgStartDate == null)
                {
                    cmd.Parameters.AddWithValue("@NewPkgStartDate", DBNull.Value);

                }
                else cmd.Parameters.AddWithValue("@NewPkgStartDate", newPackage.PkgStartDate);

                if (newPackage.PkgEndDate == null)
                {
                    cmd.Parameters.AddWithValue("@NewPkgEndDate", DBNull.Value);

                }
                else cmd.Parameters.AddWithValue("@NewPkgEndDate", newPackage.PkgEndDate);

                if (newPackage.PkgAgencyCommission == null)
                {
                    cmd.Parameters.AddWithValue("@NewPkgAgencyCommission", DBNull.Value);

                }
                else cmd.Parameters.AddWithValue("@NewPkgAgencyCommission", newPackage.PkgAgencyCommission);

                //OldPackage
                cmd.Parameters.AddWithValue("@OldPackageID", oldPackage.PackageId);



                try
                {
                    connection.Open();
                    int count = cmd.ExecuteNonQuery(); //returns 0 or 1
                    if (count > 0)
                    {
                        success = true;
//                        MessageBox.Show("Successfully updated Package");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

                return success;

            }


        }//end of UpdatePackage
/*
        public static bool AddPackage(Package newPackage)
        {
            bool success = false;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string insertString = "INSERT INTO Packages VALUES(@PkgName, @PkgStartDate,@PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";
                SqlCommand cmd = new SqlCommand(insertString, connection);
                cmd.Parameters.AddWithValue("@PkgName", newPackage.PkgName);
                cmd.Parameters.AddWithValue("@PkgBasePrice", newPackage.PkgBasePrice);

                if (newPackage.PkgDesc == "" || newPackage.PkgDesc == null)
                {
                    cmd.Parameters.AddWithValue("@PkgDesc", DBNull.Value);

                }
                else cmd.Parameters.AddWithValue("@PkgDesc", newPackage.PkgDesc);


                if (newPackage.PkgStartDate == null)
                {
                    cmd.Parameters.AddWithValue("@PkgStartDate", DBNull.Value);

                }
                else cmd.Parameters.AddWithValue("@PkgStartDate", newPackage.PkgStartDate);

                if (newPackage.PkgEndDate == null)
                {
                    cmd.Parameters.AddWithValue("@PkgEndDate", DBNull.Value);

                }
                else cmd.Parameters.AddWithValue("@PkgEndDate", newPackage.PkgEndDate);

                if (newPackage.PkgAgencyCommission == null)
                {
                    cmd.Parameters.AddWithValue("@PkgAgencyCommission", DBNull.Value);

                }
                else cmd.Parameters.AddWithValue("@PkgAgencyCommission", newPackage.PkgAgencyCommission);

                

                try
                {
                    connection.Open();
                    int count = cmd.ExecuteNonQuery(); //returns 0 or 1
                    if (count > 0)
                    {
                        success = true;
//                        MessageBox.Show("Successfully added Package");
                    }
                }
                catch (Exception ex)
                {
//                    MessageBox.Show(ex.ToString());
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

            }

            return success;
        }
*/
    }//end of Class PackageDB

}//end of Namespace

