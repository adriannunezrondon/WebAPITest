using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiNet6.Contexts;
using WebApiNet6.Models;

    

namespace WebApiNet6.Controllers
{
    [Route("producto/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly AppDbContexts _context;

        public ProductoController(AppDbContexts context)
        {
            _context = context;
        
        }

        //public async Task<ActionResult<Producto>> putProducto(int id, Producto producto)
        //{
        //    _context.Productos.Add(producto);
        //    await _context.SaveChangesAsync();

        //    return 
        
        //}


    }
}
