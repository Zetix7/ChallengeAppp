using ChallengeApp;

Console.WriteLine("Welcome in XYZ program to rate employees");
Console.WriteLine();
Console.WriteLine("Insert grade of employee: ");
var employee = new Employee("Greg", "Zet");

var input = Console.ReadLine();
employee.AddGrade(input);

while (true)
{
    Console.WriteLine("Insert next grade of employee: ");
    input = Console.ReadLine();

    if(input == "q" || input == "Q")
    {
        break;
    }
    employee.AddGrade(input);
}


var statistics = employee.GetStatistics();

Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");
Console.WriteLine($"Average: {statistics.Average:N2}");
Console.WriteLine($"AverageLetter: {statistics.AverageLetter}");
