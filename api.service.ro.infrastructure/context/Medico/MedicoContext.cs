using api.service.ro.domain.clases;
using Microsoft.EntityFrameworkCore;

namespace api.service.ro.infrastructure;

public class MedicoContext : ContextGeneral<Medico>, IMedicoContext
{
    private readonly RoDbContext _context;

    public MedicoContext(RoDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Medico>> GetAllAsync()
    {
        // Traemos solo los médicos marcados como activos
        return await _context.Medicos
            .Where(m => m.Activo == true)
            .ToListAsync();
    }

    public async Task<Medico?> GetByIdAsync(int id)
    {
        // Reutiliza el método genérico del padre
        return await GetById(id);
    }

    public async Task<Medico> InsertAsync(Medico medico)
    {
        // Reutiliza el método genérico del padre
        return await Add(medico);
    }

    public async Task<(bool Success, string? Message)> UpdateAsync(Medico medico)
    {
        try
        {
            _context.Medicos.Update(medico);
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
            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null) return (false, "Médico no encontrado");

            if (softDelete)
            {
                // Borrado lógico (recomendado para Supabase/PostgreSQL)
                medico.Activo = false;
                _context.Medicos.Update(medico);
            }
            else
            {
                // Borrado físico
                _context.Medicos.Remove(medico);
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