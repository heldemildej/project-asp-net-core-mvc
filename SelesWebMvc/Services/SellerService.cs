using SelesWebMvc.Data;
using SelesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    }
}
