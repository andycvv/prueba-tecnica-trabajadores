using backend_myper.Data;
using backend_myper.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_myper.Controllers
{
    [ApiController]
    [Route("api/departamentos")]
    public class DepartamentoController
    {
        private readonly AppDbContext _context;
        public DepartamentoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<DepartamentoDTO>> Get()
        {
            var departamentos = await _context.Departamentos
                .Select(d => new DepartamentoDTO
                {
                    Id = d.Id,
                    NombreDepartamento = d.NombreDepartamento
                })
                .ToListAsync();
            return departamentos;
        }
    }
}
