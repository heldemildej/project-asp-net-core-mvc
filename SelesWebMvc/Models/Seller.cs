using System;
using System.Collections.Generic; // using System.Collections.Generic;
using System.Linq; // using System.Linq;

namespace SelesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; } // Cada Seller(vendedor) possui um Department(departamento)
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); // Associação do Seller com o SalesRecord

        //Construtor vazio
        public Seller()
        {

        }

        //Construtor com argumentos
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        //Adicionar venda
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        // Remover venda
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        // Total de venda em um determinado intervalo de data
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
