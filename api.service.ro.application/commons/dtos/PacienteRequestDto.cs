
using System.ComponentModel.DataAnnotations;

namespace api.service.ro.application.commons.dtos
{
    public class PacienteRequestDto
    {
        [Required]
        [StringLength(15)]
        public string Identificacion { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; } = null!;

        [Required]
        public DateOnly FechaNacimiento { get; set; }

        [MaxLength(1)]
        public char? Sexo { get; set; }

        [StringLength(20)]
        public string? Telefono { get; set; }

        [StringLength(150)]
        public string? Email { get; set; }

        public string? Direccion { get; set; }
    }
}
