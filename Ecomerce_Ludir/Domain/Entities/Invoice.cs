using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Invoice
    {
        public Guid InvoiceId { get; set; }
        public List<Product> Products { get; set; }
        public float TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }

        // Relación con carrito
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        // Relación con User (Client o Company)
        public User User { get; set; }
        public Guid UserId { get; set; }
        

    }
}
