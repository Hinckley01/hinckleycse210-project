List<double> numbers = new List<double>();

Console.WriteLine("Enter a list of numbers, type 0 when finished.");

double input = -1;
while (input != 0)
{
    Console.Write("Enter number: ");
    input = double.Parse(Console.ReadLine());

    if (input != 0)
    {
        numbers.Add(input);
    }
}

// Sum
double sum = 0;
foreach (double number in numbers)
{
    sum += number;
}
Console.WriteLine($"The sum is: {sum}");

// Average
double average = sum / numbers.Count;
Console.WriteLine($"The average is: {average}");

// Largest number
double largest = numbers[0];
foreach (double number in numbers)
{
    if (number > largest)
    {
        largest = number;
    }
}
Console.WriteLine($"The largest number is: {largest}");