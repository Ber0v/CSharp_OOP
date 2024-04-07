using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        private SortedSet<string> residents;

        public BaseCamp()
        {
            residents = new SortedSet<string>();
        }

        public IReadOnlyCollection<string> Residents => residents;

        public void ArriveAtCamp(string climberName)
        {
            residents.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            residents.Remove(climberName);
        }
    }
}
