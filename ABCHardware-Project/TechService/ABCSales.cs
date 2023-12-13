using Microsoft.Data.SqlClient;
using System.Data;

namespace ABCHardware_Project.TechService
{
    public class ABCSales
    {
        private readonly string _connectionString;
        public ABCSales()
        {
            // Constructor Logic
            ConfigurationBuilder databaseUserBuilder = new ConfigurationBuilder();
            databaseUserBuilder.SetBasePath(Directory.GetCurrentDirectory());
            databaseUserBuilder.AddJsonFile("appsettings.json");
            IConfiguration databaseUsersConfiguration = databaseUserBuilder.Build();
            _connectionString = databaseUsersConfiguration.GetConnectionString("BAIST3150");
            //  _connectionString = databaseUsersConfiguration.GetConnectionString("BAIST3150")!; //null forgiving operator
        }

        #region AddSales
        public int AddSale(Models.ABCSales sales)
        {


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("AddSale", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {

                        command.Parameters.AddWithValue("@SaleNumber", sales.SaleNumber).SqlDbType = SqlDbType.Int;
                        command.Parameters.AddWithValue("@CustomerID", sales.CustomerID).SqlDbType = SqlDbType.Int;
                        command.Parameters.AddWithValue("@SaleDate", sales.SaleDate).SqlDbType = SqlDbType.Date;
                        command.Parameters.AddWithValue("@SalePerson", sales.SalePerson).SqlDbType = SqlDbType.NVarChar;

                        command.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error-Occurred - {ex.Message}");
                        return 0;
                    }
                    finally
                    {
                        conn.Close();
                    }


                }
            }
            return sales.SaleNumber;
        }
        #endregion

       

    }
}

