﻿namespace ChallengeApp;

public class EmployeeInMemory : EmployeeBase
{
    public delegate void WriteMessage(string message);
    private readonly List<float> _grades = new();

    public EmployeeInMemory(string firstName, string lastName) : base(firstName, lastName)
    {
        WriteMessage d = WriteMessageToLowerCase;
        d += WriteMessageToUpperCase;
        d -= WriteMessageToLowerCase;
        d($"{firstName} {lastName}");
        Console.WriteLine($"{firstName} {lastName}");
    }

    private void WriteMessageToLowerCase(string message)
    {
        Console.WriteLine(message.ToLower());
    }

    private void WriteMessageToUpperCase(string message)
    {
        Console.WriteLine(message.ToUpper());
    }

    public override void AddGrade(float grade)
    {
        if (grade >= 0 && grade <= 100)
        {
            _grades.Add(grade);
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
        var floatGrade = grade;
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
                throw new Exception("ERROR: Wrong grade! Input grade from 'a' to 'e'.");
        }
    }

    public override Statistics GetStatistics()
    {
        var statistics = new Statistics();
        statistics.Average = 0;
        statistics.Max = 0;
        statistics.Min = 100;
        statistics.AverageLetter = 'X';

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
