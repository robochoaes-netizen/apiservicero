using api.service.ro.application.commons.dtos;

namespace api.service.ro.application.ifeatures;

public interface IPacienteHandler
{
    Task<List<PacienteResponseDto>> GetAll();
    Task<PacienteResponseDto?> GetById(int id);
    Task<PacienteResponseDto> Insert(PacienteRequestDto request);
    Task<(bool Success, string? Message)> UpdateAsync(PacienteRequestDto request, int id);
    Task<(bool Success, string? Message)> Delete(int id, bool softDelete);
}