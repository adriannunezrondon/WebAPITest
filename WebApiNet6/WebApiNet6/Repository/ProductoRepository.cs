using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiNet6.Contexts;
using WebApiNet6.DTO;
using WebApiNet6.Interfases;
using WebApiNet6.Models;
using Dapper;


namespace WebApiNet6.Repository
{
    public class ProductoRepository : IProducto
    {

        private readonly AppDbContexts _context;
        private readonly object configuration;
        //private readonly object configuration;

        public ProductoRepository(AppDbContexts context)
        {
            _context = context;

        }


        /// ///////////////////////////////////////////////////////////////////////////////////

        public async Task<ActionResult<List<Producto>>> GetProducto()
        {
            List<Producto> result = await _context.Productos.ToListAsync();

            return result;
        }


        public async Task<ActionResult<Producto>> PostProducto(Producto pro)
        {
            if (pro is null)
                return null;
            _context.Productos.Add(pro);
            await _context.SaveChangesAsync();
            return pro;
        }

 

        /// //////////////////////////////////////////////////////////////////////////////

        public async Task<ActionResult<Producto>> GetProductoPorID(int id)
        {

            var existe = await _context.FindAsync<Producto>(id); //ESTO ES OTRA MANERA DE BUSCAR POR ID

            if (existe is null)
                return null;

            return existe;

        }

        public async Task<ActionResult<Producto>> PutProducto(int id, Producto pro)
        {

            var existe = await _context.Productos.FindAsync(id);

            if (existe is null)
                return null;


            _context.Productos.Remove(existe);
            _context.Productos.Add(pro);
            await _context.SaveChangesAsync();

           // _context.Productos.Remove(existe);
            //_context.Productos.Add(pro);
            existe.Categorias = pro.Categorias;
            existe.Descripcion = pro.Descripcion;
            existe.EmpresaID = pro.EmpresaID;
            existe.Unidades = pro.Unidades;
            existe.Precio = pro.Precio;
            existe.Nombre= pro.Nombre;


           await _context.SaveChangesAsync();


            return pro;
        }

        public async Task<ActionResult<List<Producto>>> ProductoMayorPrecio()
        {
            List<Producto> lista = await _context.Productos.ToListAsync();

            List<Producto> linq = (from p in lista orderby p.Precio descending select p).Take(1).ToList();
            return linq;
        }


        public async Task<ActionResult<Producto>> DeleteProducto(int id)
        {
            var existe = await _context.Productos.FindAsync(id);

            if (existe is null)
                return null;

            _context.Productos.Remove(existe);
            await _context.SaveChangesAsync();
            return existe;
        }

        public async Task<ActionResult<List<Producto>>> LosTresProductosDeMayorPrecio()
        {
            List<Producto> lista = await _context.Productos.ToListAsync();

            if (lista.Count==0)
                return null;

            List<Producto> linq = (from p in lista orderby p.Precio descending select p).Take(3).ToList();
            return linq;
        }

        public async Task<ActionResult<List<DTOproductos>>> DTOTodosProducto()
        {
            // Cargar configuración desde appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var sql = "SELECT P.ID, P.Nombre, P.Categorias, P.Descripcion, P.Precio, P.Unidades, E.Nombre as Empresa "+
                       "FROM Productos P INNER JOIN Empresas E ON (P.EmpresaID = E.ID)";
             

            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DifaultConnection"))) 
            { 
                connection.Open();
                try {
                    var result = await connection.QueryAsync<DTOproductos>(sql);
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
               
            }
               
        }
    }


}
