namespace ChallengeApp.Tests;

public class UserTests
{
    [Test]
    public void CheckResultOfTwoPointsForUser()
    {
        var user = new User("Greg", "asbf332r");
        user.AddScore(5);
        user.AddScore(6);

        var result = user.Result;

        Assert.AreEqual(11, result);
    }
}