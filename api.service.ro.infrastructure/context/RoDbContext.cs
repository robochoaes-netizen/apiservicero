using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api.service.ro.domain.clases;

namespace api.service.ro.infrastructure;

public partial class RoDbContext : DbContext
{
    public RoDbContext(DbContextOptions<RoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Consulta> Consultas { get; set; }

    public virtual DbSet<Especialidad> Especialidades { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "oauth_authorization_status", new[] { "pending", "approved", "denied", "expired" })
            .HasPostgresEnum("auth", "oauth_client_type", new[] { "public", "confidential" })
            .HasPostgresEnum("auth", "oauth_registration_type", new[] { "dynamic", "manual" })
            .HasPostgresEnum("auth", "oauth_response_type", new[] { "code" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" })
            .HasPostgresEnum("storage", "buckettype", new[] { "STANDARD", "ANALYTICS", "VECTOR" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("citas_pkey");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Estado).HasDefaultValueSql("'PROGRAMADA'::character varying");
            entity.Property(e => e.IdMedico).ValueGeneratedOnAdd();
            entity.Property(e => e.IdPaciente).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.Cita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cita_medico");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Cita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cita_paciente");
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasKey(e => e.IdConsulta).HasName("consultas_pkey");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IdCita).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdCitaNavigation).WithOne(p => p.Consulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_consulta_cita");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("especialidades_pkey");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("medicos_pkey");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IdEspecialidad).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Medicos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_medico_especialidad");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("pacientes_pkey");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("pagos_pkey");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IdCita).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdCitaNavigation).WithMany(p => p.Pagos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pago_cita");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
