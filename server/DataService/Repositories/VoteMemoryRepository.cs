using DataService.Models;

namespace DataService.Repositories
{
    public class VoteMemoryRepository : MemoryRepository<Vote>
    {
        public VoteMemoryRepository(VoteContext context) : base(context) { }
    }
}
