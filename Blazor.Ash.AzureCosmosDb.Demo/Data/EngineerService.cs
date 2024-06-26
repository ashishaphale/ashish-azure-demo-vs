﻿
using Microsoft.Azure.Cosmos;

namespace Blazor.Ash.AzureCosmosDb.Demo.Data
{
    public class EngineerService : IEngineerService
    {
        private readonly string CosmosDbConnectionString = "AccountEndpoint=https://ashish-cosmos-db.documents.azure.com:443/;AccountKey=mnxuHkvh9ni9UDXqfw34sV8TYIUFqNVSTuHHLQQi1sMpF1Idt64kvXB5JAxsT9w0lAxrrcklcjIrACDbApqQhg==;";
        private readonly string CosmosDbName = "Contractors";
        private readonly string CosmosDbContainerName = "Engineers";

        private Container GetContainerClient()
        {
            var cosmosDbClient = new CosmosClient(CosmosDbConnectionString);
            var container = cosmosDbClient.GetContainer(CosmosDbName, CosmosDbContainerName);
            return container;
        }
        public async Task DeleteEngineer(string? id, string? partitionKey)
        {
            try
            {
                var container = GetContainerClient();
                var response = await container.DeleteItemAsync<Engineer>(id, new PartitionKey(partitionKey));
            }
            catch (Exception ex)
            {
                throw new Exception("Exception", ex);
            }
        }

        public async Task<List<Engineer>> GetEngineerDetails()
        {
            List<Engineer> engineers = new List<Engineer>();
            try
            {
                var container = GetContainerClient();
                var sqlQuery = "SELECT * FROM c";
                QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);
                FeedIterator<Engineer> queryResultSetIterator = container.GetItemQueryIterator<Engineer>(queryDefinition);

                while (queryResultSetIterator.HasMoreResults)
                {
                    FeedResponse<Engineer> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    foreach (Engineer engineer in currentResultSet)
                    {
                        engineers.Add(engineer);
                    }
                }
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            return engineers;
        }

        public async Task<Engineer> GetEngineerDetailsById(string? id, string? partitionKey)
        {
            try
            {
                var container = GetContainerClient();
                ItemResponse<Engineer> response = await container.ReadItemAsync<Engineer>(id, new PartitionKey(partitionKey));
                return response.Resource;
            }
            catch (Exception ex)
            {

                throw new Exception("Exception ", ex);
            }
        }

        public async Task UpsertEngineer(Engineer engineer)
        {
            try
            {
                if (engineer.id == null)
                {
                    engineer.id = Guid.NewGuid();
                }
                var container = GetContainerClient();
                var updateRes = await container.UpsertItemAsync(engineer, new PartitionKey(engineer.id.ToString()));
                Console.Write(updateRes.StatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception", ex);
            }
        }
    }
}
