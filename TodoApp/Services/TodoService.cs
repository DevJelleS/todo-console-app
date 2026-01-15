using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoService
    {
        private List<TodoItem> _todos = new();

        public void ShowTodos()
        {
            Console.WriteLine("Nog geen taken.");
        }

        public void AddTodo()
        {
            Console.WriteLine("Toevoegen komt later.");
        }

        public void CompleteTodo()
        {
            Console.WriteLine("Voltooien komt later.");
        }

        public void DeleteTodo()
        {
            Console.WriteLine("Verwijderen komt later.");
        }
    }
}
