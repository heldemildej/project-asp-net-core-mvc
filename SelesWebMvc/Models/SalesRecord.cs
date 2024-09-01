using System;
namespace SelesWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SalesRecord Status { get; set; }
        public Seller Seller { get; set; } // Cada SalesRecord(registro de venda) possui um Seller(vendedor)

        //Construtor vazio
        public SalesRecord()
        {

        }

        //Construtor com argumentos
        public SalesRecord(int id, DateTime date, double amount, SalesRecord status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }

        //Construtor com argumentos


    }
}
