using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository : IRepository<IClimber>
    {
        private HashSet<IClimber> clibers;

        public ClimberRepository(HashSet<IClimber> clibers)
        {
            this.clibers = clibers;
        }

        public IReadOnlyCollection<IClimber> All => clibers;

        public void Add(IClimber model)
        {
            clibers.Add(model);
        }

        public IClimber Get(string name)
        {
            return clibers.FirstOrDefault(c => c.Name == name);
        }
    }
}
