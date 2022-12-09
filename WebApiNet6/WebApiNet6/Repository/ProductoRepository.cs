using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiNet6.Contexts;
using WebApiNet6.Interfases;
using WebApiNet6.Models;

namespace WebApiNet6.Repository
{
    public class ProductoRepository : IProducto
    {

        private readonly AppDbContexts _context;

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

    }


}
