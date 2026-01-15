using api.service.ro.application.commons.dtos;
using api.service.ro.application.commons.mappings;
using api.service.ro.application.ifeatures;
using api.service.ro.infrastructure;
using api.service.ro.domain.clases;

namespace api.service.ro.application.features;

public class MedicoHandler : IMedicoHandler
{
    private readonly Mappings _mapper;
    private readonly IMedicoContext _context;

    public MedicoHandler(IMedicoContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<MedicoResponseDto>> GetAll()
    {
        var lista = await _context.GetAllAsync();
        return _mapper.ToResponseDto(lista); // Mapperly generará esto automáticamente
    }

    public async Task<MedicoResponseDto?> GetById(int id)
    {
        var entidad = await _context.GetByIdAsync(id);
        return entidad == null ? null : _mapper.ToResponseDto(entidad);
    }

    public async Task<MedicoResponseDto> Insert(MedicoRequestDto request)
    {
        var entidad = _mapper.ToEntity(request);
        var guardada = await _context.InsertAsync(entidad);
        return _mapper.ToResponseDto(guardada);
    }

    public async Task<(bool Success, string? Message)> UpdateAsync(MedicoRequestDto request, int id)
    {
        var entidad = _mapper.ToEntity(request);
        entidad.IdMedico = id;
        
        // Retornamos la tupla directamente, resolviendo el error de deconstrucción
        return await _context.UpdateAsync(entidad);
    }

    public async Task<(bool Success, string? Message)> Delete(int id, bool softDelete)
    {
        return await _context.Delete(id, softDelete);
    }
}