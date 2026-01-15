
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.service.ro.application.commons.dtos
{
    public class PagoRequestDto
    {
        public int IdCita { get; set; }
        public decimal Monto { get; set; }
        public string? MetodoPago { get; set; }
    }
}
