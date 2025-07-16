namespace backend_myper.DTOs
{
    public class TrabajadorDTO
    {
        public int Id { get; set; }
        public required string TipoDocumento { get; set; }
        public required string NumeroDocumento { get; set; }
        public required string Nombres { get; set; }
        public required string Sexo { get; set; }
        public required string Departamento { get; set; }
        public required string Provincia { get; set; }
        public required string Distrito { get; set; }
    }
}
