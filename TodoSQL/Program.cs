using System;
using System.Threading.Tasks;
using TodoSqlCodeFirst.Models;
using TodoSqlCodeFirst.Services;

namespace TodoSqlCodeFirst
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateToDoAsync();
            await ListAllTodosAsync();
            await GetTodoAsync();
            await GetTodosByCompletedAsync(false);
            await MarkTodoasCompletedAsync();
            await DeleteTodoAsync();
        }


        private static async Task CreateToDoAsync()
        {
            Console.Write("Enter a new activity");
            string activity = Console.ReadLine();

            await TodoService.AddTodoAsync(activity);
            Console.WriteLine("Created new Todo in database");
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

        private static async Task GetTodoAsync(int id = -1)
        {
            if(id == -1)
            {
                Console.Write("Enter id of the Todo: ");
                id = Convert.ToInt32(Console.ReadLine());
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

        private static async Task MarkTodoasCompletedAsync()
        {
            Console.Write("Enter id of the completed Todo: ");
            int id = Convert.ToInt32(Console.ReadLine());

            await TodoService.UpdateTodoAsync(id);
            await GetTodoAsync(id);
        }

        private static async Task DeleteTodoAsync()
        {
            Console.Write("Enter id of for the Todo that you want to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            await TodoService.UpdateTodoAsync(id);
            await ListAllTodosAsync();
        }
    }

}
