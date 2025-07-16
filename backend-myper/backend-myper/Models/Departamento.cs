namespace backend_myper.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        public string? NombreDepartamento { get; set; }

        public virtual ICollection<Provincia> Provincias { get; set; } = new List<Provincia>();

        public virtual ICollection<Trabajador> Trabajadores { get; set; } = new List<Trabajador>();
    }
}
