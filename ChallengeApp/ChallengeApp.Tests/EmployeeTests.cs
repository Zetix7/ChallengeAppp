namespace ChallengeApp.Tests;

public class EmployeeTests
{
    [Test]
    public void Add3PointsAndCheckCorrectStatistics()
    {
        var employee = new Employee("Greg", "Zet");
        employee.AddGrade(4);
        employee.AddGrade(7);
        employee.AddGrade(6);
        
        employee.GetStatistics(out Statistics statistics);

        Assert.AreEqual(7, statistics.Max);
        Assert.AreEqual(4, statistics.Min);
        Assert.AreEqual(Math.Round(5.67, 2), Math.Round(statistics.Average, 2));
    }

    [Test]
    public void Check2DifferentEmployees()
    {
        var employee1 = new Employee("Chris", "Evans");
        
        var employee2 = GetEmployee(employee1);
        
        Assert.AreNotEqual(employee2, employee1);
    }

    [Test]
    public void Check2DifferentEmployeesByRef()
    {
        var employee = new Employee("Chris", "Evans");

        var employeeByRef = GetEmployeeByRef(ref employee);

        Assert.AreEqual(employeeByRef, employee);
    }

    [Test]
    public void Check2DifferentEmployeesByOut()
    {
        var employee = new Employee("Chris", "Evans");

        var employeeByOut = GetEmployeeByOut(out employee);

        Assert.AreEqual(employeeByOut, employee);
    }

    private Employee GetEmployee(Employee employee)
    {
        employee = new Employee("Chris", "Evans");
        return employee;
    }

    private Employee GetEmployeeByRef(ref Employee employee)
    {
        employee = new Employee("Liz", "Olsen");
        return employee;
    }

    private Employee GetEmployeeByOut(out Employee employee)
    {
        employee = new Employee("Natalie", "Portman");
        return employee;
    }
}
