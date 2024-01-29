
using Microsoft.AspNetCore.Mvc;
using WebApiNet6.Interfases;
using WebApiNet6.Models;


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
        public async Task<ActionResult<IEnumerable<Empresa>>> AllEmpresas()
        {
            
            var result = await _IEmpresaRepository.GetEmpresas();
            if(result is null)
                return NotFound();
            return result;
        }

        [HttpGet]
        [Route("GetEmpresa/{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresasById(int id)
        {

            var result = await _IEmpresaRepository.GetEmpresaById(id);
            if (result is null)
                return NotFound();
            return result;
        }

        [HttpGet]
        [Route("GetNameEmpresa/{id}")]
        public async Task<ActionResult<string>?> GetNameEmpresasById(int id)
        {

            var result = await _IEmpresaRepository.GetEmpresaById(id);
            if (result is null)
                return NotFound();
            return result.Value.Nombre;
        }


        [HttpPost]
        [Route("InsertarEmpresa")]
        public async Task<ActionResult<Empresa>> InsertarEmpresa(Empresa Empresa)
        {

            if (Empresa is null)
                return BadRequest(ModelState);
            return await _IEmpresaRepository.PostEmpresa(Empresa);

        }


        [HttpPut]
        [Route("Modificar/{id}")]

        public async Task<ActionResult<Empresa>> ModificarEmpresa(int id, Empresa empresa)
        {

            if (empresa is null)
                return NotFound();

            if (id != empresa.ID)
                return BadRequest("Los id de los elementon no coinciden");

            return await _IEmpresaRepository.PutEmpresa(id, empresa);


        }

        [HttpDelete]
        [Route("EliminarEmpresa/{id}")]

        public async Task<ActionResult<Empresa>> EliminarEmpresa(int id)
        {
            if (id == 0)
                return BadRequest("No puede ser vacio el id a eliminar");
            return await _IEmpresaRepository.DeleteEmpresa(id);

        }

       

    }
}
