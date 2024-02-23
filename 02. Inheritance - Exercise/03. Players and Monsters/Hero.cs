namespace PlayersAndMonsters
{
    public class Hero
    {
        private string Username;
        private int Level;
        public Hero(string username, int level)
        {
            Username = username;
            Level = level;
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }

    }
}
