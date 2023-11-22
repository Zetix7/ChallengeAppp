namespace ChallengeApp
{
    public class User
    {
        private List<int> _scores = new List<int>();

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; private set; }
        public string Password { get; private set; }
        public int Result
        {
            get
            {
                return _scores.Sum();
            }
        }

        public void AddScore(int score)
        {
            _scores.Add(score);
        }
    }
}
