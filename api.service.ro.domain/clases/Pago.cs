using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.service.ro.domain.clases;

[Table("pagos", Schema = "rochoa")]
public partial class Pago
{
    [Key]
    [Column("id_pago")]
    public int IdPago { get; set; }

    [Column("id_cita")]
    public int IdCita { get; set; }

    [Column("monto")]
    [Precision(10, 2)]
    public decimal Monto { get; set; }

    [Column("metodo_pago")]
    [StringLength(30)]
    public string? MetodoPago { get; set; }

    [Column("activo")]
    public bool? Activo { get; set; }

    [Column("creado_en", TypeName = "timestamp without time zone")]
    public DateTime? CreadoEn { get; set; }

    [Column("actualizado_en", TypeName = "timestamp without time zone")]
    public DateTime? ActualizadoEn { get; set; }

    [ForeignKey("IdCita")]
    [InverseProperty("Pagos")]
    public virtual Cita IdCitaNavigation { get; set; } = null!;
}
