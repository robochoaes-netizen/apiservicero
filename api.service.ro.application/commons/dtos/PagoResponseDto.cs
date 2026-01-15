
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.service.ro.application.commons.dtos
{
    public class PagoResponseDto
    {
        public int IdPago { get; set; }
        public int IdCita { get; set; }
        public decimal Monto { get; set; }
        public string? MetodoPago { get; set; }
        public bool? Activo { get; set; }
        public DateTime? CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }
    }
}
