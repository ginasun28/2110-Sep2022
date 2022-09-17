using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2110_Sep2022.TableStorage
{
    public class TableStorageManager
    {
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=storageaccountwk2;AccountKey=FXZa/WG1DBAOMjgv8HA7a9FdWE9g7VZPj3l9qRi2aDTSJMdF5jip1S9A7sZBg3mwJui2XY97t/ju+AStB3p/Sg==;EndpointSuffix=core.windows.net";

        public void Add(CustomerAccount customerAccount)
        {
            var tableServiceClient = new TableServiceClient(TableStorageManager.connectionString);
            var tableClient = tableServiceClient.GetTableClient(tableName: "CustomerAccount");

            var res = tableClient.AddEntity<CustomerAccount>(customerAccount);
        }

        public CustomerAccount Get(string customerID, string accountID)
        {
            var tableServiceClient = new TableServiceClient(TableStorageManager.connectionString);
            var tableClient = tableServiceClient.GetTableClient(tableName: "CustomerAccount");

            var customerAccount = tableClient.GetEntity<CustomerAccount>(
                partitionKey: customerID,
                rowKey: accountID
                );

            return customerAccount;
        }

        public IEnumerable<CustomerAccount> Query(string customerID)
        {
            var tableServiceClient = new TableServiceClient(TableStorageManager.connectionString);
            var tableClient = tableServiceClient.GetTableClient(tableName: "CustomerAccount");

            var customerAccounts = tableClient.Query<CustomerAccount>(x => x.PartitionKey == customerID);

            return customerAccounts;
        }
    }
}
