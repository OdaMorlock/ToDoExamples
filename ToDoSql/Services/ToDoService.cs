using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCodeFirst.Models;

namespace ToDoCodeFirst.Services
{

    /// <summary>
    /// Performs CRUD Operations for a Sql Server
    /// CRUD = Created Read Update Delete = Add,Get,Update,Remove
    /// </summary>

    public static class ToDoService
    {
        public static async Task AddToDoAsync(string activity)
        {
            using ToDoContext context = new ToDoContext();

            context.Todos.Add(new ToDo(activity));
            
            await context.SaveChangesAsync();

        }
        public static async Task<IEnumerable<ToDo>> GetToDosAsync()
        {
            using ToDoContext context = new ToDoContext();

            return await context.Todos.ToListAsync();
        }

        public static async Task<ToDo> GetToDoAsync(int id)
        {
            using ToDoContext context = new ToDoContext();

            return await context.Todos.FindAsync(id);
        }

        public static async Task<IEnumerable<ToDo>> GetTodosByCompletedAsync(bool completed)
        {
            using ToDoContext context = new ToDoContext();

            return await context.Todos.Where(todo => todo.Completed == completed).ToListAsync();
        }

        public static async Task UpdateToDoAsync(int id)
        {
            using ToDoContext context = new ToDoContext();

            var todo = await context.Todos.FindAsync(id);
           // Try 
            if( todo != null)
            {
                todo.Completed = true;
                context.Entry(todo).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
            //Catch
        }

        public static async Task RemoveTodoAsync(int id)
        {
            using ToDoContext context = new ToDoContext();

            var todo = await context.Todos.FindAsync(id);
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
