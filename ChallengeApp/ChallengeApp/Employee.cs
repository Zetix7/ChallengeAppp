namespace ChallengeApp;

public class Employee
{
    private int _age;
    private List<int> _positiveGrades = new() { 0 };
    private List<int> _negativeGrades = new() { 0 };

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
            return _positiveGrades.Sum() + _negativeGrades.Sum();
        }
    }

    public void AddGrade(int grade)
    {
        if (grade > 0)
        {
            _positiveGrades.Add(grade);
        }
        else
        {
            _negativeGrades.Add(grade);
        }
    }
}
