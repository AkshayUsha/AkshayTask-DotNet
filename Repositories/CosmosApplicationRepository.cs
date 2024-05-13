using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;
using AkshayTask.Models;
namespace AkshayTask.Repositories
{




    public class CosmosApplicationRepository : IApplicationRepository
    {
        private readonly Container _container;

        public CosmosApplicationRepository(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task SubmitApplicationAsync(Application application)
        {
            await _container.CreateItemAsync(application);
        }
    }
}