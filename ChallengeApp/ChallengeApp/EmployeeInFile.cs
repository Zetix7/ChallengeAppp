namespace ChallengeApp;

public class EmployeeInFile : EmployeeBase
{
    public event GradeAddedDelegate GradeAdded;
    private const string FILENAME = "grades.txt";

    public EmployeeInFile(string firstName, string lastName) : base(firstName, lastName)
    {
    }

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
        statistics.Min = 100;
        statistics.Max = 0;
        statistics.Average = 0;
        statistics.AverageLetter = 'X';
        var counter = 0;
        
        if (File.Exists(FILENAME))
        {
            using (var reader = File.OpenText(FILENAME))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var grade = float.Parse(line);
                    statistics.Min = Math.Min(statistics.Min, grade);
                    statistics.Max = Math.Max(statistics.Max, grade);
                    statistics.Average += grade;
                    line = reader.ReadLine();
                    counter++;
                }
            }
        }
        statistics.Average /= counter;

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
