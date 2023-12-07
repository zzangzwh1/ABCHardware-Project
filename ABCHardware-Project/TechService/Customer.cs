using System.Data;
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
    }
}
