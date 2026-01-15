using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoService
    {
        private readonly List<TodoItem> _todos = new();
        private int _nextId = 1;

        public void ShowTodos()
        {
            if (_todos.Count == 0)
            {
                Console.WriteLine("Geen taken gevonden.");
                return;
            }

            foreach (var todo in _todos)
            {
                var status = todo.IsCompleted ? "[X]" : "[ ]";
                Console.WriteLine($"{todo.Id}. {status} {todo.Title}");
            }
        }

        public void AddTodo()
        {
            Console.Write("Voer de titel van de taak in: ");
            var title = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Titel mag niet leeg zijn.");
                return;
            }

            var todo = new TodoItem
            {
                Id = _nextId++,
                Title = title,
                IsCompleted = false
            };

            _todos.Add(todo);
            Console.WriteLine("Taak toegevoegd!");
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
