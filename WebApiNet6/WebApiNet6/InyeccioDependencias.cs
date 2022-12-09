using Microsoft.EntityFrameworkCore;
using WebApiNet6.Interfases;
using WebApiNet6.Repository;

namespace WebApiNet6
{
    public static class InyeccioDependencias
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<Contexts.AppDbContexts>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DifaultConnection")));

            services.AddTransient<IEmpresa, EmpresaRepository>();
            services.AddTransient<IProducto, ProductoRepository>();

            return services;
        }
    }
}


