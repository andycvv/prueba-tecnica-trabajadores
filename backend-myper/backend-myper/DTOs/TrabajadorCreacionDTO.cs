using System.ComponentModel.DataAnnotations;

namespace backend_myper.DTOs
{
    public class TrabajadorCreacionDTO
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(3, ErrorMessage = "El campo no debe exceder los 3 caracteres")]
        public required string TipoDocumento { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(50, ErrorMessage = "El campo no debe exceder los 50 caracteres")]
        public required string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(500, ErrorMessage = "El campo no debe exceder los 500 caracteres")]
        public required string Nombres { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(1, ErrorMessage = "El campo no debe exceder los 1 caracteres")]
        public required string Sexo { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public int DepartamentoId { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int ProvinciaId { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int DistritoId { get; set; }
    }
}
