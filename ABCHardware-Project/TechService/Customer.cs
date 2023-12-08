using System.Data;
using System.Net;
using ABCHardware_Project.Models;
using Microsoft.Data.SqlClient;
namespace ABCHardware_Project.TechService
{
    public class Customer
    {
        private static string? _connectionString;

        public Customer()
        {
            // Constructor Logic
            ConfigurationBuilder databaseUserBuilder = new ConfigurationBuilder();
            databaseUserBuilder.SetBasePath(Directory.GetCurrentDirectory());
            databaseUserBuilder.AddJsonFile("appsettings.json");
            IConfiguration databaseUsersConfiguration = databaseUserBuilder.Build();
            _connectionString = databaseUsersConfiguration.GetConnectionString("BAIST3150");
            //  _connectionString = databaseUsersConfiguration.GetConnectionString("BAIST3150")!; //null forgiving operator

        }
        #region Add Customer
        public bool AddCustomer(Models.Customer customer)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("CreateCustomer", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@LastName", customer.LastName).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@Address", customer.Address).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@City", customer.City).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@Province", customer.Province).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode).SqlDbType = SqlDbType.Char;

                        command.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error-Occurreed - {ex.Message}");
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

        #region Find Customer
        public List<Models.Customer> FindCustomerWtihName(string firstOrLastName)
        {

            List<Models.Customer> customerInfo = new List<Models.Customer>();


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("FindCustomer", conn))
                {
                    command.Parameters.AddWithValue("@FirstOrLastName", firstOrLastName).SqlDbType = SqlDbType.NVarChar;
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {

                                while (reader.Read())
                                {
                                    Models.Customer customer = new Models.Customer
                                    {

                                        CustomerID = (int)reader["CustomerID"],
                                        FirstName = (string)reader["FirstName"],
                                        LastName = (string)reader["LastName"],
                                        Address = (string)reader["Address"],
                                        City = (string)reader["City"],
                                        Province = (string)reader["Province"],
                                        PostalCode = (string)reader["PostalCode"]

                                    };


                                    customerInfo.Add(customer);
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
            return customerInfo;
        }

        #endregion

        #region Update Customer

        public bool UpdateCustomers(Models.Customer customer)
        {


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("UpdateCustomer", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.Parameters.AddWithValue("@CustomerID", customer.CustomerID).SqlDbType = SqlDbType.Int;
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@LastName", customer.LastName).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@Address", customer.Address).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@City", customer.City).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@Province", customer.Province).SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode).SqlDbType = SqlDbType.Char;
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

        #region GetCustomer information for Update

        public Models.Customer GetCustomerInfo(int customerID)
        {
            Models.Customer customer = new Models.Customer();  
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("GetCustomer", conn))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerID).SqlDbType = SqlDbType.Int;
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {

                                while (reader.Read())
                                {
                                   customer = new Models.Customer
                                    {

                                        CustomerID = (int)reader["CustomerID"],
                                        FirstName = (string)reader["FirstName"],
                                        LastName = (string)reader["LastName"],
                                        Address = (string)reader["Address"],
                                        City = (string)reader["City"],
                                        Province = (string)reader["Province"],
                                        PostalCode = (string)reader["PostalCode"]

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
            return customer;
        }
        #endregion

        #region

        public bool DeleteCustomers(int customerID)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("RemoveCustomer", conn))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerID",customerID).SqlDbType = SqlDbType.Int;
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
