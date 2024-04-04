namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private static int baseOxygen = 540;
        public ScubaDiver(string name) : base(name, baseOxygen)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.3, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = baseOxygen;
        }
    }
}
