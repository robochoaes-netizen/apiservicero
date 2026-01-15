using api.service.ro.domain.clases;
using Microsoft.EntityFrameworkCore;

namespace api.service.ro.infrastructure;

public class PagoContext : ContextGeneral<Pago>, IPagoContext
{
    private readonly RoDbContext _context;

    public PagoContext(RoDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Pago>> GetAllAsync()
    {
        // Retornamos pagos activos incluyendo información de la cita
        return await _context.Pagos
            .Include(p => p.IdCitaNavigation)
            .Where(p => p.Activo == true)
            .ToListAsync();
    }

    public async Task<Pago?> GetByIdAsync(int id)
    {
        return await _context.Pagos
            .Include(p => p.IdCitaNavigation)
            .FirstOrDefaultAsync(p => p.IdPago == id);
    }

    public async Task<Pago> InsertAsync(Pago pago)
    {
        // Reutiliza el método Add del ContextGeneral
        return await Add(pago);
    }

    public async Task<(bool Success, string? Message)> UpdateAsync(Pago pago)
    {
        try
        {
            _context.Pagos.Update(pago);
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
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null) return (false, "Pago no encontrado");

            if (softDelete)
            {
                pago.Activo = false;
                _context.Pagos.Update(pago);
            }
            else
            {
                _context.Pagos.Remove(pago);
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