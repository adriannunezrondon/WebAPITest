
using Microsoft.AspNetCore.Mvc;
using WebApiNet6.Models;
using WebApiNet6.Interfases;
using Microsoft.AspNetCore.JsonPatch.Internal;
using System.Collections;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {

        private readonly IEmpresa _IEmpresaRepository;

        public EmpresaController(IEmpresa IEmpresaRepository)
        {

            _IEmpresaRepository = IEmpresaRepository;
        }


        [HttpGet]
        [Route("Empresas")]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            return await _IEmpresaRepository.GetEmpresas();
        }


        [HttpPost]
        [Route("Insertar Empresa")]
        public async Task<ActionResult<Empresa>> InsertarEmpresa(Empresa Empresa)
        {

            if (Empresa is null)
                return BadRequest(ModelState);

            return await _IEmpresaRepository.PostEmpresa(Empresa);

        }


        [HttpPut]
        [Route("Modificar")]

        public async Task<ActionResult<Empresa>> ModificarEmpresa(int id, Empresa empresa)
        {

            if (empresa is null)
                return NotFound();

            if (id != empresa.ID)
                return BadRequest("Los id de los elementon no coinciden");


            return await _IEmpresaRepository.PutEmpresa(id, empresa);


        }

        [HttpDelete]
        [Route("Eliminar Empresa")]

        public async Task<ActionResult<Empresa>> EliminarEmpresa(int id)
        {
            if (id == 0)
                return BadRequest("No puede ser vacio el id a eliminar");
            return await _IEmpresaRepository.DeleteEmpresa(id);
        
        }

        //[HttpGet]
        //[Route("invento Mio")]
        //public async Task<ActionResult<int>>Invento()
        //{
        //    return  await _IEmpresaRepository.GetEmpresaProcedure();

        //}

    }
}
