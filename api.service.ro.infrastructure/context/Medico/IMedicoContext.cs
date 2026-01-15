using api.service.ro.domain.clases;

namespace api.service.ro.infrastructure;

public interface IMedicoContext : IContextGeneral<Medico>
{
    Task<List<Medico>> GetAllAsync();
    Task<Medico?> GetByIdAsync(int id);
    Task<Medico> InsertAsync(Medico medico);
    Task<(bool Success, string? Message)> UpdateAsync(Medico medico);
    Task<(bool Success, string? Message)> Delete(int id, bool softDelete);
}