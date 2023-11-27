namespace ChallengeApp.Tests;

public class EmployeeTests
{
    [Test]
    public void Add3PointsAndReturnCorrectMin()
    {
        var employee = new Employee("Greg", "Zet");
        employee.AddGrade(35);
        employee.AddGrade('e');
        employee.AddGrade(63);

        var statistics = employee.GetStatistics();

        Assert.AreEqual(20, statistics.Min);
    }

    [Test]
    public void Add3PointsAndReturnCorrectMax()
    {
        var employee = new Employee("Greg", "Zet");
        employee.AddGrade('B');
        employee.AddGrade(17.77);
        employee.AddGrade(97);

        var statistics = employee.GetStatistics();

        Assert.AreEqual(97, statistics.Max);
    }

    [Test]
    public void Add3PointsAndReturnCorrectAverage()
    {
        var employee = new Employee("Greg", "Zet");
        employee.AddGrade(4);
        employee.AddGrade(6);
        employee.AddGrade(7);

        var statistics = employee.GetStatistics();

        Assert.AreEqual(Math.Round(5.67, 2), Math.Round(statistics.Average, 2));
    }

    [Test]
    public void Add3PointsAndReturnCorrectAverageLetter()
    {
        var employee = new Employee("Greg", "Zet");
        employee.AddGrade(42);
        employee.AddGrade(67);
        employee.AddGrade(77);

        var statistics = employee.GetStatistics();

        Assert.AreEqual('B', statistics.AverageLetter);
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
