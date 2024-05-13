using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;
using AkshayTask.Models;
namespace AkshayTask.Repositories
{
    public class CosmosQuestionRepository : IQuestionRepository
    {
        private readonly Container _container;

        public CosmosQuestionRepository(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task AddQuestionAsync(Question question)
        {
            await _container.CreateItemAsync(question, new PartitionKey(question.Type));
        }

        public async Task UpdateQuestionAsync(int id, Question question)
        {
            await _container.ReplaceItemAsync(question, id.ToString(), new PartitionKey(question.Type));
        }
    }



}
