Random random = new Random();
int magicNumber = random.Next(1, 101);

int guess = 0;

while (guess != magicNumber)
{
    Console.Write("What is your guess? ");
    string input = Console.ReadLine();
    guess = int.Parse(input);

    if (guess < magicNumber)
    {
        Console.WriteLine("Higher");
    }
    else if (guess > magicNumber)
    {
        Console.WriteLine("Lower");
    }
    else
    {
        Console.WriteLine("You guessed it!");
    }
}