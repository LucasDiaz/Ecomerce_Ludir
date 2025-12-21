using Org.BouncyCastle.Crypto.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public string? ImgProfile { get; set; }

      
        // --- Nuevos Campos para la Verificación ---
        public string? EmailVerificationToken { get; set; } = string.Empty;
        public bool IsEmailVerified { get; set; } = false;
        // ------------------------------------------

        // --- NUEVOS CAMPOS para Restablecer Contraseña ---
        public string? PasswordResetToken { get; set; } // Token de un solo uso
        public DateTime? ResetTokenExpires { get; set; } // Fecha/Hora de expiración del token


        //------------------------------------------
        //relación con Invoice
        public List<Invoice> Invoices { get; set; }
       

    }
}
