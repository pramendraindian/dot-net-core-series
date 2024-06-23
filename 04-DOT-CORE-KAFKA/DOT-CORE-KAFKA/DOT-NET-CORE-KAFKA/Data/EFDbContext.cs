using DOT_NET_CORE_KAFKA.Models;
using Microsoft.EntityFrameworkCore;

namespace DOT_NET_CORE_KAFKA.Data
{
    public class EFDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public EFDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultSQLServer"));
        }

        public DbSet<ProductDetails> Products { get; set; }
    }
}
