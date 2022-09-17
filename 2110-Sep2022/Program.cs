using System;
using Microsoft.Data.SqlClient;
using _2110_Sep2022.TableStorage;
using Sept2022.SqlDataAccess;
using _2110_Sep2022.Common;
using _2110_Sep2022.Queue;

namespace _2110_Sep2022
{
    class Program
    {
        private static string tableName = "CustomerAccount";
        private static string queueName = "orderqueue";
        private IStorageConfiguration storageConfiguration = new StorageConfiguration();

        static void Main(string[] args)
        {

            // new Program().AddCustomerAccount();
            // new Program().GetCustomerAccount();
            // new Program().Query();

            new Program().EnqueueMessage("892123", "I19101");
            new Program().EnqueueMessage("890167", "I17701");
            new Program().EnqueueMessage("890623", "I19101");
            new Program().EnqueueMessage("890190", "I19121");
            // new Program().PeekMessage();
            new Program().DequeueMessage();
        }

        public void EnqueueMessage(string orderID, string customerID)
        {
            var order = new Order() { OrderID = orderID, CustomerID = customerID };
            var orderQueueRepository = new OrderQueueRepository(this.storageConfiguration, queueName);
            orderQueueRepository.Enqueue(order);
        }

        public void PeekMessage()
        {
            var orderQueueRepository = new OrderQueueRepository(this.storageConfiguration, queueName);
            orderQueueRepository.Peek();
        }

        public void DequeueMessage()
        {
            var orderQueueRepository = new OrderQueueRepository(this.storageConfiguration, queueName);
            orderQueueRepository.Dequeue();
        }


        public void Query()
        {
            var accounts = new CustomerAccountTableStorageRepository(this.storageConfiguration, tableName)
                .Query("C013");

            foreach (var account in accounts)
            {
                Console.WriteLine(string.Format("{0}-{1}-{2}", account.PartitionKey, account.RowKey, account.InterestRate));
            }
        }

        public void AddCustomerAccount()
        {
            var customerAccount = new CustomerAccount()
            {
                PartitionKey = "C013",  // Customer ID - has to be Unique ID
                RowKey = "200002",      // Account ID - has to be Unique for each customer
                InterestRate = 2,
                IsAccountActive = true,
            };

            new CustomerAccountTableStorageRepository(this.storageConfiguration, tableName).Add(customerAccount);
        }

        public void GetCustomerAccount()
        {
            var customer = new CustomerAccountTableStorageRepository(this.storageConfiguration, tableName).Get("C013", "200002");
            Console.WriteLine($"{customer.PartitionKey}, {customer.RowKey}, {customer.InterestRate}");
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
