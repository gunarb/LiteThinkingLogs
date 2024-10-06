using Microsoft.Azure.Cosmos;

namespace InterfaceAdapters_Data
{
    public class AppDbContext
    {
        //private readonly CosmosClient _cosmosClient;

        public AppDbContext()
        {
            var endpoint = "https://cosmosdb-lt.documents.azure.com:443/";
            var key = "";
            var databaseName = "ltlogdataset";
            var containerName = "FileEntity";

            var cosmosClient = new CosmosClient(endpoint, key);
            LogContainer = cosmosClient.GetContainer(databaseName, containerName);
        }

        public Container LogContainer { get; }
    }
}
