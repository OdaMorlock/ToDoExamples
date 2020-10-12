using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoCosmosWithEF.Models;

namespace TodoCosmosWithEF.Services
{
    public static class TodoService
    {
        public static async Task AddToDoAsync(string activity)
        {
            using TodoContext context = new TodoContext();

            context.Todos.Add(new Todo(activity));

            await context.SaveChangesAsync();

        }
        public static async Task<IEnumerable<Todo>> GetToDosAsync()
        {
            using TodoContext context = new TodoContext();

            return await context.Todos.ToListAsync();
        }

        public static async Task<Todo> GetToDoAsync(string id)
        {
            using TodoContext context = new TodoContext();

            return await context.Todos.FindAsync(id);
        }

        public static async Task<IEnumerable<Todo>> GetTodosByCompletedAsync(bool completed)
        {
            using TodoContext context = new TodoContext();

            return await context.Todos.Where(todo => todo.Completed == completed).ToListAsync();
        }

        public static async Task UpdateToDoAsync(string id)
        {
            using TodoContext context = new TodoContext();

            var todo = await context.Todos.Where(todo => todo.Id == id).FirstOrDefaultAsync();
            // Try 
            if (todo != null)
            {
                todo.Completed = true;
                context.Entry(todo).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
            //Catch
        }

        public static async Task RemoveTodoAsync(string id)
        {
            using TodoContext context = new TodoContext();

            var todo = await context.Todos.Where(todo => todo.Id == id).FirstOrDefaultAsync();
            //Try
            if (todo != null)
            {

                context.Todos.Remove(todo);
                await context.SaveChangesAsync();
            }
            //Catch
        }
    }
}
