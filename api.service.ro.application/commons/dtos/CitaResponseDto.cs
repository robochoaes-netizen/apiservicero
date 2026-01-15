
using System;

namespace api.service.ro.application.commons.dtos
{
    public class CitaResponseDto
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora { get; set; }
        public string? Estado { get; set; }
    }
}
