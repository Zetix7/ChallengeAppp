namespace ChallengeApp;

public class EmployeeInMemory : EmployeeBase
{
     private readonly List<float> _grades = new();

    public EmployeeInMemory(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public override event GradeAddedDelegate GradeAdded;

    public override void AddGrade(float grade)
    {
        if (grade >= 0 && grade <= 100)
        {
            _grades.Add((float)Math.Round(double.Parse(grade.ToString()), 2));
            if(GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }
        else
        {
            throw new Exception($"ERROR: Invalid value '{grade}'! Float must be from 0 to 100.");
        }
    }

    public override Statistics GetStatistics()
    {
        var statistics = new Statistics();

        foreach (var grade in _grades)
        {
            statistics.AddGrade(grade);
        }

        return statistics;
    }
}
