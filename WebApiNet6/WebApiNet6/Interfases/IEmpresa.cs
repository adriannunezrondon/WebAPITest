using Microsoft.AspNetCore.Mvc;
using WebApiNet6.Models;

namespace WebApiNet6.Interfases
{
    public interface IEmpresa
    {
        Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas();
        Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa);
        Task<ActionResult<Empresa>> PutEmpresa(int id, Empresa empresa);
        Task<ActionResult<Empresa>> DeleteEmpresa(int id);

    }
}
