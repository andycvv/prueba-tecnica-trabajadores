using backend_myper.Data;
using backend_myper.DTOs;
using backend_myper.Models;
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
                .Select(t => new TrabajadorEditarDTO
                {
                    Id = t.Id,
                    TipoDocumento = t.TipoDocumento,
                    NumeroDocumento = t.NumeroDocumento,
                    Nombres = t.Nombres,
                    Sexo = t.Sexo,
                    DepartamentoId = t.Departamento.Id,
                    DistritoId = t.Distrito.Id,
                    ProvinciaId = t.Provincia.Id
                })
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trabajador is null)
            {
                return NotFound();
            }

            return Ok(trabajador);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TrabajadorCreacionDTO dto)
        {
            var trabajador = new Trabajador
            {
                TipoDocumento = dto.TipoDocumento,
                NumeroDocumento = dto.NumeroDocumento,
                Nombres = dto.Nombres,
                Sexo = dto.Sexo,
                DepartamentoId = dto.DepartamentoId,
                ProvinciaId = dto.ProvinciaId,
                DistritoId = dto.DistritoId
            };

            _context.Add(trabajador);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("obtenerTrabajadorPorId", new { id = trabajador.Id }, dto);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] TrabajadorCreacionDTO dto)
        {
            var trabajador = await _context.Trabajadores.FirstOrDefaultAsync(t => t.Id == id);

            if (trabajador is null)
            {
                return NotFound();
            }

            trabajador.NumeroDocumento = dto.NumeroDocumento;
            trabajador.TipoDocumento = dto.TipoDocumento;
            trabajador.Nombres = dto.Nombres;
            trabajador.Sexo = dto.Sexo;
            trabajador.DepartamentoId = dto.DepartamentoId;
            trabajador.ProvinciaId = dto.ProvinciaId;
            trabajador.DistritoId = dto.DistritoId;

            _context.Update(trabajador);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var registrosBorrados = await _context.Trabajadores
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();

            if (registrosBorrados == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
