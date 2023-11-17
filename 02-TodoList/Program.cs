Console.WriteLine("Hello!");
List<string> todos = new List<string>();

bool shallExit = false;

while (!shallExit)
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    var userInput = Console.ReadLine()!;

    switch (userInput)
    {
        case "s":
        case "S":
            PrintTodos(todos);
            break;
        case "a":
        case "A":
            AddTodo(todos);
            break;
        case "r":
        case "R":
            RemoveTodo(todos);
            break;
        case "e":
        case "E":
            shallExit = true;
            break;
        default:
            Console.WriteLine("Incorrect input");
            break;
    }
}


void PrintTodos(List<string> todos)
{
    if (todos.Count == 0)
    {
        NoTodoMessage();
        return;
    }

    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }
}


void AddTodo(List<string> todos)
{
    string inputTodo;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        inputTodo = Console.ReadLine()!;
    } while (!ValidateDescription(inputTodo));
    todos.Add(inputTodo);
}


bool ValidateDescription(string inputTodo)
{
    if (inputTodo.Length == 0)
    {
        Console.WriteLine("The description cannot be empty.");
        return false;
    }
    else if (todos.Contains(inputTodo))
    {
        Console.WriteLine("The description must be unique.");
        return false;
    }
    return true;
}


void RemoveTodo(List<string> todos)
{
    if (todos.Count == 0)
    {
        NoTodoMessage();
        return;
    }

    int index;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove:");
        PrintTodos(todos);
    } while (!ValidateInputIndex(out index, todos));
    Console.WriteLine($"TODO removed: {todos[index - 1]}");
    todos.RemoveAt(index - 1);
}


bool ValidateInputIndex(out int index, List<string> todos)
{
    var inputIndex = Console.ReadLine()!;
    if (inputIndex.Length == 0)
    {
        Console.WriteLine("Selected index cannot be empty.");
        index = 0;
        return false;
    }
    if (!int.TryParse(inputIndex, out index) ||
        index < 1 ||
        index > todos.Count)
    {
        Console.WriteLine("The given index is not valid.");
        index = 0;
        return false;
    }
    return true;
}


static void NoTodoMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}
