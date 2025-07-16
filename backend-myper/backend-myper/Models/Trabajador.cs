using System.ComponentModel.DataAnnotations.Schema;

namespace backend_myper.Models
{
    public class Trabajador
    {
        public int Id { get; set; }

        public string? TipoDocumento { get; set; }

        public string? NumeroDocumento { get; set; }

        public string? Nombres { get; set; }

        public string? Sexo { get; set; }

        [Column("IdDepartamento")]
        public int? DepartamentoId { get; set; }

        [Column("IdProvincia")]
        public int? ProvinciaId { get; set; }

        [Column("IdDistrito")]
        public int? DistritoId { get; set; }

        public virtual Departamento? Departamento { get; set; }

        public virtual Distrito? Distrito { get; set; }

        public virtual Provincia? Provincia { get; set; }
    }
}
