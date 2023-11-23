namespace ChallengeApp.Tests;

public class EmployeeTests
{
    [Test]
    public void CheckAddPositivePoints()
    {
        var employee = new Employee("Greg", "Zet", 30);
        employee.AddGrade(4);
        employee.AddGrade(7);
        employee.AddGrade(5);

        var result = employee.Result;

        Assert.AreEqual(16, result);
    }

    [Test]
    public void CheckAddNegativePoints()
    {
        var employee = new Employee("Greg", "Zet", 30);
        employee.AddGrade(-4);
        employee.AddGrade(-7);
        employee.AddGrade(-5);

        var result = employee.Result;

        Assert.AreEqual(-16, result);
    }

    [Test]
    public void CheckAddEveryPoints()
    {
        var employee = new Employee("Greg", "Zet", 30);
        employee.AddGrade(4);
        employee.AddGrade(-7);
        employee.AddGrade(0);

        var result = employee.Result;

        Assert.AreEqual(-3, result);
    }
}
