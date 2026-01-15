
namespace api.service.ro.application.commons.dtos
{
    public class PacienteResponseDto
    {
        public int IdPaciente { get; set; }
        public string Identificacion { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateOnly FechaNacimiento { get; set; }
        public char? Sexo { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
    }
}
