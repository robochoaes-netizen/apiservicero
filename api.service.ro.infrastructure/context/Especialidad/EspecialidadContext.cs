using api.service.ro.domain.clases;
using Microsoft.EntityFrameworkCore;

namespace api.service.ro.infrastructure;

public class EspecialidadContext : ContextGeneral<Especialidad>, IEspecialidadContext
{
    private readonly RoDbContext _context;

    public EspecialidadContext(RoDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Especialidad>> GetAllAsync()
    {
        // Traemos solo las especialidades marcadas como activas
        return await _context.Especialidades
            .Where(e => e.Activo == true)
            .ToListAsync();
    }

    public async Task<Especialidad?> GetByIdAsync(int id)
    {
        // Reutiliza el método genérico del padre
        return await GetById(id);
    }

    public async Task<Especialidad> InsertAsync(Especialidad especialidad)
    {
        // Reutiliza el método genérico del padre
        return await Add(especialidad);
    }

    public async Task<(bool Success, string? Message)> UpdateAsync(Especialidad especialidad)
    {
        try
        {
            _context.Especialidades.Update(especialidad);
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
            var especialidad = await _context.Especialidades.FindAsync(id);
            if (especialidad == null) return (false, "Especialidad no encontrada");

            if (softDelete)
            {
                // Borrado lógico
                especialidad.Activo = false;
                _context.Especialidades.Update(especialidad);
            }
            else
            {
                // Borrado físico
                _context.Especialidades.Remove(especialidad);
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