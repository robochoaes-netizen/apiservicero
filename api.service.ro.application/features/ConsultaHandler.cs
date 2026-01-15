using api.service.ro.application.commons.dtos;
using api.service.ro.application.commons.mappings;
using api.service.ro.application.ifeatures;
using api.service.ro.infrastructure;
using api.service.ro.domain.clases;

namespace api.service.ro.application.features;

public class ConsultaHandler : IConsultaHandler
{
    private readonly Mappings _mapper;
    private readonly IConsultaContext _context;

    public ConsultaHandler(IConsultaContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<ConsultaResponseDto>> GetAll()
    {
        var lista = await _context.GetAllAsync();
        return _mapper.ToResponseDto(lista); // Mapperly generará este método
    }

    public async Task<ConsultaResponseDto?> GetById(int id)
    {
        var entidad = await _context.GetByIdAsync(id);
        return entidad == null ? null : _mapper.ToResponseDto(entidad);
    }

    public async Task<ConsultaResponseDto> Insert(ConsultaRequestDto request)
    {
        var entidad = _mapper.ToEntity(request);
        var guardada = await _context.InsertAsync(entidad);
        return _mapper.ToResponseDto(guardada);
    }

    public async Task<(bool Success, string? Message)> UpdateAsync(ConsultaRequestDto request, int id)
    {
        var entidad = _mapper.ToEntity(request);
        entidad.IdConsulta = id; 
        // El uso de tipos explícitos aquí previene el error CS8130
        return await _context.UpdateAsync(entidad);
    }

    public async Task<(bool Success, string? Message)> Delete(int id, bool softDelete)
    {
        return await _context.Delete(id, softDelete);
    }
}