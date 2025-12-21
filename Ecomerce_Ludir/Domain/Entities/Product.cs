using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? imgProduct { get; set; }
        public int Calification { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public float[]? VectorEmbedding { get; set; }


    }
}
