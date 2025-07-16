using backend_myper.Data;
using backend_myper.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_myper.Controllers
{
    [ApiController]
    [Route("api/provincias")]
    public class ProvinciaController
    {
        private readonly AppDbContext _context;
        public ProvinciaController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<ProvinciaDTO>> Get()
        {
            var provincias = await _context.Provincias
                .Select(p => new ProvinciaDTO
                {
                    Id = p.Id,
                    NombreProvincia = p.NombreProvincia
                })
                .ToListAsync();
            return provincias;
        }
    }
}
