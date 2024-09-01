using System; //using System;
using System.Collections.Generic; // using System.Collections.Generic;
using System.Linq;
namespace SelesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller> (); // Associação do Department com o Seller

        //Construtor vazio 
        public Department()
        {

        }

        //Construtor com argumentos
        public Department(int id, string name)
        {
            id = Id;
            name = Name;
        }

        // Adicionar vendedor
        public void AddSaller(Seller seller)
        {
            Sellers.Add(seller);
        }

        // Total de vendas do Department em um determinado intervalo de data
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
