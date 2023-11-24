namespace ChallengeApp.Tests;

public class TypeTests
{
    [Test]
    public void Check2DoublesAndReturnSameValues()
    {
        var pi1 = Math.PI;
        var pi2 = pi1;

        Assert.AreEqual(pi1, pi2);
    }

    [Test]
    public void Check2StringsAndReturnSameValues()
    {
        var name1 = "Greg";
        var name2 = "Greg";

        Assert.AreEqual(name1, name2);
    }

    [Test]
    public void Check2IntegersAndReturn2DifferentValues()
    {
        var number1 = 1;
        var number2 = 2;

        Assert.AreNotEqual(number1, number2);
    }

    [Test]
    public void Check2UsersAndReturnSameObjects()
    {
        var employee1 = GetEmployee("Greg", "Zet");
        var employee2 = employee1;

        Assert.AreEqual(employee1, employee2);
    }

    [Test]
    public void Check2UsersAndReturn2DifferentObjects()
    {
        var employee1 = GetEmployee("Greg", "Zet");
        var employee2 = GetEmployee("Greg", "Zet");

        Assert.AreNotEqual(employee1, employee2);
    }

    private Employee GetEmployee(string firstName, string lastName)
    {
        return new Employee(firstName, lastName);
    }
}
