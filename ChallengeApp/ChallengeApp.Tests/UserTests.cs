namespace ChallengeApp.Tests
{
    public class Tests
    {
        [Test]
        public void CheckResultOfTwoPointsUser()
        {
            var user = new User("Greg", "asbf332r");
            user.AddScore(5);
            user.AddScore(6);

            var result = user.Result;

            Assert.AreEqual(11, result);
        }
    }
}