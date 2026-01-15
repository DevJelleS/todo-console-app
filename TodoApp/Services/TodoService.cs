using System.Text.Json;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoService
    {
        private readonly List<TodoItem> _todos = new();
        private int _nextId = 1;
        private readonly string _filePath =
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "todos.json");


        private void SaveToFile()
        {
            var json = JsonSerializer.Serialize(_todos, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json);
        }

        private void LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return;

            var json = File.ReadAllText(_filePath);
            var loadedTodos = JsonSerializer.Deserialize<List<TodoItem>>(json);

            if (loadedTodos == null)
                return;

            _todos.Clear();
            _todos.AddRange(loadedTodos);

            if (_todos.Count > 0)
                _nextId = _todos.Max(t => t.Id) + 1;
        }

        public TodoService()
        {
            LoadFromFile();
        }


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
            SaveToFile();
            Console.WriteLine("Taak toegevoegd!");
        }

        public void CompleteTodo()
        {
            if (_todos.Count == 0)
            {
                Console.WriteLine("Er zijn geen taken om te voltooien.");
                return;
            }

            ShowTodos();
            Console.Write("Voer het ID in van de taak die je wilt voltooien: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Ongeldig ID.");
                return;
            }

            var todo = _todos.FirstOrDefault(t => t.Id == id);

            if (todo == null)
            {
                Console.WriteLine("Taak niet gevonden.");
                return;
            }

            todo.IsCompleted = true;
            SaveToFile();
            Console.WriteLine("Taak gemarkeerd als voltooid.");
        }


        public void DeleteTodo()
        {
            if (_todos.Count == 0)
            {
                Console.WriteLine("Er zijn geen taken om te verwijderen.");
                return;
            }

            ShowTodos();
            Console.Write("Voer het ID in van de taak die je wilt verwijderen: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Ongeldig ID.");
                return;
            }

            var todo = _todos.FirstOrDefault(t => t.Id == id);

            if (todo == null)
            {
                Console.WriteLine("Taak niet gevonden.");
                return;
            }

            _todos.Remove(todo);
            SaveToFile();
            Console.WriteLine("Taak verwijderd.");
        }

    }
}
