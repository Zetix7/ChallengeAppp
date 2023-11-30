namespace ChallengeApp;

public abstract class EmployeeBase : IEmployee
{
    public delegate void GradeAddedDelegate(object sender, EventArgs e);
    public abstract event GradeAddedDelegate GradeAdded;

    public EmployeeBase(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }
    public string LastName { get; }

    public abstract void AddGrade(float grade);

    public void AddGrade(string grade)
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
        else if (grade.Trim().Length == 1)
        {
            AddGrade(grade[0]);
        }
        else
        {
            throw new Exception($"ERROR: Invalid value '{grade}'! String is not float.");
        }
    }

    public void AddGrade(int grade)
    {
        var floatGrade = (float)grade;
        AddGrade(floatGrade);
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
                throw new Exception("ERROR: Wrong grade! Input grade from 'a' to 'e'.");
        }
    }

    public abstract Statistics GetStatistics();
}
