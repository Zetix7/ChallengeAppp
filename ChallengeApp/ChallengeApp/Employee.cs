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

        var index = 0;
        while (index < _grades.Count)
        {
            if (_grades[index] == 7)
            {
                break;
            }

            statistics.Max = Math.Max(statistics.Max, _grades[index]);
            statistics.Min = Math.Min(statistics.Min, _grades[index]);
            statistics.Average += _grades[index];
            index++;
        }

        statistics.Average /= _grades.Count;
        return statistics;
    }
}
