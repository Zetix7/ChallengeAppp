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

    public override void AddGrade(string grade)
    {
        if (int.TryParse(grade, out int intGrade))
        {
            AddGrade(intGrade);
        }
        else if (double.TryParse(grade, out double doubleResult))
        {
            AddGrade(doubleResult);
        }
        else if (float.TryParse(grade, out float floatResult))
        {
            AddGrade(floatResult);
        }
        else if (grade.Length == 1)
        {
            AddGrade(grade[0]);
        }
        else
        {
            throw new Exception($"ERROR: Invalid value '{grade}'! String is not float.");
        }
    }

    public override void AddGrade(int grade)
    {
        var floatGrade = (float)grade;
        AddGrade(floatGrade);
    }

    public override void AddGrade(double grade)
    {
        var floatValue = (float)grade;
        AddGrade(floatValue);
    }

    public override void AddGrade(char grade)
    {
        switch (grade)
        {
            case 'a' or 'A':
                AddGrade(100);
                break;
            case 'b' or 'B':
                AddGrade(80);
                break;
            case 'c' or 'C':
                AddGrade(60);
                break;
            case 'd' or 'D':
                AddGrade(40);
                break;
            case 'e' or 'E':
                AddGrade(20);
                break;
            default:
                throw new Exception("ERROR: Wrong grade! Input grade from 'a' to 'e'.");
        }
    }

    public override Statistics GetStatistics()
    {
        var statistics = new Statistics();

        foreach (var grade in _grades)
        {
            statistics.Max = Math.Max(statistics.Max, grade);
            statistics.Min = Math.Min(statistics.Min, grade);
            statistics.Average += grade;
        }

        statistics.Average /= _grades.Count;

        switch (statistics.Average)
        {
            case var average when average >= 80:
                statistics.AverageLetter = 'A';
                break;
            case var average when average >= 60:
                statistics.AverageLetter = 'B';
                break;
            case var average when average >= 40:
                statistics.AverageLetter = 'C';
                break;
            case var average when average >= 20:
                statistics.AverageLetter = 'D';
                break;
            default:
                statistics.AverageLetter = 'E';
                break;
        }

        return statistics;
    }
}
