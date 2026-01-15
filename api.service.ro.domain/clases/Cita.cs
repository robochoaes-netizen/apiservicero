using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.service.ro.domain.clases;

[Table("citas", Schema = "rochoa")]
public partial class Cita
{
    [Key]
    [Column("id_cita")]
    public int IdCita { get; set; }

    [Column("id_paciente")]
    public int IdPaciente { get; set; }

    [Column("id_medico")]
    public int IdMedico { get; set; }

    [Column("fecha")]
    public DateOnly Fecha { get; set; }

    [Column("hora")]
    public TimeOnly Hora { get; set; }

    [Column("estado")]
    [StringLength(20)]
    public string? Estado { get; set; }

    [Column("activo")]
    public bool? Activo { get; set; }

    [Column("creado_en", TypeName = "timestamp without time zone")]
    public DateTime? CreadoEn { get; set; }

    [Column("actualizado_en", TypeName = "timestamp without time zone")]
    public DateTime? ActualizadoEn { get; set; }

    [InverseProperty("IdCitaNavigation")]
    public virtual Consulta? Consulta { get; set; }

    [ForeignKey("IdMedico")]
    [InverseProperty("Cita")]
    public virtual Medico IdMedicoNavigation { get; set; } = null!;

    [ForeignKey("IdPaciente")]
    [InverseProperty("Cita")]
    public virtual Paciente IdPacienteNavigation { get; set; } = null!;

    [InverseProperty("IdCitaNavigation")]
    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
