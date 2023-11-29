namespace ChallengeApp;

public abstract class EmployeeBase : IEmployee
{
    public delegate void GradeAddedDelegate(object sender, EventArgs e);

    public EmployeeBase(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }
    public string LastName { get; }

    public abstract void AddGrade(float grade);

    public abstract void AddGrade(string grade);

    public abstract void AddGrade(double grade);

    public abstract void AddGrade(char grade);

    public abstract void AddGrade(int grade);

    public abstract Statistics GetStatistics();
}
