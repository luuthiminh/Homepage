using System;
using System.ComponentModel.DataAnnotations;

namespace Homepage.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        public string Customer { get; set; }
        public DateTime Date { get; set; }
   
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
