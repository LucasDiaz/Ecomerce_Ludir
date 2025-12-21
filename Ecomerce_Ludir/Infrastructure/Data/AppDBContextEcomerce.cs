using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDBContextEcomerce: DbContext
    {
        public AppDBContextEcomerce(DbContextOptions<AppDBContextEcomerce> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Biblioteca> Bibliotecas { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity => {
                entity.ToTable("users");
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Address).HasMaxLength(200);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(150);
                entity.Property(u => u.Password).IsRequired().HasMaxLength(200);
                entity.Property(u => u.Telefono).HasMaxLength(20);
                entity.Property(u => u.CreatedAt).IsRequired();
                entity.Property(u => u.LastUpdatedAt).IsRequired();
                entity.Property(u => u.IsActive).IsRequired();
                entity.HasDiscriminator<string>("user_type")
                .HasValue<Client>("Client")// Valor cuando es Persona
                .HasValue<Company>("Company");// Valor cuando es Empresa


            });
            
         
        
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Description).HasMaxLength(1000);
                entity.Property(p => p.Stock).IsRequired();
                

                // Mapeo de precisión decimal para dinero
                entity.Property(p => p.Price).HasColumnType("numeric(10,2)");
                
                // El vector de IA se guarda como un array de floats en Postgres
                entity.Property(p => p.VectorEmbedding).HasColumnType("float4[]");
            });
        


            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("carts");
                entity.HasKey(c => c.CartId);
                entity.Property(c => c.TotalPrice).IsRequired();  
            });

             modelBuilder.Entity<Invoice>(entity =>
             {
                 entity.ToTable("invoices");
                 entity.HasKey(i => i.InvoiceId);
                 entity.Property(i => i.TotalPrice).IsRequired().HasColumnType("numeric(10,2)");
                 entity.Property(i => i.CreatedAt).IsRequired();
                 //entity.HasOne<User>()
                 //      .WithMany()
                 //      .HasForeignKey(i => i.UserId)
                 //      .OnDelete(DeleteBehavior.Cascade);

             });

            modelBuilder.Entity<Biblioteca>(entity =>
            {
                entity.ToTable("bibliotecas");
                entity.HasKey(b => b.BibliotecaId);
             
            });

      
         
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admins");
                entity.Property(u => u.UserName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Address).HasMaxLength(200);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(150);
                entity.Property(u => u.Password).IsRequired().HasMaxLength(200);
                entity.Property(u => u.Telefono).HasMaxLength(20);
                entity.Property(u => u.CreatedAt).IsRequired();
                entity.Property(u => u.LastUpdatedAt).IsRequired();
                entity.Property(u => u.IsActive).IsRequired();
            });


            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("cart_items");
                entity.HasKey(ci => ci.CartItemId);

                entity.HasOne(ci => ci.Cart)
                      .WithMany(c => c.Items)
                      .HasForeignKey(ci => ci.CartId);

                entity.HasOne(ci => ci.Product)
                      .WithMany() // Un producto puede estar en muchos CartItems
                      .HasForeignKey(ci => ci.ProductId);

                entity.Property(ci => ci.UnitPrice).HasColumnType("numeric(10,2)");
            });

            modelBuilder.Entity<BibliotecaProduct>(entity =>
            {
                entity.ToTable("biblioteca_products");
                // Clave primaria compuesta
                entity.HasKey(bp => new { bp.BibliotecaId, bp.ProductId });

                entity.HasOne(bp => bp.Biblioteca)
                      .WithMany(b => b.BibliotecaProductos)
                      .HasForeignKey(bp => bp.BibliotecaId);

                entity.HasOne(bp => bp.Product)
                      .WithMany()
                      .HasForeignKey(bp => bp.ProductId);
            });




            // Definición de relaciones
            //carrito - cliente (1-1)
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Client)
                .WithOne(cl => cl.carrito)
                .HasForeignKey<Cart>(c => c.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            //biblioteca - company (1-1)
            modelBuilder.Entity<Biblioteca>()
                .HasOne(b => b.Company)
                .WithOne(cl => cl.biblioteca)
                .HasForeignKey<Biblioteca>(b => b.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
           
            //invoice - carrito (1-1)
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Cart)
                .WithOne(c => c.Invoice)
                .HasForeignKey<Invoice>(b => b.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            //invoice - user (many-1)
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.User)
                .WithMany(u => u.Invoices)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

          





        }

    }
}
