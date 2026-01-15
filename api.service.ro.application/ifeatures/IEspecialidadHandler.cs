using api.service.ro.application.commons.dtos;

namespace api.service.ro.application.ifeatures;

public interface IEspecialidadHandler
{
    Task<List<EspecialidadResponseDto>> GetAll();
    Task<EspecialidadResponseDto?> GetById(int id);
    Task<EspecialidadResponseDto> Insert(EspecialidadRequestDto request);
    Task<(bool Success, string? Message)> UpdateAsync(EspecialidadRequestDto request, int id);
    Task<(bool Success, string? Message)> Delete(int id, bool softDelete);
}