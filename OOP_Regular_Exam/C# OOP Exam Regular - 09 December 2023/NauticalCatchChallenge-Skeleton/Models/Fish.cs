using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        private string name;
        private double points;
        private int timeToCatch;

        public Fish(string name, double points, int timeToCatch)
        {
            this.Name = name;
            this.Points = points;
            this.TimeToCatch = timeToCatch;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.FishNameNull);
                }
                this.name = value;
            }
        }

        public double Points
        {
            get { return points; }
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentNullException(ExceptionMessages.PointsNotInRange);
                }
                points = value;
            }
        }

        public int TimeToCatch
        {
            get { return timeToCatch; }
            private set { timeToCatch = value; }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }
    }
}
