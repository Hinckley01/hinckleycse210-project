void DisplayWelcome()
{
    Console.WriteLine("Welcome to the program!");
}

string PromptUserName()
{
    Console.Write("Please enter your name: ");
    string name = Console.ReadLine();
    return name;
}

int PromptUserNumber()
{
    Console.Write("Please enter your favorite number: ");
    int number = int.Parse(Console.ReadLine());
    return number;
}

int SquareNumber(int number)
{
    return number * number;
}

void DisplayResult(string name, int squaredNumber)
{
    Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
}

// Main program
DisplayWelcome();
string userName = PromptUserName();
int userNumber = PromptUserNumber();
int squared = SquareNumber(userNumber);
DisplayResult(userName, squared);