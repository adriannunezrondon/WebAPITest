
using Microsoft.AspNetCore.Mvc;
using WebApiNet6.Interfases;
using WebApiNet6.Models;


namespace WebApiNet6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IProducto _IProductoRepository;   //AQUI ESTA LA INYECCION ORM DE LA BASE RELACIONAL

        public ProductoController(IProducto IProductoRepository)
        {
            _IProductoRepository = IProductoRepository;

        }

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



        [HttpGet]
        [Route("Productos")]
        public async Task<ActionResult<IEnumerable<Producto>>> ObtenerTodosProducto()
        {
            var result = await _IProductoRepository.GetProducto();

<<<<<<< Updated upstream
            return Ok(result);
=======
            return Ok(result.Value);
        }

        [HttpGet]
        [Route("DTOProductos")]
        public async Task<ActionResult<IEnumerable<DTOproductos>>> DTOTodosProducto()
        {
            var result = await _IProductoRepository.DTOTodosProducto();
            if (result != null)
            {
                return Ok(result.Value);
            }
            return BadRequest(ModelState);

>>>>>>> Stashed changes
        }



        [HttpGet]
        [Route("BuscarProdictoPorId/{id}")]

        public async Task<ActionResult<Producto>> BuscarProductoPorId(int id)
        {
<<<<<<< Updated upstream
            if (id == 0)
=======

            var pro = await _IProductoRepository.GetProductoPorID(id);
            if (pro is null)
>>>>>>> Stashed changes
                return BadRequest("El id que pasaste no es correcto!!");

            return await _IProductoRepository.GetProductoPorID(id);

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













        //[HttpPut("{id:int}")]

        //public async Task<ActionResult> ModificarProducto(int id, Producto producto)
        //{
        //    if (producto is null)
        //        return BadRequest(ModelState);

        //    if (id != producto.ID)
        //        return BadRequest("Identificador no son iguales");

        //    var existeProducto = await _context.Productos.FindAsync(id);


        //    if (existeProducto is null)
        //        return NotFound($"Entidad con Id ={id} not Fonciona");


        //    _context.Productos.Remove(existeProducto);

        //    _context.Productos.Add(producto);

        //    var result = await _context.SaveChangesAsync();


        //    if (result <= 0)
        //        return BadRequest("Tus cambios no pueden salvados");

        //    return NoContent();



        //}
        //[HttpPost("InsertarProducto")]
        //public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        //{
        //    _context.Productos.Add(producto);
        //    var result = await _context.SaveChangesAsync();
        //    if (result != 1)
        //        return BadRequest(result);

        //    return Ok(producto);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Producto>> DeleteProducto(int id)
        //{
        //    var result = await _context.Productos.FindAsync(id);
        //    if (result is null)
        //        return NotFound();

        //    _context.Productos.Remove(result);
        //    var resultado = await _context.SaveChangesAsync();
        //    if (resultado == 1)
        //        return Ok(result);

        //    return BadRequest("No se elimino el elemento" + resultado);
        //}

        //[HttpGet("Mayor_Precio_Producto")]
        //public async Task<ActionResult<Producto>> productoMayor()
        //{

        //    List<Producto> lista = await _context.Productos.ToListAsync();

        //    if (lista is null)
        //        return BadRequest("La lista es vacia");

        //    List<Producto> prodMayorPrecio = (from prod in lista orderby prod.Precio descending select prod).Take(1).ToList();

        //    return Ok(prodMayorPrecio);
        //    //Producto may = prodMayorPrecio.ElementAt(0);

        //    //foreach (Producto i in prodMayorPrecio) 
        //    //{

        //    //    if (may.Precio < i.Precio)
        //    //        may = i;



        //    //}

        //    //Producto mayor = lista.ElementAt(0);
        //    //for (int i = 1; i < lista.Count() - 1; i++)
        //    //{
        //    //    if (mayor.Precio < lista.ElementAt(i).Precio)
        //    //        mayor = lista.ElementAt(i);
        //    //}
        //    //return Ok(mayor);

        //    // return Ok(may);
        //}









        ////ENCONTRAR LOS TRES PRODUCTOS DE MAYOR PRECIO
        //[HttpGet("Tres_Mayor_Precio_Producto")]
        //public async Task<ActionResult<List<Producto>>> TresProductosMayorPrecio()
        //{

        //    List<Producto> lista1 = await _context.Productos.ToListAsync();

        //    if (lista1 is null)
        //        return BadRequest("Lista Vacia");

        //    List<Producto> tresMayores = (from prod in lista1 orderby prod.Precio descending select prod).Take(3).ToList();

        //    return Ok(tresMayores);

        //    ///////////////////////////////////////////////////////

        //    //List < Producto > lista = await _context.Productos.ToListAsync();

        //    //List<Producto> lst = lista;

        //    //List<Producto> listaresul = new List<Producto>();
        //    //if (lista.Count() < 3)
        //    //    return NotFound("Existen menos de 3 elementos");


        //    //Producto mayor = lista.ElementAt(0);
        //    //Producto mediano = lista.ElementAt(1);
        //    //Producto menor = lista.ElementAt(2);

        //    //for (int i = 0; i <= lista.Count() - 1; i++)
        //    //{
        //    //    if (mayor.Precio < lista.ElementAt(i).Precio)
        //    //    {
        //    //        menor = mediano;
        //    //        mediano = mayor;
        //    //        mayor = lista.ElementAt(i);
        //    //    }
        //    //    else
        //    //    if (mediano.Precio < lista.ElementAt(i).Precio)
        //    //    {
        //    //        menor = mediano;
        //    //        mediano = lista.ElementAt(i);
        //    //    }
        //    //    else
        //    //    if (menor.Precio < lista.ElementAt(i).Precio)
        //    //    {
        //    //        menor = lista.ElementAt(i);
        //    //    }
        //    //}
        //    //listaresul.Add(mayor);
        //    //listaresul.Add(mediano);
        //    //listaresul.Add(menor);
        //    //return Ok();          

        //}//FIN TRES MAYORES

        //[HttpGet("JOIN EmpresaProducto")]
        //public async Task<ActionResult<List<Empresa>>> JoinEmpresaProducto()
        //{

        //    List<Producto> ListaProductos = await _context.Productos.ToListAsync();

        //    List<Empresa> ListaEmpresas = await _context.Empresas.ToListAsync();



        //    if (ListaProductos is null || ListaEmpresas is null)
        //        return NotFound("La tabla empresa o la tabla producto esta vacia");

        //    List<Empresa> join = (from empresa in ListaEmpresas join producto in ListaProductos
        //                        on empresa.ID equals producto.EmpresaID
        //                          // where empresa.ID==id
        //                          select empresa).ToList();


        //    return join;
        //}



    }
}
