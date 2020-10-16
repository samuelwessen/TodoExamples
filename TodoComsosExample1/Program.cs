using System;
using System.Threading.Tasks;
using TodoCosmosWithEF.Services;

namespace TodoCosmosWithEF
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateTodoAsync();
            await ListAllTodosAsync();
            await GetTodoAsync();
            await GetTodosByCompletedAsync(false);
            await MarkTodoAsCompletedAsync();
            await DeleteTodoAsync();
        }

        private static async Task CreateTodoAsync()
        {
            Console.Write("Enter a new activity: ");
            string activity = Console.ReadLine();

            await TodoService.AddTodoAsync(activity);
            Console.WriteLine("Created new Todo in the Database");
        }

        private static async Task ListAllTodosAsync()
        {
            var todos = await TodoService.GetTodosAsync();

            Console.WriteLine("Listing all Todos from the Database");
            foreach (var todo in todos)
            {
                Console.WriteLine($"Id: {todo.Id}");
                Console.WriteLine($"Created: {todo.Created}");
                Console.WriteLine($"Completed: {todo.Completed}");
                Console.WriteLine($"Activity: {todo.Activity}");
                Console.WriteLine(new string('-', 30));
            }
        }

        private static async Task GetTodoAsync(string id = null)
        {
            if (id == null)
            {
                Console.Write("Enter id for the Todo: ");
                id = Console.ReadLine();
            }

            var todo = await TodoService.GetTodoAsync(id);
            Console.WriteLine($"Id: {todo.Id}");
            Console.WriteLine($"Created: {todo.Created}");
            Console.WriteLine($"Completed: {todo.Completed}");
            Console.WriteLine($"Activity: {todo.Activity}");
        }

        private static async Task GetTodosByCompletedAsync(bool completed)
        {
            var todos = await TodoService.GetTodosByCompletedAsync(completed);

            Console.WriteLine("Listing Todos from the Database");
            foreach (var todo in todos)
            {
                Console.WriteLine($"Id: {todo.Id}");
                Console.WriteLine($"Created: {todo.Created}");
                Console.WriteLine($"Completed: {todo.Completed}");
                Console.WriteLine($"Activity: {todo.Activity}");
                Console.WriteLine(new string('-', 30));
            }
        }

        private static async Task MarkTodoAsCompletedAsync()
        {
            Console.Write("Enter id of the completed Todo: ");
            var id = Console.ReadLine();

            await TodoService.UpdateTodoAsync(id);
            await GetTodoAsync(id);
        }

        private static async Task DeleteTodoAsync()
        {
            Console.Write("Enter id for the Todo that you want to delete: ");
            var id = Console.ReadLine();

            await TodoService.RemoveTodoAsync(id);
            await ListAllTodosAsync();
        }
    }
}
