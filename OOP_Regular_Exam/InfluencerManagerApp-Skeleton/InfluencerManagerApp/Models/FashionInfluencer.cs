namespace InfluencerManagerApp.Models
{
    public class FashionInfluencer : Influencer
    {
        public FashionInfluencer(string username, int followers) : base(username, followers, 4.0)
        {
        }

        public override int CalculateCampaignPrice()
        {
            const double factor = 0.1;
            return (int)(Followers * EngagementRate * factor);
        }
    }
}
