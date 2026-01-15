
using System;
using System.ComponentModel.DataAnnotations;

namespace api.service.ro.application.commons.dtos
{
    public class CitaRequestDto
    {
        [Required]
        public int IdPaciente { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        public DateOnly Fecha { get; set; }

        [Required]
        public TimeOnly Hora { get; set; }

        [StringLength(20)]
        public string? Estado { get; set; }
    }
}
