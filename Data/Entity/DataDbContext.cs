using Microsoft.EntityFrameworkCore;

namespace DM.Data.Entity
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }

        public DbSet<Exhibit> Exhibits { get; set; }
    }
}
