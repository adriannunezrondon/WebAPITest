
using Microsoft.AspNetCore.Mvc;
using WebApiNet6.Models;

namespace WebApiNet6.Interfases
{
    public interface IProducto
    {

        Task<ActionResult<List<Producto>>> GetProducto();
        Task<ActionResult<Producto>> GetProductoPorID(int id);
        Task<ActionResult<Producto>> PutProducto(int id, Producto pro);
        Task<ActionResult<List<Producto>>> ProductoMayorPrecio();
        Task<ActionResult<Producto>> DeleteProducto(int id);


    }
}
