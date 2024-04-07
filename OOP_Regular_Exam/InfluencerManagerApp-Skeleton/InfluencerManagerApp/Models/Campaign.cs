using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public class Campaign : ICampaign
    {
        private string brand;
        private double budget;
        private readonly List<string> contributors;

        public Campaign(string brand, double budget)
        {
            this.Brand = brand;
            this.Budget = budget;
            contributors = new List<string>();
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.BrandIsrequired);
                }
                this.brand = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set => budget = value;
        }

        public IReadOnlyCollection<string> Contributors => contributors.AsReadOnly();

        public void Engage(IInfluencer influencer)
        {
            var price = influencer.CalculateCampaignPrice();
            contributors.Add(influencer.Username);
            Budget -= price;
            influencer.EarnFee(price);
        }

        public void Gain(double amount)
        {
            Budget += amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {Contributors.Count}";
        }
    }
}
