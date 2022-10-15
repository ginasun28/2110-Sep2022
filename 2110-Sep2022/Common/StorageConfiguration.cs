using _2110_Sep2022.Common;

namespace _2110_Sep2022.Common
{
    public class StorageConfiguration : IStorageConfiguration
    {
        // "DefaultEndpointsProtocol=https;AccountName=storagegblset2022;AccountKey={your-account-key};EndpointSuffix=core.windows.net";
        private static string connectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";
        public string GetStorageConnectionString()
        {
            return connectionString;
        }
    }
}
