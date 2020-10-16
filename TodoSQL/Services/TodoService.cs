using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoSqlCodeFirst.Models;

namespace TodoSqlCodeFirst.Services
{
    /// <summary>
    /// Preforms CRUD operations for a Sql Server
    /// CRUD = Create Read Update Delete
    /// </summary>

    public static class TodoService
    {
        public static async Task AddTodoAsync(string activity)
        {
            using ToDoContext context = new ToDoContext();

            context.ToDos.Add(new ToDo(activity));            
            await context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<ToDo>> GetTodosAsync()
        {
            using ToDoContext context = new ToDoContext();
            return await context.ToDos.ToListAsync();
        }

        public static async Task<ToDo> GetTodoAsync(int id)
        {
            using ToDoContext context = new ToDoContext();
            return await context.ToDos.FindAsync(id);
        }

        public static async Task<IEnumerable<ToDo>> GetTodosByCompletedAsync(bool completed)
        {
            using ToDoContext context = new ToDoContext();

            return await context.ToDos.Where(todo => todo.Completed == completed).ToListAsync();
        }

        public static async Task UpdateTodoAsync(int id)
        {
            using ToDoContext context = new ToDoContext();

            var todo = await context.ToDos.FindAsync(id);

            if(todo != null)
            {
                todo.Completed = true;
                context.Entry(todo).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
        
        public static async Task RemoveTodoAsync(int id)
        {
            using ToDoContext context = new ToDoContext();

            var todo = await context.ToDos.FindAsync(id);

            if (todo != null)
            {
                context.ToDos.Remove(todo);
                await context.SaveChangesAsync();
            }
        }
    }
}
