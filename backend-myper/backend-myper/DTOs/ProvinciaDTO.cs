using System.ComponentModel.DataAnnotations.Schema;

namespace backend_myper.DTOs
{
    public class ProvinciaDTO
    {
        public int Id { get; set; }
        public required string NombreProvincia { get; set; }
    }
}
