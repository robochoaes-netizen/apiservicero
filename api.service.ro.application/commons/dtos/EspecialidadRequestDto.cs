
using System.ComponentModel.DataAnnotations;

namespace api.service.ro.application.commons.dtos
{
    public class EspecialidadRequestDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }
    }
}
