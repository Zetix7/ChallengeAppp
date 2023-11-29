namespace ChallengeApp;

public class EmployeeInFile : EmployeeBase
{
    private const string FILENAME = "grades.txt";

    public EmployeeInFile(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public override void AddGrade(float grade)
    {
        using(var writer = File.AppendText(FILENAME))
        {
            writer.WriteLine(grade);
        }
    }

    public override void AddGrade(string grade)
    {
        throw new NotImplementedException();
    }

    public override void AddGrade(double grade)
    {
        throw new NotImplementedException();
    }

    public override void AddGrade(char grade)
    {
        throw new NotImplementedException();
    }

    public override void AddGrade(int grade)
    {
        throw new NotImplementedException();
    }

    public override Statistics GetStatistics()
    {
        throw new NotImplementedException();
    }
}
