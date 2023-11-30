using System.Diagnostics;

namespace ChallengeApp;

public class EmployeeInFile : EmployeeBase
{
    private const string FILENAME = "grades.txt";

    public EmployeeInFile(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public override event GradeAddedDelegate GradeAdded;
    
    public override void AddGrade(float grade)
    {
        if (grade >= 0 && grade <= 100)
        {
            using (var writer = File.AppendText(FILENAME))
            {
                writer.WriteLine(Math.Round(grade, 2));
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }
        else
        {
            throw new Exception($"ERROR: Invalid value '{grade}'! Float must be from 0 to 100.");
        }
    }

    public override void AddGrade(string grade)
    {
        if (int.TryParse(grade, out int intNumber))
        {
            AddGrade(intNumber);
        }
        else if (double.TryParse(grade, out double doubleNumber))
        {
            AddGrade(doubleNumber);
        }
        else if (float.TryParse(grade, out float floatNumber))
        {
            AddGrade(floatNumber);
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

    public override void AddGrade(double grade)
    {
        var floatNumber = (float)grade;
        AddGrade(floatNumber);
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
                throw new Exception($"ERROR: Invalid value '{grade}'! Input grade from 'a' to 'e'.");
        }
    }

    public override void AddGrade(int grade)
    {
        var floatNumber = (float)grade;
        AddGrade(floatNumber);
    }

    public override Statistics GetStatistics()
    {
        var statistics = new Statistics();
        var grades = new List<float>();

        if (File.Exists(FILENAME))
        {
            using (var reader = File.OpenText(FILENAME))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var grade = float.Parse(line);
                    grades.Add(grade);
                    line = reader.ReadLine();
                }
            }
        }

        foreach (var grade in grades)
        {
            statistics.AddGrade(grade);
        }
        
        return statistics;
    }
}
