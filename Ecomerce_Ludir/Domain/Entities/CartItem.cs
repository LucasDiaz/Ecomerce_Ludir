using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem
    {
        public Guid CartItemId { get; set; } 

        // Relación con el Carrito
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        // Relación con el Producto
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        // Atributo extra solicitado: Cantidad
        public int Quantity { get; set; }

        // Atributo recomendado: Precio al momento de agregar
        public decimal UnitPrice { get; set; }
    }
}
