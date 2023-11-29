namespace ChallengeApp;

public class EmployeeInFile : EmployeeBase
{
    private const string FILENAME = "grades.txt";

    public EmployeeInFile(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public override void AddGrade(float grade)
    {
        using (var writer = File.AppendText(FILENAME))
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
        var statistics = new Statistics();
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
