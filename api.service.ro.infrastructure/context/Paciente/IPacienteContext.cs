using api.service.ro.domain.clases;

namespace api.service.ro.infrastructure;

public interface IPacienteContext : IContextGeneral<Paciente>
{
    Task<List<Paciente>> GetAllAsync();
    Task<Paciente?> GetByIdAsync(int id);
    Task<Paciente> InsertAsync(Paciente paciente);
    Task<(bool Success, string? Message)> UpdateAsync(Paciente paciente);
    Task<(bool Success, string? Message)> Delete(int id, bool softDelete);
}