Console.WriteLine("Hello!");

Console.WriteLine("Input the first number:");
int firstNumber = int.Parse(Console.ReadLine()!);

Console.WriteLine("Input the second number:");
int secondNumber = int.Parse(Console.ReadLine()!);

Console.WriteLine("What do you want to do those numbers?");
Console.WriteLine("[A]dd");
Console.WriteLine("[S]ubtract");
Console.WriteLine("[M]ultiply");
string operation = Console.ReadLine()!;

if (operation.ToLower() == "a") {
    PrintEquation(firstNumber, secondNumber, "+", firstNumber + secondNumber);
}
else if (operation.ToLower() == "s") {
    PrintEquation(firstNumber, secondNumber, "-", firstNumber - secondNumber);
}
else if (operation.ToLower() == "m") {
    PrintEquation(firstNumber, secondNumber, "*", firstNumber * secondNumber);
}
else {
    Console.WriteLine("Invalid option");
}

Console.WriteLine("Press any key to close");
Console.ReadKey();


void PrintEquation(int firstNumber, int secondNumber, string operation, int result) {
    Console.WriteLine(firstNumber + " " + operation + " " + secondNumber + " = " + result);
}
