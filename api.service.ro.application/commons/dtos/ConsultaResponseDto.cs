
namespace api.service.ro.application.commons.dtos
{
    public class ConsultaResponseDto
    {
        public int IdConsulta { get; set; }
        public int IdCita { get; set; }
        public string MotivoConsulta { get; set; } = null!;
        public string? Diagnostico { get; set; }
        public string? Tratamiento { get; set; }
        public string? Observaciones { get; set; }
    }
}
