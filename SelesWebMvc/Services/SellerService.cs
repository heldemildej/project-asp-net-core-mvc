using SelesWebMvc.Data;
using SelesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore; 
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
            _context.Add(obj);
            _context.SaveChanges();
        }

          public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller
                .Include(s => s.Department) 
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }


    }
}
