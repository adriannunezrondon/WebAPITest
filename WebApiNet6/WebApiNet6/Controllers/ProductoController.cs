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
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly AppDbContexts _context;

        public ProductoController(AppDbContexts context)
        {
            _context = context;
        
        }

        [HttpGet]
        [Route("Productos")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProducto()
        {
            var result = await _context.Productos.ToListAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Producto>> GetProductoID(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            { 
              return NotFound();
            }
            return Ok(producto);

        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> ModificarProducto(int id,Producto producto)
        {
            if (producto is null)
                return BadRequest(ModelState);

            if (id !=producto.ID)
                return BadRequest("Identificador no son iguales");

            var existeProducto = await _context.Productos.FindAsync(id);


            if (existeProducto is null)
                return NotFound($"Entidad con Id ={id} not Fonciona");


            _context.Productos.Remove(existeProducto);

            _context.Productos.Add(producto);

             var result =await _context.SaveChangesAsync();


            if (result <= 0)
                return BadRequest("Tus cambios no pueden salvados");

            return NoContent();
            


        }


    }
}
