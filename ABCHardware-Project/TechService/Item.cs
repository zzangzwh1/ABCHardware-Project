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


        public bool AddItem(Models.SaleItem items)
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
        public bool AddTempItem(Models.SaleItem items)
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

        public Models.SaleItem GetItemInformation(string itemCode)
        {

            Models.SaleItem itemInfo = new Models.SaleItem();

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
                                    itemInfo = new Models.SaleItem
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
        public bool UpdateItems(Models.SaleItem items)
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


        #region Delete Item
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

        #region Get Every Item

        public List<Models.SaleItem> GetEveryItem()
        {
            List<Models.SaleItem> everyItem = new List<Models.SaleItem>();
            Models.SaleItem itemInfo = new Models.SaleItem();

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
                                    itemInfo = new Models.SaleItem
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

        #region Update Quantity Item 
        public bool UpdateQuantityItem(Models.SaleItem items)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("UpdateItemQuantity", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.Parameters.AddWithValue("@ItemCode", items.ItemCode).SqlDbType = SqlDbType.NVarChar;
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
    }
}
