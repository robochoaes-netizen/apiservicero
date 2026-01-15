using api.service.ro.domain.clases;
using Microsoft.EntityFrameworkCore;

namespace api.service.ro.infrastructure;

public class CitaContext : ContextGeneral<Cita>, ICitaContext
{
    private readonly RoDbContext _context;

    public CitaContext(RoDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Cita>> GetAllAsync()
    {
        // Traemos las citas activas incluyendo Médico y Paciente para tener la información completa
        return await _context.Citas
            .Include(c => c.IdMedicoNavigation)
            .Include(c => c.IdPacienteNavigation)
            .Where(c => c.Activo == true)
            .ToListAsync();
    }

    public async Task<Cita?> GetByIdAsync(int id)
    {
        return await _context.Citas
            .Include(c => c.IdMedicoNavigation)
            .Include(c => c.IdPacienteNavigation)
            .Include(c => c.Consulta) // Opcional: incluir la consulta si ya se realizó
            .FirstOrDefaultAsync(c => c.IdCita == id);
    }

    public async Task<Cita> InsertAsync(Cita cita)
    {
        // El estado por defecto suele ser 'PROGRAMADA'
        return await Add(cita);
    }

    public async Task<(bool Success, string? Message)> UpdateAsync(Cita cita)
    {
        try
        {
            _context.Citas.Update(cita);
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
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null) return (false, "Cita no encontrada");

            if (softDelete)
            {
                cita.Activo = false;
                // Podrías cambiar el estado a 'CANCELADA' aquí también si lo deseas
                cita.Estado = "CANCELADA"; 
                _context.Citas.Update(cita);
            }
            else
            {
                _context.Citas.Remove(cita);
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