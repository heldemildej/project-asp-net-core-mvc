using SelesWebMvc.Data;
using SelesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SelesWebMvc.Services
{
    public class SellerService
    {
        private readonly SelesWebMvcContext _context;

        public SellerService(SelesWebMvcContext context)
        {
            _context = context;
        }

        // Método FindAll: retorna todos os vendedores com seus departamentos
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller
                                 .Include(s => s.Department)
                                 .ToListAsync();
        }

        // Inserir um novo vendedor no banco de dados
        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First(); // forçar 1º departamento
            _context.Add(obj);
            _context.SaveChanges();
        }


    }
}
