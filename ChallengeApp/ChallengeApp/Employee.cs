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
            statistics.Max = Math.Max(statistics.Max, grade);
            statistics.Min = Math.Min(statistics.Min, grade);
            statistics.Average += grade;
        }
        
        statistics.Average /= _grades.Count;
        return statistics;
    }

    public Statistics GetStatisticsWithFor()
    {
        var statistics = new Statistics();
        statistics.Average = 0;
        statistics.Max = 0;
        statistics.Min = 100;

        for(var i = 0; i < _grades.Count; i++)
        {
            statistics.Average += _grades[i];
            statistics.Max = Math.Max(statistics.Max, _grades[i]);
            statistics.Min = Math.Min(statistics.Min, _grades[i]);
        }

        statistics.Average /= _grades.Count;
        return statistics;
    }

    public Statistics GetStatisticsWithDoWhile()
    {
        var statistics = new Statistics();
        statistics.Average = 0;
        statistics.Max = 0;
        statistics.Min = 100;

        var index = 0;
        do
        {
            statistics.Average += _grades[index];
            statistics.Max = Math.Max(statistics.Max, _grades[index]);
            statistics.Min = Math.Min(statistics.Min, _grades[index]);
            index++;
        } while (index < _grades.Count);

        statistics.Average /= _grades.Count;
        return statistics;
    }

    public Statistics GetStatisticsWithWhile()
    {
        var statistics = new Statistics();
        statistics.Average = 0;
        statistics.Max = 0;
        statistics.Min = 100;

        var index = 0;
        while (index < _grades.Count)
        {
            statistics.Average += _grades[index];
            statistics.Max = Math.Max(statistics.Max, _grades[index]);
            statistics.Min = Math.Min(statistics.Min, _grades[index]);
            index++;
        } 

        statistics.Average /= _grades.Count;
        return statistics;
    }
}
