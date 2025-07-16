using System.ComponentModel.DataAnnotations.Schema;

namespace backend_myper.Models
{
    public class Provincia
    {
        public int Id { get; set; }

        [Column("IdDepartamento")]
        public int? DepartamentoId { get; set; }

        public string? NombreProvincia { get; set; }

        public virtual ICollection<Distrito> Distritos { get; set; } = new List<Distrito>();

        public virtual Departamento? Departamento { get; set; }

        public virtual ICollection<Trabajador> Trabajadores { get; set; } = new List<Trabajador>();
    }
}
