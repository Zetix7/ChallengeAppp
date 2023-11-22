namespace ChallengeApp;

public class Employee
{
    private int _age;
    private List<int> _grades = new();

    public Employee(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        _age = age;
    }
    public string FirstName { get; }
    public string LastName { get; }

    public int Result
    {
        get
        {
            return _grades.Sum();
        }
    }

    public void AddGrade(int grade)
    {
        _grades.Add(grade);
    }
}
