using Microsoft.EntityFrameworkCore;

namespace Minibox.Presentation.Core.Data.Context.Main
{
    public class MainDbContext(DbContextOptions options) : BaseDbContext(options)
    {
    }
}
