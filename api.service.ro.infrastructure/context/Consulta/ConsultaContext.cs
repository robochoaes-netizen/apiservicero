using api.service.ro.domain.clases;
using Microsoft.EntityFrameworkCore;

namespace api.service.ro.infrastructure;

public class ConsultaContext : ContextGeneral<Consulta>, IConsultaContext
{
    private readonly RoDbContext _context;

    public ConsultaContext(RoDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Consulta>> GetAllAsync()
    {
        // Traemos las consultas activas e incluimos la información de la cita relacionada
        return await _context.Consultas
            .Include(c => c.IdCitaNavigation)
            .Where(c => c.Activo == true)
            .ToListAsync();
    }

    public async Task<Consulta?> GetByIdAsync(int id)
    {
        // Buscamos por ID incluyendo la relación con la cita
        return await _context.Consultas
            .Include(c => c.IdCitaNavigation)
            .FirstOrDefaultAsync(c => c.IdConsulta == id);
    }

    public async Task<Consulta> InsertAsync(Consulta consulta)
    {
        return await Add(consulta);
    }

    public async Task<(bool Success, string? Message)> UpdateAsync(Consulta consulta)
    {
        try
        {
            _context.Consultas.Update(consulta);
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
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null) return (false, "Consulta no encontrada");

            if (softDelete)
            {
                consulta.Activo = false;
                _context.Consultas.Update(consulta);
            }
            else
            {
                _context.Consultas.Remove(consulta);
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