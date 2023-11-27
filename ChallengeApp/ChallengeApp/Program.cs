using ChallengeApp;

Console.WriteLine("Welcome in XYZ program to rate employees");
Console.WriteLine();

var employee = new Employee("Greg", "Zet");

try
{
    Employee e = null;
    var firstName = e.FirstName; 
}
catch (NullReferenceException nre)
{
    Console.WriteLine(nre.Message);
}
finally
{
    Console.WriteLine("Finally here");
}

do
{
    Console.WriteLine("Insert next grade of employee: ");
    var input = Console.ReadLine();

    if (input == "q" || input == "Q")
    {
        break;
    }
    employee.AddGrade(input);
} while (true);

var statistics = employee.GetStatistics();

Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");
Console.WriteLine($"Average: {statistics.Average:N2}");
Console.WriteLine($"AverageLetter: {statistics.AverageLetter}");
