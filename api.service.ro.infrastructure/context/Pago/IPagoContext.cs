using api.service.ro.domain.clases;

namespace api.service.ro.infrastructure;

public interface IPagoContext : IContextGeneral<Pago>
{
    Task<List<Pago>> GetAllAsync();
    Task<Pago?> GetByIdAsync(int id);
    Task<Pago> InsertAsync(Pago pago);
    Task<(bool Success, string? Message)> UpdateAsync(Pago pago);
    Task<(bool Success, string? Message)> Delete(int id, bool softDelete);
}