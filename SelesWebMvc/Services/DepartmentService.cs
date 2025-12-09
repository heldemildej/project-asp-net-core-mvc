using Microsoft.EntityFrameworkCore;
using SelesWebMvc.Data;
using SelesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SelesWebMvcContext _context;

        public DepartmentService(SelesWebMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department
                           .OrderBy(d => d.Name)
                           .ToList();
        }

        public async Task<ICollection<Department>> FindAllAsync()
        {
            return await _context.Department
                                 .OrderBy(d => d.Name)
                                 .ToListAsync();
        }
    }
}
