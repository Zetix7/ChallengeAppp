namespace ChallengeApp;

public interface IEmployee
{
    string FirstName { get; }
    string LastName { get; }

    void AddGrade(float grade);
    void AddGrade(string grade);
    void AddGrade(double grade);
    void AddGrade(char grade);
    void AddGrade(int grade);
    Statistics GetStatistics();
}
