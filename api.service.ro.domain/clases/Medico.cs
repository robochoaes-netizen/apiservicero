using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.service.ro.domain.clases;

[Table("medicos", Schema = "rochoa")]
[Index("Email", Name = "medicos_email_key", IsUnique = true)]
[Index("Identificacion", Name = "medicos_identificacion_key", IsUnique = true)]
public partial class Medico
{
    [Key]
    [Column("id_medico")]
    public int IdMedico { get; set; }

    [Column("id_especialidad")]
    public int IdEspecialidad { get; set; }

    [Column("identificacion")]
    [StringLength(15)]
    public string Identificacion { get; set; } = null!;

    [Column("nombres")]
    [StringLength(100)]
    public string Nombres { get; set; } = null!;

    [Column("apellidos")]
    [StringLength(100)]
    public string Apellidos { get; set; } = null!;

    [Column("telefono")]
    [StringLength(20)]
    public string? Telefono { get; set; }

    [Column("email")]
    [StringLength(150)]
    public string? Email { get; set; }

    [Column("activo")]
    public bool? Activo { get; set; }

    [Column("creado_en", TypeName = "timestamp without time zone")]
    public DateTime? CreadoEn { get; set; }

    [Column("actualizado_en", TypeName = "timestamp without time zone")]
    public DateTime? ActualizadoEn { get; set; }

    [InverseProperty("IdMedicoNavigation")]
    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    [ForeignKey("IdEspecialidad")]
    [InverseProperty("Medicos")]
    public virtual Especialidad IdEspecialidadNavigation { get; set; } = null!;
}
