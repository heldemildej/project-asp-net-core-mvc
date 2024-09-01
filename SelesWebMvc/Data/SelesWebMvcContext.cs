using Microsoft.EntityFrameworkCore;

namespace SelesWebMvc.Data
{
    public class SelesWebMvcContext : DbContext
    {
        public SelesWebMvcContext(DbContextOptions<SelesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Department> Department { get; set; }
        public DbSet<Models.Seller> Seller { get; set; }
        public DbSet<Models.SalesRecord> SalesRecord { get; set; }
        
    }
}
