using api.service.ro.application.commons.dtos;

namespace api.service.ro.application.ifeatures;

public interface IPagoHandler
{
    Task<List<PagoResponseDto>> GetAll();
    Task<PagoResponseDto?> GetById(int id);
    Task<PagoResponseDto> Insert(PagoRequestDto request);
    Task<(bool Success, string? Message)> UpdateAsync(PagoRequestDto request, int id);
    Task<(bool Success, string? Message)> Delete(int id, bool softDelete);
}