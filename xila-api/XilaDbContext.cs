using Microsoft.EntityFrameworkCore;
using xila_api.Models.Db;

namespace xila_api
{
    public class XilaDbContext : DbContext
    {
        public DbSet<GeneratedKeyRecord> GeneratedKeyRecords { get; set; }
        public XilaDbContext(DbContextOptions<XilaDbContext> options) : base(options) { }
    }
}
