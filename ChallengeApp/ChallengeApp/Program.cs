using ChallengeApp;

var employee = new Employee("Greg", "Zet");
employee.AddGrade(2);
employee.AddGrade(2);
employee.AddGrade(7);
employee.AddGrade(6.456789987);
employee.AddGrade(1.986);
employee.AddGrade("4,1237");
employee.AddGrade("7,45677994566");
employee.AddGrade("687");
employee.AddGrade("test");
var statistics = employee.GetStatistics();
Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");
Console.WriteLine($"Average: {statistics.Average:N2}");
