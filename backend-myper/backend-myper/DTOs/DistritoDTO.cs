using System.ComponentModel.DataAnnotations.Schema;

namespace backend_myper.DTOs
{
    public class DistritoDTO
    {
        public int Id { get; set; }
        public required string NombreDistrito { get; set; }
    }
}
