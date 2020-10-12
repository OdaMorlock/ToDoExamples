using System;
using System.Threading.Tasks;
using ToDoCodeFirst.Services;

namespace ToDoCodeFirst
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

            await ToDoService.AddToDoAsync(activity);
            Console.WriteLine("Created new Todo in the DataBase");
        }

        private static async Task ListAllTodosAsync()
        {
            var todos = await ToDoService.GetToDosAsync();
            Console.WriteLine("Listing all Todo from the DataBase");
            foreach (var todo in todos)
            {
                Console.WriteLine($"Id: {todo.Id}");
                Console.WriteLine($"Created: {todo.Created}");
                Console.WriteLine($"Completed: {todo.Completed}");
                Console.WriteLine($"Activity: {todo.Activity}");
                Console.WriteLine(new string ('-',30));
            }
        }
             
        private static async Task GetTodoAsync(int id = -1)
        {
            if(id == -1) 
            {
                Console.Write("Enter The Id Of a Todo:");
                id = Convert.ToInt32(Console.ReadLine());

                //return id;
            }

            
            var todo = await ToDoService.GetToDoAsync(id);

            Console.WriteLine($"Id: {todo.Id}");
            Console.WriteLine($"Created: {todo.Created}");
            Console.WriteLine($"Completed: {todo.Completed}");
            Console.WriteLine($"Activity: {todo.Activity}");
            Console.WriteLine(new string('-', 30));
        }
        private static async Task GetTodosByCompletedAsync(bool completed)
        {
            var todos = await ToDoService.GetTodosByCompletedAsync(completed);
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
            int id = Convert.ToInt32(Console.ReadLine());

            await ToDoService.UpdateToDoAsync(id);
            await GetTodoAsync(id);

        }
        private static async Task DeleteTodoAsync()
        {
            Console.Write("Enter The Id Of the Todo you want gone:");
            int id = Convert.ToInt32(Console.ReadLine());

            await ToDoService.RemoveTodoAsync(id);
            await ListAllTodosAsync();
        }
    }
}
