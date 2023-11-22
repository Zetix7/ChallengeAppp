using ChallengeApp;

var employee1 = new Employee("Greg", "Zet", 30);
var employee2 = new Employee("Liz", "Olsen", 35);
var employee3 = new Employee("Natalie", "Portman", 40);

List<Employee> employees = new List<Employee>
{
    employee1,
    employee2,
    employee3
};

foreach (var employee in employees)
{
    for (int i = 0; i < 5; i++)
    {
        employee.AddGrade(new Random().Next(1, 10));
    }
}

var maxGrades = 0;
var employeeWinner = employee1;
foreach (var employee in employees)
{
    if (maxGrades < employee.Result)
    {
        maxGrades = employee.Result;
        employeeWinner = employee;
    }
}

Console.WriteLine(employeeWinner.FirstName + " " + employeeWinner.LastName + ", the highest result is: " + employeeWinner.Result);