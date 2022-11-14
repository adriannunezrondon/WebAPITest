using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiNet6.Contexts;
using WebApiNet6.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly AppDbContexts _context;

        public EmpresaController(AppDbContexts context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Empresas")]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            var result = await _context.Empresas.ToListAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("Productos")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }


        //api/BusquedaProductoPorId
        [HttpGet("Producto/{id}")]
        public async Task<ActionResult<Producto>> GetProductoPorId(int id)
        {

            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);

        }


        [HttpPost("InsertarEmpresa")]

        public async  Task<ActionResult<Empresa>> PostEmpresa (Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresas", new { ID = empresa.ID }, empresa);
        
        }

       

    }
}
