namespace InfluencerManagerApp.Models
{
    public class BusinessInfluencer : Influencer
    {
        public BusinessInfluencer(string username, int followers) : base(username, followers, 3.0)
        {
        }

        public override int CalculateCampaignPrice()
        {
            const double factor = 0.15;
            return (int)(Followers * EngagementRate * factor);
        }
    }
}
