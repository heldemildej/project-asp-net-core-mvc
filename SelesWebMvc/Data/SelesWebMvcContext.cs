using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelesWebMvc.Models;

namespace SelesWebMvc.Data
{
    public class SelesWebMvcContext : DbContext
    {
        public SelesWebMvcContext (DbContextOptions<SelesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<SelesWebMvc.Models.Department> Department { get; set; }
    }
}
