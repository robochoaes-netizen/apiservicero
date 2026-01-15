using api.service.ro.domain.clases;

namespace api.service.ro.infrastructure;

public interface IConsultaContext : IContextGeneral<Consulta>
{
    Task<List<Consulta>> GetAllAsync();
    Task<Consulta?> GetByIdAsync(int id);
    Task<Consulta> InsertAsync(Consulta consulta);
    Task<(bool Success, string? Message)> UpdateAsync(Consulta consulta);
    Task<(bool Success, string? Message)> Delete(int id, bool softDelete);
}