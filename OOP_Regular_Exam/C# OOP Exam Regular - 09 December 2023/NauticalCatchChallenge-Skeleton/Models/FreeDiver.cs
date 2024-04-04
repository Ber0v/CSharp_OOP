namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private static int baseOxygen = 120;
        public FreeDiver(string name) : base(name, baseOxygen)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.6, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = baseOxygen;
        }
    }
}
