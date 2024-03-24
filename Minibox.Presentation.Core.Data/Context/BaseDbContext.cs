using Microsoft.EntityFrameworkCore;

namespace Minibox.Presentation.Core.Data.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
