using api.service.ro.application.commons.dtos;
using api.service.ro.domain.clases;
using Riok.Mapperly.Abstractions;

namespace api.service.ro.application.commons.mappings;

[Mapper]
public partial class Mappings
{
    // --- PACIENTES ---
    public partial PacienteResponseDto ToResponseDto(Paciente paciente);
    public partial List<PacienteResponseDto> ToResponseDto(List<Paciente> pacientes);
    public partial Paciente ToEntity(PacienteRequestDto pacienteRequestDto);

    // --- MEDICOS ---
    public partial MedicoResponseDto ToResponseDto(Medico medico);
    public partial List<MedicoResponseDto> ToResponseDto(List<Medico> medicos);
    public partial Medico ToEntity(MedicoRequestDto medicoRequestDto);

    // --- ESPECIALIDADES ---
    // Usamos Especialidade para que coincida con tu entidad del dominio
    public partial EspecialidadResponseDto ToResponseDto(Especialidad especialidad);
    public partial List<EspecialidadResponseDto> ToResponseDto(List<Especialidad> especialidades);
    public partial Especialidad ToEntity(EspecialidadRequestDto especialidadRequestDto);

    // --- CITAS ---
    public partial CitaResponseDto ToResponseDto(Cita cita);
    public partial List<CitaResponseDto> ToResponseDto(List<Cita> citas);
    public partial Cita ToEntity(CitaRequestDto citaRequestDto);

    // --- CONSULTAS ---
    public partial ConsultaResponseDto ToResponseDto(Consulta consulta);
    public partial List<ConsultaResponseDto> ToResponseDto(List<Consulta> consultas);
    public partial Consulta ToEntity(ConsultaRequestDto consultaRequestDto);

    // --- PAGOS ---
    public partial PagoResponseDto ToResponseDto(Pago pago);
    public partial List<PagoResponseDto> ToResponseDto(List<Pago> pagos);
    public partial Pago ToEntity(PagoRequestDto pagoRequestDto);
}