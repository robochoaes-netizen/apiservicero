
using System.ComponentModel.DataAnnotations;

namespace api.service.ro.application.commons.dtos
{
    public class ConsultaRequestDto
    {
        [Required]
        public int IdCita { get; set; }

        [Required]
        public string MotivoConsulta { get; set; } = null!;

        public string? Diagnostico { get; set; }

        public string? Tratamiento { get; set; }

        public string? Observaciones { get; set; }
    }
}
