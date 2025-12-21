using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Company : User
    {
        public string CompanyName { get; set; }
        public string TaxId { get; set; } // Identificación Fiscal

        // Relación con Biblioteca
        public Biblioteca biblioteca { get; set; }
    }
}
