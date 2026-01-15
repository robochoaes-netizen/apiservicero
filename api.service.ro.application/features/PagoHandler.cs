using api.service.ro.application.commons.dtos;
using api.service.ro.application.commons.mappings;
using api.service.ro.application.ifeatures;
using api.service.ro.infrastructure;
using api.service.ro.domain.clases;

namespace api.service.ro.application.features;

public class PagoHandler : IPagoHandler
{
    private readonly Mappings _mapper;
    private readonly IPagoContext _context;

    public PagoHandler(IPagoContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<PagoResponseDto>> GetAll()
    {
        var lista = await _context.GetAllAsync();
        // Mapperly usará la firma de la lista para generar el código
        return _mapper.ToResponseDto(lista); 
    }

    public async Task<PagoResponseDto?> GetById(int id)
    {
        var entidad = await _context.GetByIdAsync(id);
        return entidad == null ? null : _mapper.ToResponseDto(entidad);
    }

    public async Task<PagoResponseDto> Insert(PagoRequestDto request)
    {
        var entidad = _mapper.ToEntity(request);
        var guardada = await _context.InsertAsync(entidad);
        return _mapper.ToResponseDto(guardada);
    }

    public async Task<(bool Success, string? Message)> UpdateAsync(PagoRequestDto request, int id)
    {
        var entidad = _mapper.ToEntity(request);
        entidad.IdPago = id;
        // La deconstrucción explícita previene el error CS8130 de tus capturas
        return await _context.UpdateAsync(entidad);
    }

    public async Task<(bool Success, string? Message)> Delete(int id, bool softDelete)
    {
        return await _context.Delete(id, softDelete);
    }
}
