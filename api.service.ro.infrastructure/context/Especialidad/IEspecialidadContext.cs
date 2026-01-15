using api.service.ro.domain.clases;

namespace api.service.ro.infrastructure;

public interface IEspecialidadContext : IContextGeneral<Especialidad>
{
    Task<List<Especialidad>> GetAllAsync();
    Task<Especialidad?> GetByIdAsync(int id);
    Task<Especialidad> InsertAsync(Especialidad especialidad);
    Task<(bool Success, string? Message)> UpdateAsync(Especialidad especialidad);
    Task<(bool Success, string? Message)> Delete(int id, bool softDelete);
}