using _2110_Sep2022.Common;

namespace _2110_Sep2022.Common
{
    public class StorageConfiguration : IStorageConfiguration
    {
        // private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=storageaccountwk2;AccountKey=FXZa/WG1DBAOMjgv8HA7a9FdWE9g7VZPj3l9qRi2aDTSJMdF5jip1S9A7sZBg3mwJui2XY97t/ju+AStB3p/Sg==;EndpointSuffix=core.windows.net";
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=storagegblset2022;AccountKey=ujEqZTVSBUgnr35X5lWPxlFRifEA9O9FKiW/UACPHCoZU2Nd4Ba47dMSM6hpyKnH+BIXX+moqypk+AStjWtNKw==;EndpointSuffix=core.windows.net";

        public string GetStorageConnectionString()
        {
            return connectionString;
        }
    }
}
