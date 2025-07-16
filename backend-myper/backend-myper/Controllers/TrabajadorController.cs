using backend_myper.Data;
using backend_myper.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_myper.Controllers
{
    [Route("api/trabajadores")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TrabajadorController(AppDbContext _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public async Task<List<TrabajadorDTO>> Get()
        {
            return await _context.Trabajadores
                .Select(t => new TrabajadorDTO
                {
                    Id = t.Id,
                    TipoDocumento = t.TipoDocumento,
                    NumeroDocumento = t.NumeroDocumento,
                    Nombres = t.Nombres,
                    Sexo = t.Sexo,
                    Departamento = t.Departamento.NombreDepartamento,
                    Distrito = t.Distrito.NombreDistrito,
                    Provincia = t.Provincia.NombreProvincia
                }).ToListAsync();
        }
        [HttpGet("{id:int}", Name = "obtenerTrabajadorPorId")]
        public async Task<ActionResult<TrabajadorDTO>> GetById(int id)
        {
            var trabajador = await _context.Trabajadores
                .Include(t => t.Departamento)
                .Include(t => t.Provincia)
                .Include(t => t.Distrito)
                .Select(t => new TrabajadorDTO
                {
                    Id = t.Id,
                    TipoDocumento = t.TipoDocumento,
                    NumeroDocumento = t.NumeroDocumento,
                    Nombres = t.Nombres,
                    Sexo = t.Sexo,
                    Departamento = t.Departamento.NombreDepartamento,
                    Distrito = t.Distrito.NombreDistrito,
                    Provincia = t.Provincia.NombreProvincia
                })
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trabajador is null)
            {
                return NotFound();
            }

            return Ok(trabajador);
        }
    }
}
