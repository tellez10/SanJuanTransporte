using Microsoft.EntityFrameworkCore;
using SanJuanTransporte.Models;

namespace SanJuanTransporte.Context
{
    public class MiContext : DbContext
    {
        public MiContext(DbContextOptions<MiContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conductor> Conductor { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Recibo> Recibos { get; set; } // Agregado DbSet para la entidad Recibo
        
    }
}
