using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository : IRepository<ICampaign>
    {
        private readonly List<ICampaign> model;

        public CampaignRepository()
        {
            this.model = new List<ICampaign>();
        }

        public IReadOnlyCollection<ICampaign> Models => model.AsReadOnly();

        public void AddModel(ICampaign model)
        {
            this.model.Add(model);
        }

        public ICampaign FindByName(string name)
        {
            return this.model.FirstOrDefault(c => c.Brand == name);
        }

        public bool RemoveModel(ICampaign model)
        {
            return this.model.Remove(model);
        }
    }
}
