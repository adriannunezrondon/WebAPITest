
using Microsoft.AspNetCore.Mvc;
using WebApiNet6.Interfases;
<<<<<<< HEAD
using WebApiNet6.DTO;
=======
using WebApiNet6.Models;

>>>>>>> Main

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

<<<<<<< HEAD
        [HttpPost]
        [Route("InsertarProductos")]
        public async Task<ActionResult<Producto>> Insertar(Producto Pro)
        { 
            if(await _IProductoRepository.PostProducto(Pro) is null)
                return BadRequest(ModelState);
            return Ok(ModelState);
        
        }
=======
<<<<<<< Updated upstream

=======
        [HttpPost]
        [Route("InsertarProductos")]
        public async Task<ActionResult<Producto>> Insertar(Producto Pro)
        {
            if (await _IProductoRepository.PostProducto(Pro) is null)
                return BadRequest(ModelState);
            return Ok(ModelState);

        }
>>>>>>> Stashed changes
>>>>>>> Main



        [HttpGet]
        [Route("Productos")]
        public async Task<ActionResult<IEnumerable<Producto>>> ObtenerTodosProducto()
        {
            var result = await _IProductoRepository.GetProducto();

<<<<<<< HEAD
=======
<<<<<<< Updated upstream
            return Ok(result);
=======
>>>>>>> Main
            return Ok(result.Value);
        }

        [HttpGet]
        [Route("DTOProductos")]
        public async Task<ActionResult<IEnumerable<DTOproductos>>> DTOTodosProducto()
        {
            var result = await _IProductoRepository.DTOTodosProducto();
<<<<<<< HEAD
            if (result !=  null)
=======
            if (result != null)
>>>>>>> Main
            {
                return Ok(result.Value);
            }
            return BadRequest(ModelState);
<<<<<<< HEAD
            
=======

>>>>>>> Stashed changes
>>>>>>> Main
        }



        [HttpGet]
        [Route("BuscarProdictoPorId {id}")]

        public async Task<ActionResult<Producto>> BuscarProductoPorId(int id)
        {
<<<<<<< HEAD
     
            var pro = await _IProductoRepository.GetProductoPorID(id);
            if (pro is null)
                return BadRequest("El id que pasaste no es correcto!!");
            return Ok(pro.Value);
=======
<<<<<<< Updated upstream
            if (id == 0)
=======

            var pro = await _IProductoRepository.GetProductoPorID(id);
            if (pro is null)
>>>>>>> Stashed changes
                return BadRequest("El id que pasaste no es correcto!!");

            return await _IProductoRepository.GetProductoPorID(id);
>>>>>>> Main

        }


        //*********************************************************************************************
        [HttpPut ("{id}")]

        public async Task<ActionResult<Producto>> ModificarProducto(int id, Producto producto)
        {

            if ((producto is null) || (id != producto.ID))
                return BadRequest("El Producto es nulo o son diferentes los identificadores");


            return await _IProductoRepository.PutProducto(id, producto);



        }


        //***********************************************************************************************
        [HttpGet("Producto_Mayor_Precio")]
        public async Task<ActionResult<List<Producto>>> ProductoDeMayorPrecio()
        {
            return await _IProductoRepository.ProductoMayorPrecio();
        }



        //**************************************************************************************************
        [HttpDelete("Eliminar_Producto/{id}")]
        public async Task<ActionResult<Producto>> EliminarProducto(int id)
        {

            if (id == 0)
                return BadRequest("No existe un identificador como ese!!");

            return await _IProductoRepository.DeleteProducto(id);

        }



    }
}
