using api.service.ro.application.commons.dtos;

namespace api.service.ro.application.ifeatures;

public interface ICitaHandler
{
    Task<List<CitaResponseDto>> GetAll();
    Task<CitaResponseDto?> GetById(int id);
    Task<CitaResponseDto> Insert(CitaRequestDto citaRequest);
    Task<(bool Success, string? Message)> UpdateAsync(CitaRequestDto citaRequest, int id);
    Task<(bool Success, string? Message)> Delete(int id, bool softDelete);
}