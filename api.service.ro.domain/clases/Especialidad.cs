using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.service.ro.domain.clases;

[Table("especialidades", Schema = "rochoa")]
[Index("Nombre", Name = "especialidades_nombre_key", IsUnique = true)]
public partial class Especialidad
{
    [Key]
    [Column("id_especialidad")]
    public int IdEspecialidad { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Column("activo")]
    public bool? Activo { get; set; }

    [Column("creado_en", TypeName = "timestamp without time zone")]
    public DateTime? CreadoEn { get; set; }

    [Column("actualizado_en", TypeName = "timestamp without time zone")]
    public DateTime? ActualizadoEn { get; set; }

    [InverseProperty("IdEspecialidadNavigation")]
    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
