using backend_myper.Data;
using backend_myper.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_myper.Controllers
{
    [ApiController]
    [Route("api/distritos")]
    public class DistritoController
    {
        private readonly AppDbContext _context;
        public DistritoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<DistritoDTO>> Get()
        {
            var distritos = await _context.Distritos
                .Select(d => new DistritoDTO
                {
                    Id = d.Id,
                    NombreDistrito = d.NombreDistrito
                })
                .ToListAsync();
            return distritos;
        }
    }
}
