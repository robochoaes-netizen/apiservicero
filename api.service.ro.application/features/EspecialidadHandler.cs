using api.service.ro.application.commons.dtos;
using api.service.ro.application.commons.mappings;
using api.service.ro.application.ifeatures;
using api.service.ro.infrastructure;
using api.service.ro.domain.clases;

namespace api.service.ro.application.features;

public class EspecialidadHandler : IEspecialidadHandler
{
    private readonly Mappings _mapper;
    private readonly IEspecialidadContext _context;

    public EspecialidadHandler(IEspecialidadContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<EspecialidadResponseDto>> GetAll()
    {
        var lista = await _context.GetAllAsync();
        // Mapperly generará este método automáticamente
        return _mapper.ToResponseDto(lista);
    }

    public async Task<EspecialidadResponseDto?> GetById(int id)
    {
        var entidad = await _context.GetByIdAsync(id);
        return entidad == null ? null : _mapper.ToResponseDto(entidad);
    }

    public async Task<EspecialidadResponseDto> Insert(EspecialidadRequestDto request)
    {
        var entidad = _mapper.ToEntity(request);
        var guardada = await _context.InsertAsync(entidad);
        return _mapper.ToResponseDto(guardada);
    }

    public async Task<(bool Success, string? Message)> UpdateAsync(EspecialidadRequestDto request, int id)
    {
        var entidad = _mapper.ToEntity(request);
        entidad.IdEspecialidad = id;
        
        // Aquí se resuelve el error de inferencia CS8130
        var result = await _context.UpdateAsync(entidad);
        return result;
    }

    public async Task<(bool Success, string? Message)> Delete(int id, bool softDelete)
    {
        return await _context.Delete(id, softDelete);
    }
}