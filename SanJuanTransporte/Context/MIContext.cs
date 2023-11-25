using Microsoft.EntityFrameworkCore;
using SanJuanTransporte.Models;

namespace SanJuanTransporte.Context
{
    public class MiContext : DbContext
    {
        public  MiContext(DbContextOptions <MiContext> options) : base(options)
        {

        }
        //estas clases persistemtes se van ha tranformar en tablas en base de datos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conductor> Conductor { get; set; }

    }
}
