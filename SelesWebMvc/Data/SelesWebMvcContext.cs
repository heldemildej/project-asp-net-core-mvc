using Microsoft.EntityFrameworkCore;

namespace SelesWebMvc.Data
{
    public class SelesWebMvcContext : DbContext
    {
        public SelesWebMvcContext(DbContextOptions<SelesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<SelesWebMvc.Models.Department> Department { get; set; }
        
    }
}
