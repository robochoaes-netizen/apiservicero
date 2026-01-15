using api.service.ro.domain.clases;
using Microsoft.EntityFrameworkCore;

namespace api.service.ro.infrastructure;

public class PacienteContext : ContextGeneral<Paciente>, IPacienteContext
{
    private readonly RoDbContext _context;

    public PacienteContext(RoDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Paciente>> GetAllAsync()
    {
        // Solo traemos los pacientes activos
        return await _context.Pacientes
            .Where(p => p.Activo == true)
            .ToListAsync();
    }

    public async Task<Paciente?> GetByIdAsync(int id)
    {
        // Usa el método genérico heredado de ContextGeneral
        return await GetById(id);
    }

    public async Task<Paciente> InsertAsync(Paciente paciente)
    {
        // Usa el método genérico heredado de ContextGeneral
        return await Add(paciente);
    }

    public async Task<(bool Success, string? Message)> UpdateAsync(Paciente paciente)
    {
        try
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }

    public async Task<(bool Success, string? Message)> Delete(int id, bool softDelete)
    {
        try
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return (false, "Paciente no encontrado");

            if (softDelete)
            {
                // Borrado lógico: cambiamos el flag activo
                paciente.Activo = false;
                _context.Pacientes.Update(paciente);
            }
            else
            {
                // Borrado físico de la base de datos
                _context.Pacientes.Remove(paciente);
            }

            await _context.SaveChangesAsync();
            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}