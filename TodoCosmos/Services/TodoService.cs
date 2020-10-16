using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using TodoCosmos.Models;

namespace TodoCosmos.Services
{
    class TodoService
    {
        private static CosmosClient cosmosClient;
        private static Database database;
        private static Container container;

        private static async Task CreateDatabaseAsync()
        {
            database = await cosmosClient.CreateDatabaseIfNotExistsAsync(ConfigurationManager.AppSettings["DatabaseName"]);
        }
        private static async Task CreateContainerAsync()
        {
            container = await database.CreateContainerIfNotExistsAsync(
                    ConfigurationManager.AppSettings["ContainerName"], "/id", 400
                );
        }

        public static async Task InitializeCosmosDb()
        {
            cosmosClient = new CosmosClient(
                ConfigurationManager.AppSettings["EndpointUri"],
                ConfigurationManager.AppSettings["PrimaryKey"]
            );

            await CreateDatabaseAsync();
            await CreateContainerAsync();
        }

        public static async Task AddTodoAsync(string activity)
        {
            await container.CreateItemAsync(new Todo { Activity = activity });
        }

        public static async Task<IEnumerable<Todo>> GetTodosAsync()
        {
            var query = new QueryDefinition("SELECT * FROM c");
            FeedIterator<Todo> result = container.GetItemQueryIterator<Todo>(query);

            var todos = new List<Todo>();

            while (result.HasMoreResults)
            {
                var data = await result.ReadNextAsync();
                foreach(var todo in data)
                {
                    todos.Add(todo);
                }
            }

            return todos;
        }

        public static async Task<Todo> GetTodoAsync(string id)
        {
            var result = await container.ReadItemAsync<Todo>(id, new PartitionKey(id));
            return result.Resource;
        }

        public static async Task UpdateTodoAsync(string id)
        {
            var result = await container.ReadItemAsync<Todo>(id, new PartitionKey(id));

            if(result != null)
            {
                var todo = result.Resource;
                todo.Completed = true;

                await container.ReplaceItemAsync(todo, todo.Id, new PartitionKey(todo.Id));
            }
        }

        public static async Task RemoveTodoAsync(string id)
        {
            var result = await container.ReadItemAsync<Todo>(id, new PartitionKey(id));

            if (result != null)
            {
                var todo = result.Resource;
                todo.Completed = true;
                await container.DeleteItemAsync<Todo>(todo.Id, new PartitionKey(todo.Id));               
            }
        }
    }
}
