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
