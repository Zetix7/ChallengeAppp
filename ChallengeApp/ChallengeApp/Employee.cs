﻿using System.Diagnostics;

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

    public void AddGrade(char grade)
    {
        switch (grade)
        {
            case 'a' or 'A':
                _grades.Add(100);
                break;
            case 'b' or 'B':
                _grades.Add(80);
                break;
            case 'c' or 'C':
                _grades.Add(60);
                break;
            case 'd' or 'D':
                _grades.Add(40);
                break;
            case 'e' or 'E':
                _grades.Add(20);
                break;
            default:
                Console.WriteLine("ERROR: Wrong grade! Input grade from 'a' to 'e'.");
                break;
        }
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
}
