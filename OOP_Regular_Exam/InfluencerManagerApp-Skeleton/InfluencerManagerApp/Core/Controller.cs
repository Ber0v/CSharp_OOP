using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IInfluencer> influencers;
        private readonly IRepository<ICampaign> campaigns;

        public Controller()
        {
            this.influencers = new InfluencerRepository();
            this.campaigns = new CampaignRepository();
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            // Validate influencer type
            if (typeName != nameof(BusinessInfluencer) && typeName != nameof(FashionInfluencer) && typeName != nameof(BloggerInfluencer))
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);

            // Check for duplicate registrations
            if (influencers.Models.Any(i => i.Username == username))
                return string.Format(OutputMessages.UsernameIsRegistered, username, "InfluencerRepository");

            // Create influencer based on type
            IInfluencer influencer = null;
            switch (typeName)
            {
                case nameof(BusinessInfluencer):
                    influencer = new BusinessInfluencer(username, followers);
                    break;
                case nameof(FashionInfluencer):
                    influencer = new FashionInfluencer(username, followers);
                    break;
                case nameof(BloggerInfluencer):
                    influencer = new BloggerInfluencer(username, followers);
                    break;
            }

            influencers.AddModel(influencer);
            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            // Validate campaign type
            if (typeName != nameof(ProductCampaign) && typeName != nameof(ServiceCampaign))
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);

            // Check for duplicate campaigns
            if (campaigns.Models.Any(c => c.Brand == brand))
                return string.Format(OutputMessages.CampaignDuplicated, brand);

            // Create campaign based on type
            ICampaign campaign = null;
            switch (typeName)
            {
                case nameof(ProductCampaign):
                    campaign = new ProductCampaign(brand);
                    break;
                case nameof(ServiceCampaign):
                    campaign = new ServiceCampaign(brand);
                    break;
            }

            campaigns.AddModel(campaign);
            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string AttractInfluencer(string brand, string username)
        {
            // Find influencer and campaign
            var influencer = influencers.FindByName(username);
            var campaign = campaigns.FindByName(brand);

            // Check if influencer and campaign exist
            if (influencer == null)
                return string.Format(OutputMessages.InfluencerNotFound, "InfluencerRepository", username);
            if (campaign == null)
                return string.Format(OutputMessages.CampaignNotFound, brand);

            // Check if influencer is already engaged
            if (campaign.Contributors.Contains(username))
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);

            // Check if influencer is eligible for campaign
            if (!IsInfluencerEligibleForCampaign(influencer, campaign))
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);

            // Check campaign budget
            int price = influencer.CalculateCampaignPrice();
            if (price > campaign.Budget)
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);

            // Attract influencer to campaign
            campaign.Engage(influencer);
            influencer.EnrollCampaign(brand);

            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string FundCampaign(string brand, double amount)
        {
            // Find campaign
            var campaign = campaigns.FindByName(brand);

            // Check if campaign exists
            if (campaign == null)
                return OutputMessages.InvalidCampaignToFund;

            // Validate funding amount
            if (amount <= 0)
                return OutputMessages.NotPositiveFundingAmount;

            // Fund campaign
            campaign.Gain(amount);
            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string CloseCampaign(string brand)
        {
            // Find campaign
            var campaign = campaigns.FindByName(brand);

            // Check if campaign exists
            if (campaign == null)
                return OutputMessages.InvalidCampaignToClose;

            // Check if campaign budget exceeds $10,000
            if (campaign.Budget <= 10000)
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);

            // Distribute bonuses and remove participations
            DistributeBonuses(campaign);
            RemoveParticipations(campaign);

            // Remove campaign
            campaigns.RemoveModel(campaign);
            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            // Find influencer
            var influencer = influencers.FindByName(username);

            // Check if influencer exists
            if (influencer == null)
                return string.Format(OutputMessages.InfluencerNotSigned, username);

            // Check if influencer has active participations
            if (influencer.Participations.Any())
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);

            // Remove influencer
            influencers.RemoveModel(influencer);
            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string ApplicationReport()
        {
            var report = influencers.Models.OrderByDescending(i => i.Income).ThenByDescending(i => i.Followers);
            var result = "";

            foreach (var influencer in report)
            {
                result += $"{influencer}\n";
                result += "Active Campaigns:\n";
                foreach (var brand in influencer.Participations.OrderBy(b => b))
                {
                    result += $"--{brand}\n";
                }
            }

            return result;
        }

        private bool IsInfluencerEligibleForCampaign(IInfluencer influencer, ICampaign campaign)
        {
            if (campaign.GetType() == typeof(ProductCampaign))
            {
                return influencer is BusinessInfluencer || influencer is FashionInfluencer;
            }
            else if (campaign.GetType() == typeof(ServiceCampaign))
            {
                return influencer is BusinessInfluencer || influencer is BloggerInfluencer;
            }

            return false;
        }

        private void DistributeBonuses(ICampaign campaign)
        {
            foreach (var influencerName in campaign.Contributors)
            {
                var influencer = influencers.FindByName(influencerName);
                influencer.EarnFee(2000); // Each influencer gets $2000 bonus
            }
        }

        private void RemoveParticipations(ICampaign campaign)
        {
            foreach (var influencerName in campaign.Contributors)
            {
                var influencer = influencers.FindByName(influencerName);
                influencer.EndParticipation(campaign.Brand);
            }
        }
    }
}
