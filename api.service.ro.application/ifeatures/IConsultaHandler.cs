using api.service.ro.application.commons.dtos;

namespace api.service.ro.application.ifeatures;

public interface IConsultaHandler
{
    Task<List<ConsultaResponseDto>> GetAll();
    Task<ConsultaResponseDto?> GetById(int id);
    Task<ConsultaResponseDto> Insert(ConsultaRequestDto request);
    Task<(bool Success, string? Message)> UpdateAsync(ConsultaRequestDto request, int id);
    Task<(bool Success, string? Message)> Delete(int id, bool softDelete);
}