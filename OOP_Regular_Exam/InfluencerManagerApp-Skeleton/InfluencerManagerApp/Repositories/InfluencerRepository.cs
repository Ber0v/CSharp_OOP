using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository : IRepository<IInfluencer>
    {
        private readonly List<IInfluencer> model;

        public InfluencerRepository()
        {
            this.model = new List<IInfluencer>();
        }

        public IReadOnlyCollection<IInfluencer> Models => model.AsReadOnly();

        public void AddModel(IInfluencer model)
        {
            this.model.Add(model);
        }

        public IInfluencer FindByName(string name)
        {
            return model.FirstOrDefault(i => i.Username == name);
        }

        public bool RemoveModel(IInfluencer model)
        {
            return this.model.Remove(model);
        }
    }
}
