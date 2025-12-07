using System;
using System.Linq;
using SelesWebMvc.Models;
using SelesWebMvc.Models.Enums;

namespace SelesWebMvc.Data
{
    public class SeedingService
    {
        private readonly SelesWebMvcContext _context;

        public SeedingService(SelesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // Verifica se já existem dados no banco
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // Banco já foi populado
            }

            // Cria departamentos
            Department d1 = new Department { Name = "Computers" };
            Department d2 = new Department { Name = "Electronics" };
            Department d3 = new Department { Name = "Fashion" };
            Department d4 = new Department { Name = "Books" };

            // Salva departamentos primeiro para garantir IDs gerados
            _context.Department.AddRange(d1, d2, d3, d4);
            _context.SaveChanges();

            // Cria vendedores associando departamentos já salvos
            Seller s1 = new Seller { Name = "Bob Brown", Email = "bob@gmail.com", BirthDate = new DateTime(1998, 4, 21), BaseSalary = 1000.0, Department = d1 };
            Seller s2 = new Seller { Name = "Maria Green", Email = "maria@gmail.com", BirthDate = new DateTime(1979, 12, 31), BaseSalary = 3500.0, Department = d2 };
            Seller s3 = new Seller { Name = "Alex Grey", Email = "alex@gmail.com", BirthDate = new DateTime(1988, 1, 15), BaseSalary = 2200.0, Department = d1 };
            Seller s4 = new Seller { Name = "Martha Red", Email = "martha@gmail.com", BirthDate = new DateTime(1993, 11, 30), BaseSalary = 3000.0, Department = d4 };
            Seller s5 = new Seller { Name = "Donald Blue", Email = "donald@gmail.com", BirthDate = new DateTime(2000, 1, 9), BaseSalary = 4000.0, Department = d3 };
            Seller s6 = new Seller { Name = "Alex Pink", Email = "pink@gmail.com", BirthDate = new DateTime(1997, 3, 4), BaseSalary = 3000.0, Department = d2 };

            // Salva vendedores
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SaveChanges();

            // Cria e salva registros de vendas
            SalesRecord r1 = new SalesRecord { Date = new DateTime(2025, 09, 25), Amount = 11000.0, Status = SaleStatus.Billed, Seller = s1 };
            SalesRecord r2 = new SalesRecord { Date = new DateTime(2025, 09, 11), Amount = 7000.0, Status = SaleStatus.Billed, Seller = s5 };
            SalesRecord r3 = new SalesRecord { Date = new DateTime(2025, 09, 12), Amount = 4000.0, Status = SaleStatus.Cancelled, Seller = s4 };
            SalesRecord r4 = new SalesRecord { Date = new DateTime(2025, 09, 13), Amount = 8000.0, Status = SaleStatus.Billed, Seller = s1 };
            SalesRecord r5 = new SalesRecord { Date = new DateTime(2025, 09, 14), Amount = 3000.0, Status = SaleStatus.Billed, Seller = s3 };
            SalesRecord r6 = new SalesRecord { Date = new DateTime(2025, 09, 15), Amount = 2000.0, Status = SaleStatus.Billed, Seller = s2 };

            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6);
            _context.SaveChanges();

        }
    }
}
