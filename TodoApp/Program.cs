using TodoApp.Services;

var todoService = new TodoService();

while (true)
{
    Console.Clear();
    Console.WriteLine("=== TO-DO APP ===");
    Console.WriteLine("1. Bekijk taken");
    Console.WriteLine("2. Voeg taak toe");
    Console.WriteLine("3. Markeer taak als voltooid");
    Console.WriteLine("4. Verwijder taak");
    Console.WriteLine("0. Afsluiten");
    Console.Write("Maak een keuze: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            todoService.ShowTodos();
            break;
        case "2":
            todoService.AddTodo();
            break;
        case "3":
            todoService.CompleteTodo();
            break;
        case "4":
            todoService.DeleteTodo();
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Ongeldige keuze.");
            break;
    }

    Console.WriteLine("Druk op een toets om verder te gaan...");
    Console.ReadKey();
}
