using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public List<Product> Products { get; set; }
        public float TotalPrice { get; set; }

        // Relación con Client
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        // Relación con Invoice
        public Guid? InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

    }
}
