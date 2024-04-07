using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Text;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        private HashSet<string> conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            conqueredPeaks = new();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public int Stamina
        {
            get => stamina;
            protected set
            {
                if (value > 10)
                {
                    stamina = 10;
                }
                else if (value < 0)
                {
                    stamina = 0;
                }
                else
                {
                    stamina = value;
                }
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks;

        public void Climb(IPeak peak)
        {
            conqueredPeaks.Add(peak.Name);
            switch (peak.DifficultyLevel)
            {
                case "Extreme":
                    Stamina -= 6;
                    break;
                case "Hard":
                    Stamina -= 4;
                    break;
                case "Moderate":
                    Stamina -= 2;
                    break;
            }
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            if (conqueredPeaks.Count == 0)
            {
                sb.Append("Peaks conquered: no peaks conquered");
            }
            else
            {
                sb.Append($"Peaks conquered: {this.conqueredPeaks.Count}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
