using Microsoft.EntityFrameworkCore;
using Practica2.Models;

namespace Practica2.Data
{
    public class DataPractica : DbContext
    {
        public DataPractica(DbContextOptions<DataPractica> options):base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Restaurante> Restaurantes { get;set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Platillo> Platillos { get; set; }
        public DbSet<Detalle_Pedido> DetallePedidos { get;set; }
        public DbSet<Pago> Pagos { get; set; }
       
    }
}
