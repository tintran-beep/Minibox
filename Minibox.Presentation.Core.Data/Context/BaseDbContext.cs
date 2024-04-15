using Microsoft.EntityFrameworkCore;

namespace Minibox.Presentation.Core.Data.Context
{
    public class BaseDbContext(DbContextOptions options) : DbContext(options)
    {
    }
}
