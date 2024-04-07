using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        private HashSet<IPeak> peaks;

        public PeakRepository(HashSet<IPeak> peaks)
        {
            this.peaks = peaks;
        }

        public IReadOnlyCollection<IPeak> All => peaks;

        public void Add(IPeak model)
        {
            peaks.Add(model);
        }

        public IPeak Get(string name)
        {
            return peaks.FirstOrDefault(p => p.Name == name);
        }
    }
}
