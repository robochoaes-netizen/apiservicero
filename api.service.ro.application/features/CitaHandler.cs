using api.service.ro.application.commons.dtos;
using api.service.ro.application.commons.mappings;
using api.service.ro.application.ifeatures;
using api.service.ro.infrastructure;
using api.service.ro.domain.clases;

namespace api.service.ro.application.features;

public class CitaHandler : ICitaHandler
{
    private readonly Mappings _mapper;
    private readonly ICitaContext _context;

    // Inyectamos el contexto de infraestructura que ya tienes configurado
    public CitaHandler(ICitaContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<CitaResponseDto>> GetAll()
    {
        var citas = await _context.GetAllAsync();
        return _mapper.ToResponseDto(citas);
    }

    public async Task<CitaResponseDto?> GetById(int id)
    {
        var cita = await _context.GetByIdAsync(id);
        return cita == null ? null : _mapper.ToResponseDto(cita);
    }

    public async Task<CitaResponseDto> Insert(CitaRequestDto citaRequest)
    { 
        var cita = _mapper.ToEntity(citaRequest);
        var citaGuardada = await _context.InsertAsync(cita);
        return _mapper.ToResponseDto(citaGuardada);
    }

    public async Task<(bool Success, string? Message)> UpdateAsync(CitaRequestDto citaRequest, int id)
    { 
        var cita = _mapper.ToEntity(citaRequest);
        cita.IdCita = id; // Aseguramos que el ID coincida con la ruta
        
        // Aquí se resuelve el error CS8130 de tus imágenes previas
        return await _context.UpdateAsync(cita);
    }

    public async Task<(bool Success, string? Message)> Delete(int id, bool softDelete)
    { 
        return await _context.Delete(id, softDelete);
    }
}