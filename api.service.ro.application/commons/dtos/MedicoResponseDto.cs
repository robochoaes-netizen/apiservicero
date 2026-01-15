
namespace api.service.ro.application.commons.dtos
{
    public class MedicoResponseDto
    {
        public int IdMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public string Identificacion { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
