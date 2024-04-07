namespace InfluencerManagerApp.Models
{
    public class BloggerInfluencer : Influencer
    {
        public BloggerInfluencer(string username, int followers) : base(username, followers, 2.0)
        {
        }

        public override int CalculateCampaignPrice()
        {
            const double factor = 0.2;
            return (int)(Followers * EngagementRate * factor);
        }
    }
}
