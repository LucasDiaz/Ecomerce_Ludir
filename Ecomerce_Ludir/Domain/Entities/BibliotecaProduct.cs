using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BibliotecaProduct
    {
        public Guid BibliotecaId { get; set; }
        public Biblioteca Biblioteca { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
