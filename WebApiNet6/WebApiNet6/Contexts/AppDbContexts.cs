using Microsoft.EntityFrameworkCore;
using WebApiNet6.Models;




namespace WebApiNet6.Contexts
{
    public class AppDbContexts : DbContext
    {
        public AppDbContexts(DbContextOptions options) : base(options) { }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
    }

}
