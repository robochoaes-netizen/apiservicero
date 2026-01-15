using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.service.ro.domain.clases;

[Table("consultas", Schema = "rochoa")]
[Index("IdCita", Name = "consultas_id_cita_key", IsUnique = true)]
public partial class Consulta
{
    [Key]
    [Column("id_consulta")]
    public int IdConsulta { get; set; }

    [Column("id_cita")]
    public int IdCita { get; set; }

    [Column("motivo_consulta")]
    public string MotivoConsulta { get; set; } = null!;

    [Column("diagnostico")]
    public string? Diagnostico { get; set; }

    [Column("tratamiento")]
    public string? Tratamiento { get; set; }

    [Column("observaciones")]
    public string? Observaciones { get; set; }

    [Column("activo")]
    public bool? Activo { get; set; }

    [Column("creado_en", TypeName = "timestamp without time zone")]
    public DateTime? CreadoEn { get; set; }

    [Column("actualizado_en", TypeName = "timestamp without time zone")]
    public DateTime? ActualizadoEn { get; set; }

    [ForeignKey("IdCita")]
    [InverseProperty("Consulta")]
    public virtual Cita IdCitaNavigation { get; set; } = null!;
}
