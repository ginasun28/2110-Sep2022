using System;
using Microsoft.Data.SqlClient;
using _2110_Sep2022.TableStorage;
using Sept2022.SqlDataAccess;

namespace _2110_Sep2022
{
    class Program
    {
        static void Main(string[] args)
        {

            // new Program().AddCustomerAccount();
            // new Program().GetCustomerAccount();
            new Program().Query();
        }

        public void Query()
        {
            var accounts = new TableStorageManager().Query("C002");

            foreach (var account in accounts)
            {
                Console.WriteLine(string.Format("{0}-{1}-{2}", account.PartitionKey, account.RowKey, account.InterestRate));
            }
        }

        public void AddCustomerAccount()
        {
            var customerAccount = new CustomerAccount()
            {
                PartitionKey = "C002",  // Customer ID - has to be Unique ID
                RowKey = "200312",      // Account ID - has to be Unique for each customer
                InterestRate = 2,
                IsAccountActive = true,
            };

            new TableStorageManager().Add(customerAccount);
        }

        public void GetCustomerAccount()
        {
            new TableStorageManager().Get("C002", "100200");
        }

        public void CreateTable()
        {
            var readConfig = new ReadConfiguration();
            var connString = readConfig.GetConnectionString(EnvironmentSettings.DBEnvironment);
            Console.WriteLine(connString);

            var sqlConnection = new SqlConnection(connString);

            string sqlStatement = "CREATE TABLE Employee(ID VARCHAR(30) NOT NULL, NAME VARCHAR(50) NOT NULL)";
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
