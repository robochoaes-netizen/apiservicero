using api.service.ro.application.commons.dtos;
using api.service.ro.application.commons.mappings;
using api.service.ro.application.ifeatures;
using api.service.ro.infrastructure;
using api.service.ro.domain.clases;

namespace api.service.ro.application.features;

public class PacienteHandler : IPacienteHandler
{
    private readonly Mappings _mapper;
    private readonly IPacienteContext _context;

    public PacienteHandler(IPacienteContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<PacienteResponseDto>> GetAll()
    {
        var lista = await _context.GetAllAsync();
        return _mapper.ToResponseDto(lista); // Esto usa Mapperly para evitar el error CS1061
    }

    public async Task<PacienteResponseDto?> GetById(int id)
    {
        var entidad = await _context.GetByIdAsync(id);
        return entidad == null ? null : _mapper.ToResponseDto(entidad);
    }

    public async Task<PacienteResponseDto> Insert(PacienteRequestDto request)
    {
        var entidad = _mapper.ToEntity(request);
        var guardada = await _context.InsertAsync(entidad);
        return _mapper.ToResponseDto(guardada);
    }

    public async Task<(bool Success, string? Message)> UpdateAsync(PacienteRequestDto request, int id)
    {
        var entidad = _mapper.ToEntity(request);
        entidad.IdPaciente = id;
        return await _context.UpdateAsync(entidad); // Devolución directa de tupla para evitar CS8130
    }

    public async Task<(bool Success, string? Message)> Delete(int id, bool softDelete)
    {
        return await _context.Delete(id, softDelete);
    }
}