using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Biblioteca
    {
        public Guid BibliotecaId { get; set; }
        public List<Product> Products { get; set; }

        // Relación con Company
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        // Relación con BibiliotecaItem
        public List<BibliotecaProduct> BibliotecaProductos { get; set; }
    }
}
