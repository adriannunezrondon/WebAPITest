
using Microsoft.AspNetCore.Mvc;
using WebApiNet6.Models;
using WebApiNet6.Interfases;
using WebApiNet6.DTO;

namespace WebApiNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IProducto _IProductoRepository;   //AQUI ESTA LA INYECCION ORM DE LA BASE RELACIONAL

        public ProductoController(IProducto IProductoRepository)
        {
            _IProductoRepository = IProductoRepository;

        }

        [HttpPost]
        [Route("InsertarProductos")]
        public async Task<ActionResult<Producto>> Insertar(Producto Pro)
        { 
            if(await _IProductoRepository.PostProducto(Pro) is null)
                return BadRequest(ModelState);
            return Ok(ModelState);
        
        }



        [HttpGet]
        [Route("Productos")]
        public async Task<ActionResult<IEnumerable<Producto>>> ObtenerTodosProducto()
        {
            var result = await _IProductoRepository.GetProducto();

            return Ok(result.Value);
        }

        [HttpGet]
        [Route("DTOProductos")]
        public async Task<ActionResult<IEnumerable<DTOproductos>>> DTOTodosProducto()
        {
            var result = await _IProductoRepository.DTOTodosProducto();
            if (result !=  null)
            {
                return Ok(result.Value);
            }
            return BadRequest(ModelState);
            
        }



        [HttpGet]
        [Route("BuscarProdictoPorId {id}")]

        public async Task<ActionResult<Producto>> BuscarProductoPorId(int id)
        {
     
            var pro = await _IProductoRepository.GetProductoPorID(id);
            if (pro is null)
                return BadRequest("El id que pasaste no es correcto!!");
            return Ok(pro.Value);

        }


        //*********************************************************************************************
        [HttpPut]

        public async Task<ActionResult<Producto>>ModificarProducto(int id, Producto producto)
        {

            if((producto is null) || (id != producto.ID))
                     return BadRequest("El Producto es nulo o son diferentes los identificadores");


            return await _IProductoRepository.PutProducto(id, producto);



        }


        //***********************************************************************************************
        [HttpGet("Producto_Mayor_Precio")]
        public async Task<ActionResult<List<Producto>>>ProductoDeMayorPrecio()
        {
            return await _IProductoRepository.ProductoMayorPrecio();
        }



        //**************************************************************************************************
        [HttpDelete("Eliminar_Producto")]
        public async Task<ActionResult<Producto>> EliminarProducto(int id)
        {

            if (id == 0)
                return BadRequest("No existe un identificador como ese!!");

            return await _IProductoRepository.DeleteProducto(id);
        
        }



    }
}
