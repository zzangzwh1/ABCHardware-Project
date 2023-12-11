using System.Data;
using System.Net;
using ABCHardware_Project.Models;
using Microsoft.Data.SqlClient;

namespace ABCHardware_Project.TechService
{
    public class Item
    {
        private readonly string _connectionString;
        public Item()
        {
            // Constructor Logic
            ConfigurationBuilder databaseUserBuilder = new ConfigurationBuilder();
            databaseUserBuilder.SetBasePath(Directory.GetCurrentDirectory());
            databaseUserBuilder.AddJsonFile("appsettings.json");
            IConfiguration databaseUsersConfiguration = databaseUserBuilder.Build();
            _connectionString = databaseUsersConfiguration.GetConnectionString("BAIST3150")!;
            //  _connectionString = databaseUsersConfiguration.GetConnectionString("BAIST3150")!; //null forgiving operator
        }

        #region Add Item


        public bool AddItem(Models.Item items)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("CreateItem", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        command.Parameters.AddWithValue("@ItemCode", items.ItemCode).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@Description", items.Description).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@UnitPrice", items.UnitPrice).SqlDbType = SqlDbType.Decimal;
                        command.Parameters.AddWithValue("@Quantity", items.Quantity).SqlDbType = SqlDbType.Int;

                        command.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error-Occurred - {ex.Message}");
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }


                }
            }
            return true;
        }
        #endregion

        #region
        public bool AddTempItem(Models.Item items)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("CreateTempItem", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        command.Parameters.AddWithValue("@ItemCode", items.ItemCode).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@Description", items.Description).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@UnitPrice", items.UnitPrice).SqlDbType = SqlDbType.Decimal;
                        command.Parameters.AddWithValue("@Quantity", items.Quantity).SqlDbType = SqlDbType.Int;

                        command.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error-Occurred - {ex.Message}");
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }


                }
            }
            return true;
        }
        #endregion

        #region GetItemInformation

        public Models.Item GetItemInformation(string itemCode)
        {

            Models.Item itemInfo = new Models.Item();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("FindItem", conn))
                {
                    command.Parameters.AddWithValue("@ItemCode", itemCode).SqlDbType = SqlDbType.NVarChar;
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {

                                while (reader.Read())
                                {
                                    itemInfo = new Models.Item
                                    {

                                        ItemCode = (string)reader["ItemCode"],
                                        Description = (string)reader["Description"],
                                        UnitPrice = (decimal)reader["UnitPrice"],
                                        Quantity = (int)reader["Quantity"]


                                    };



                                }
                            }
                            else
                            {
                                Console.WriteLine($"There are No Student exists with that student ID try other Student ID");
                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred - {ex.Message}");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return itemInfo;
        }
        #endregion

        #region
        public bool UpdateItems(Models.Item items)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("ModifyItem", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.Parameters.AddWithValue("@ItemCode", items.ItemCode).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@Description", items.Description).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@UnitPrice", items.UnitPrice).SqlDbType = SqlDbType.Decimal;
                        command.Parameters.AddWithValue("@Quantity", items.Quantity).SqlDbType = SqlDbType.Int;

                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred {ex.Message}");
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
            return true;
        }
        #endregion


        #region
        public bool DeleteItem(string itemCode)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("DeleteItem", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.Parameters.AddWithValue("@ItemCode", itemCode).SqlDbType = SqlDbType.NVarChar;


                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred {ex.Message}");
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
            return true;
        }
        #endregion

        #region

        public List<Models.Item> GetEveryItem()
        {
            List<Models.Item> everyItem = new List<Models.Item>();
            Models.Item itemInfo = new Models.Item();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("GetEveryItems", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {

                                while (reader.Read())
                                {
                                    itemInfo = new Models.Item
                                    {

                                        ItemCode = (string)reader["ItemCode"],
                                        Description = (string)reader["Description"],
                                        UnitPrice = (decimal)reader["UnitPrice"],
                                        Quantity = (int)reader["Quantity"]



                                    };


                                    everyItem.Add(itemInfo);
                                }
                             

                            }
                            else
                            {
                                everyItem = null!; 
                            }
                         


                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred - {ex.Message}");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return everyItem;
        }

        #endregion
    }
}
