Console.WriteLine("Hello!");
Console.WriteLine("What do you want to do?");
Console.WriteLine("[S]ee all TODOs");
Console.WriteLine("[A]dd a TODO");
Console.WriteLine("[R]emove a TODO");
Console.WriteLine("[E]xit");

var userChoice = Console.ReadLine()!;
bool isLong = IsLong(userChoice);

if (userChoice == "S") {
    PrintSelectedOption("See all TODOs");
}
else if (userChoice == "A") {
    PrintSelectedOption("Add a TODO");
}
else if (userChoice == "R") {
    PrintSelectedOption("Remove a TODO");
}
else if (userChoice == "E") {
    PrintSelectedOption("Exit");
}


void PrintSelectedOption(string selectedOption) {
    Console.WriteLine("Selected option: " + selectedOption);
}

bool IsLong(string input) {
    return input.Length > 10;
}
