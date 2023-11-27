using ChallengeApp;

Console.WriteLine("Welcome in XYZ program to rate employees");
Console.WriteLine();

var employee = new Employee("Greg", "Zet");

do
{
    Console.WriteLine("Insert next grade of employee: ");
    var input = Console.ReadLine();

    if (input == "q" || input == "Q")
    {
        break;
    }

    try
    {
        employee.AddGrade(input);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
} while (true);

var statistics = employee.GetStatistics();

Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");
Console.WriteLine($"Average: {statistics.Average:N2}");
Console.WriteLine($"AverageLetter: {statistics.AverageLetter}");
