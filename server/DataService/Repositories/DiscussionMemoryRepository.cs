using DataService.Models;

namespace DataService.Repositories
{
    public class DiscussionMemoryRepository : MemoryRepository<Discussion>
    {
        public DiscussionMemoryRepository(DiscussionContext context) : base(context) { }
    }
}
