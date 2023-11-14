using Microsoft.EntityFrameworkCore;
using SanJuanTransporte.Models;

namespace SanJuanTransporte.Context
{
    public class MyContext:DbContext
    {
        MyContext(DbContextOptions options): base(options) 
        { 
        
        }
        public DbSet <Usuario> Usuarios {  get; set; }
        public DbSet<Conductor> Conductors { get; set; }

    }
}
