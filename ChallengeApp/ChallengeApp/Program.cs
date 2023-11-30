using ChallengeApp;

Console.WriteLine("Welcome in XYZ program to rate employees");
Console.WriteLine();

Console.Write("Choose saving grades: \n\t1 - to memory, \n\t2 - to file grades.txt \nYour choise: ");
var choise = Console.ReadLine();
do
{

    if (choise == "1")
    {
        var employee = new EmployeeInMemory("Greg", "Zet");
        employee.GradeAdded += EmployeeGradeAdded;
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
        break;
    }
    else if (choise == "2")
    {
        var employee = new EmployeeInFile("Greg", "Zet");
        employee.GradeAdded += EmployeeGradeAdded;
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
        break;
    }
    else
    {
        Console.Write("\tChoose 1 - memory or 2 - file. \nYour choise: ");
        choise = Console.ReadLine();
    }
} while (choise.Trim() != "1" || choise.Trim() != "2");

void EmployeeGradeAdded(object sender, EventArgs e)
{
    Console.WriteLine("New grade added.");
}
