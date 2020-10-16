using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAzureSqlCodeFirst.Models;

namespace TodoAzureSqlCodeFirst.Services
{
    public static class TodoService
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

        public static async Task<ToDo> GetTodoAsync(int id)
        {
            using TodoContext context = new TodoContext();

            return await context.ToDos.FindAsync(id);
        }

        public static async Task<IEnumerable<ToDo>> GetTodosByCompletedAsync(bool completed)
        {
            using TodoContext context = new TodoContext();

            return await context.ToDos.Where(todo => todo.Completed == completed).ToListAsync();
        }

        public static async Task UpdateTodoAsync(int id)
        {
            using TodoContext context = new TodoContext();

            var todo = await context.ToDos.FindAsync(id);

            if (todo != null)
            {
                todo.Completed = true;
                context.Entry(todo).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public static async Task RemoveTodoAsync(int id)
        {
            using TodoContext context = new TodoContext();

            var todo = await context.ToDos.FindAsync(id);

            if (todo != null)
            {
                context.ToDos.Remove(todo);
                await context.SaveChangesAsync();
            }
        }
    }
}
