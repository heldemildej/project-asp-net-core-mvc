using System.Collections.Generic;
using System.Linq;
using SelesWebMvc.Data;
using SelesWebMvc.Models;

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
            return _context.Department.OrderBy(d => d.Name).ToList();
        }
    }
}
