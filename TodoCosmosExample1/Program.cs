using System;
using System.Threading.Tasks;
using TodoCosmosWithEF.Services;
using TodoCosmosWithEF.Models;

namespace TodoCosmosWithEF
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // await CreateToDoAsync();

            // await ListAllTodosAsync();

            // await GetTodoAsync();

            // await MarkTodoAsCompletedAsync();

            // await GetTodosByCompletedAsync(true);

            // await DeleteTodoAsync();
        }



        private static async Task CreateToDoAsync()
        {
            Console.Write("Enter a new Acticity:");
            string activity = Console.ReadLine();

            await TodoService.AddToDoAsync(activity);
            Console.WriteLine("Created new Todo in the DataBase");
        }

        private static async Task ListAllTodosAsync()
        {
            var todos = await TodoService.GetToDosAsync();
            Console.WriteLine("Listing all Todo from the DataBase");
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
                Console.Write("Enter The Id for the Todo:");
                id = Console.ReadLine();

                //return id;
            }


            var todo = await TodoService.GetToDoAsync(id);

            Console.WriteLine($"Id: {todo.Id}");
            Console.WriteLine($"Created: {todo.Created}");
            Console.WriteLine($"Completed: {todo.Completed}");
            Console.WriteLine($"Activity: {todo.Activity}");
            Console.WriteLine(new string('-', 30));
        }
        private static async Task GetTodosByCompletedAsync(bool completed)
        {
            var todos = await TodoService.GetTodosByCompletedAsync(completed);
            Console.WriteLine("Listing Todo from the DataBase");
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
            Console.Write("Enter The Id Of the completedTodo:");
            var id = Console.ReadLine();

            await TodoService.UpdateToDoAsync(id);
            await GetTodoAsync(id);

        }
        private static async Task DeleteTodoAsync()
        {
            Console.Write("Enter The Id Of the Todo you want gone:");
            var id = Console.ReadLine();

            await TodoService.RemoveTodoAsync(id);
            await ListAllTodosAsync();
        }
    }
}
