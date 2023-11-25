using System.Diagnostics;

namespace ChallengeApp;

public class Employee
{
    private List<float> _grades = new();

    public Employee(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }
    public string LastName { get; }

    public void AddGrade(float grade)
    {
        if (grade >= 0 && grade <= 100)
        {
            _grades.Add(grade);
        }
        else
        {
            Console.WriteLine($"ERROR: Invalid value '{grade}'! Float must be from 0 to 100.");
        }
    }

    public void AddGrade(string grade)
    {
        if (double.TryParse(grade, out double doubleResult))
        {
            AddGrade(doubleResult);
        }
        else if (float.TryParse(grade, out float floatResult))
        {
            AddGrade(floatResult);
        }
        else
        {
            Console.WriteLine($"ERROR: Invalid value '{grade}'! String is not double or float.");
        }
    }

    public void AddGrade(double grade)
    {
        var floatValue = (float)grade;
        AddGrade(floatValue);
    }

    public Statistics GetStatistics()
    {
        var statistics = new Statistics();
        statistics.Average = 0;
        statistics.Max = 0;
        statistics.Min = 100;

        foreach (var grade in _grades)
        {
            if (grade == 7)
            {
                Console.WriteLine("Number 7 is always skip and does not part of this statistic.");
                continue;
            }

            statistics.Max = Math.Max(statistics.Max, grade);
            statistics.Min = Math.Min(statistics.Min, grade);
            statistics.Average += grade;
        }

        statistics.Average /= _grades.Count;
        return statistics;
    }
}
