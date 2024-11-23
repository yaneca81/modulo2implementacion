using Caso3.Models;
using Microsoft.EntityFrameworkCore;

namespace Caso3.Data
{
    public class RestauranteDbContext : DbContext
    {
        public RestauranteDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar relaciones sin eliminación en cascada
            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.Pedido)
                .WithMany(p => p.Detalles)
                .HasForeignKey(dp => dp.PedidoId)
                .OnDelete(DeleteBehavior.Restrict); // Evita la eliminación en cascada

            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.Menu)
                .WithMany()
                .HasForeignKey(dp => dp.MenuId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Pedidos)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Restaurante)
                .WithMany(r => r.Pedidos)
                .HasForeignKey(p => p.RestauranteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Menu>()
                .HasOne(m => m.Restaurante)
                .WithMany(r => r.Menus)
                .HasForeignKey(m => m.RestauranteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Pedido)
                .WithOne()
                .HasForeignKey<Pago>(p => p.PedidoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
