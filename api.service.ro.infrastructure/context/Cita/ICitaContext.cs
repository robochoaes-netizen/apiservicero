using api.service.ro.domain.clases;

namespace api.service.ro.infrastructure;

public interface ICitaContext : IContextGeneral<Cita>
{
    Task<List<Cita>> GetAllAsync();
    Task<Cita?> GetByIdAsync(int id);
    Task<Cita> InsertAsync(Cita cita);
    Task<(bool Success, string? Message)> UpdateAsync(Cita cita);
    Task<(bool Success, string? Message)> Delete(int id, bool softDelete);
}