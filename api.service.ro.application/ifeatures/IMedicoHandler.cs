using api.service.ro.application.commons.dtos;

namespace api.service.ro.application.ifeatures;

public interface IMedicoHandler
{
    Task<List<MedicoResponseDto>> GetAll();
    Task<MedicoResponseDto?> GetById(int id);
    Task<MedicoResponseDto> Insert(MedicoRequestDto request);
    Task<(bool Success, string? Message)> UpdateAsync(MedicoRequestDto request, int id);
    Task<(bool Success, string? Message)> Delete(int id, bool softDelete);
}