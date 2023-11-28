namespace ChallengeApp;

public abstract class Person
{
    public Person(string firstName)
    {
        FirstName = firstName;
    }

    public string FirstName { get; }
}
