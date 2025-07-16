using System.ComponentModel.DataAnnotations.Schema;

namespace backend_myper.Models
{
    public class Distrito
    {
        public int Id { get; set; }

        [Column("IdProvincia")]
        public int? ProvinciaId { get; set; }

        public string? NombreDistrito { get; set; }

        public virtual Provincia? Provincia { get; set; }

        public virtual ICollection<Trabajador> Trabajadores { get; set; } = new List<Trabajador>();
    }
}
