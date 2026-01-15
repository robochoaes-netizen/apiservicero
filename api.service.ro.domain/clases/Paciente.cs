using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.service.ro.domain.clases;

[Table("pacientes", Schema = "rochoa")]
[Index("Email", Name = "pacientes_email_key", IsUnique = true)]
[Index("Identificacion", Name = "pacientes_identificacion_key", IsUnique = true)]
public partial class Paciente
{
    [Key]
    [Column("id_paciente")]
    public int IdPaciente { get; set; }

    [Column("identificacion")]
    [StringLength(15)]
    public string Identificacion { get; set; } = null!;

    [Column("nombres")]
    [StringLength(100)]
    public string Nombres { get; set; } = null!;

    [Column("apellidos")]
    [StringLength(100)]
    public string Apellidos { get; set; } = null!;

    [Column("fecha_nacimiento")]
    public DateOnly FechaNacimiento { get; set; }

    [Column("sexo")]
    [MaxLength(1)]
    public char? Sexo { get; set; }

    [Column("telefono")]
    [StringLength(20)]
    public string? Telefono { get; set; }

    [Column("email")]
    [StringLength(150)]
    public string? Email { get; set; }

    [Column("direccion")]
    public string? Direccion { get; set; }

    [Column("activo")]
    public bool? Activo { get; set; }

    [Column("creado_en", TypeName = "timestamp without time zone")]
    public DateTime? CreadoEn { get; set; }

    [Column("actualizado_en", TypeName = "timestamp without time zone")]
    public DateTime? ActualizadoEn { get; set; }

    [InverseProperty("IdPacienteNavigation")]
    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
