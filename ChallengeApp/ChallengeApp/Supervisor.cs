using static ChallengeApp.EmployeeBase;

namespace ChallengeApp;

public class Supervisor : EmployeeBase
{
    private readonly List<float> _grades = new();
    public override event GradeAddedDelegate GradeAdded;

    public Supervisor(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public override void AddGrade(float grade)
    {
        if (grade >= 0 && grade <= 100)
        {
            _grades.Add(grade);
        }
    }

    public override void AddGrade(string grade)
    {
        if (grade.Length < 3 && (char.IsDigit(grade[0]) && grade.Length == 1 || (grade.Contains('-') || grade.Contains('+'))))
        {
            switch (grade)
            {
                case "6":
                    AddGrade(100);
                    break;
                case "-6" or "6-":
                    AddGrade(95);
                    break;
                case "+5" or "5+":
                    AddGrade(85);
                    break;
                case "5":
                    AddGrade(80);
                    break;
                case "-5" or "5-":
                    AddGrade(75);
                    break;
                case "+4" or "4+":
                    AddGrade(65);
                    break;
                case "4":
                    AddGrade(60);
                    break;
                case "-4" or "4-":
                    AddGrade(55);
                    break;
                case "+3" or "3+":
                    AddGrade(45);
                    break;
                case "3":
                    AddGrade(40);
                    break;
                case "-3" or "3-":
                    AddGrade(35);
                    break;
                case "+2" or "2+":
                    AddGrade(25);
                    break;
                case "2":
                    AddGrade(20);
                    break;
                case "-2" or "2-":
                    AddGrade(15);
                    break;
                case "+1" or "1+":
                    AddGrade(5);
                    break;
                case "1":
                    AddGrade(0);
                    break;
                default:
                    throw new Exception("ERROR: Wrong grade! Accepted range 1 to 6 also can use '+' or '-'.\n\tYou can add numbers 0 to 9 as grades - before number insert space. Example: ' 7' -> new grade added '7'.");
            }
        }
        else
        {
            if (int.TryParse(grade, out int intGrade))
            {
                AddGrade(intGrade);
            }
            else if (double.TryParse(grade, out double doubleGrade))
            {
                AddGrade(doubleGrade);
            }
            else if (float.TryParse(grade, out float floatGrade))
            {
                AddGrade(floatGrade);
            }
            else if (grade.Length == 1)
            {
                AddGrade(grade[0]);
            }
            else
            {
                throw new Exception($"ERROR: Wrong grade '{grade}'! String is not float.");
            }
        }
    }

    public override void AddGrade(int grade)
    {
        var floatGrade = (float)grade;
        AddGrade(floatGrade);
    }

    public override void AddGrade(double grade)
    {
        var floatGrade = (float)grade;
        AddGrade(floatGrade);
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

        foreach (var grade in _grades)
        {
            statistics.Min = Math.Min(statistics.Min, grade);
            statistics.Max = Math.Max(statistics.Max, grade);
            statistics.Average += grade;
        }

        statistics.Average /= _grades.Count;

        switch (statistics.Average)
        {
            case var average when average >= 80:
                statistics.Average = 'A';
                break;
            case var average when average >= 60:
                statistics.Average = 'B';
                break;
            case var average when average >= 40:
                statistics.Average = 'C';
                break;
            case var average when average >= 20:
                statistics.Average = 'D';
                break;
            default:
                statistics.Average = 'E';
                break;
        }
        return statistics;
    }
}
