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
        var user1 = GetUser("Greg", "Psafasd");
        var user2 = user1;

        Assert.AreEqual(user1, user2);
    }

    [Test]
    public void Check2UsersAndReturn2DifferentObjects()
    {
        var user1 = GetUser("Greg", "Psafasd");
        var user2 = GetUser("Greg", "Psafasd");

        Assert.AreNotEqual(user1, user2);
    }

    private User GetUser(string login, string password)
    {
        return new User(login, password);
    }
}
