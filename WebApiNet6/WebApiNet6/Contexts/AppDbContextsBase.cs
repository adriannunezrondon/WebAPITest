using Microsoft.EntityFrameworkCore;
using WebApiNet6.Models;

namespace WebApiNet6.Contexts
{
    public class AppDbContextsBase
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}