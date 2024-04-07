using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private string username;
        private int followers;
        private double engagementRate;
        private double income;
        private readonly List<string> participations;

        public Influencer(string username, int followers, double engagementRate)
        {
            this.Username = username;
            this.Followers = followers;
            this.engagementRate = engagementRate;
            income = 0;
            participations = new List<string>();
        }

        public string Username
        {
            get => username;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.UsernameIsRequired);
                }
                this.username = value;
            }
        }

        public int Followers
        {
            get => followers;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException(ExceptionMessages.FollowersCountNegative);
                }
                this.followers = value;
            }
        }

        public double EngagementRate => engagementRate;

        public double Income => income;

        public IReadOnlyCollection<string> Participations => participations.AsReadOnly();

        public abstract int CalculateCampaignPrice();

        public void EarnFee(double amount)
        {
            income += amount;
        }

        public void EndParticipation(string brand)
        {
            participations.Remove(brand);
        }

        public void EnrollCampaign(string brand)
        {
            participations.Add(brand);
        }

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }
    }
}
