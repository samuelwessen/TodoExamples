using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoCosmosWithEF.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TodoCosmosWithEF.Services
{
    public class TodoService
    {
        public static async Task AddTodoAsync(string activity)
        {
            using TodoContext context = new TodoContext();

            context.ToDos.Add(new ToDo(activity));
            await context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<ToDo>> GetTodosAsync()
        {
            using TodoContext context = new TodoContext();
            return await context.ToDos.ToListAsync();
        }

        public static async Task<ToDo> GetTodoAsync(string id)
        {
            using TodoContext context = new TodoContext();
            return await context.ToDos.Where(todo => todo.Id == id).FirstOrDefaultAsync();
        }

        public static async Task<IEnumerable<ToDo>> GetTodosByCompletedAsync(bool completed)
        {
            using TodoContext context = new TodoContext();

            return await context.ToDos.Where(todo => todo.Completed == completed).ToListAsync();
        }

        public static async Task UpdateTodoAsync(string id)
        {
            using TodoContext context = new TodoContext();

            var todo = await context.ToDos.Where(todo => todo.Id == id).FirstOrDefaultAsync();

            if (todo != null)
            {
                todo.Completed = true;
                context.Entry(todo).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public static async Task RemoveTodoAsync(string id)
        {
            using TodoContext context = new TodoContext();

            var todo = await context.ToDos.Where(todo => todo.Id == id).FirstOrDefaultAsync();

            if (todo != null)
            {
                context.ToDos.Remove(todo);
                await context.SaveChangesAsync();
            }
        }
    }
}
