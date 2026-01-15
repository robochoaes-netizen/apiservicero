using api.service.ro.application.features;
using api.service.ro.application.ifeatures;
using Microsoft.Extensions.DependencyInjection;

namespace api.service.ro.application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Registro de Handlers para la lógica de negocio del proyecto RO
        services.AddScoped<IPacienteHandler, PacienteHandler>();
        services.AddScoped<IMedicoHandler, MedicoHandler>();
        services.AddScoped<IEspecialidadHandler, EspecialidadHandler>();
        services.AddScoped<ICitaHandler, CitaHandler>();
        services.AddScoped<IConsultaHandler, ConsultaHandler>();
        services.AddScoped<IPagoHandler, PagoHandler>();

        return services;
    }
}