using System;
using System.Collections.Generic;
using System.Text;

namespace _2110_Sep2022.TableStorage
{
    public class StorageConfiguration : IStorageConfiguration
    {
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=storageaccountwk2;AccountKey=FXZa/WG1DBAOMjgv8HA7a9FdWE9g7VZPj3l9qRi2aDTSJMdF5jip1S9A7sZBg3mwJui2XY97t/ju+AStB3p/Sg==;EndpointSuffix=core.windows.net";
        public string GetStorageConnectionString()
        {
            return connectionString;
        }
    }
}
