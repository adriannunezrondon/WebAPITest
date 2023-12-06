using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiNet6.Contexts;
using WebApiNet6.Interfases;
using WebApiNet6.Models;

namespace WebApiNet6.Repository
{
    public class EmpresaRepository:IEmpresa
    {

        private readonly AppDbContexts _context;

        public EmpresaRepository (AppDbContexts context) 
        {
            _context = context;
        }



        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            var result = await _context.Empresas.ToListAsync();
            return result;
        }

        public async Task<ActionResult<Empresa>> GetEmpresaById(int id)
        {
            var result = await _context.Empresas.FindAsync(id);
            return result;
        }
        //GetEmpresasById

        ////INSERTAR EMPRESAS


        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {

            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return empresa;

        }

        public async Task<ActionResult<Empresa>> PutEmpresa(int id, Empresa empresa)
        {

            var existe = await _context.Empresas.FindAsync(id);

            if (existe is null)
                return null;
           
            /* _context.Empresas.Remove(existe);
             _context.Empresas.Add(empresa);*/
            existe.Nombre= empresa.Nombre;
            existe.Direccion= empresa.Direccion;
             await _context.SaveChangesAsync();

            return empresa;
        
        }


        public async Task<ActionResult<Empresa>> DeleteEmpresa(int id)
        { 
        
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa is null)
                return null;

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return empresa;

        }

    
    }
}
