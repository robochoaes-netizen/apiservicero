using api.service.ro.infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api.service.ro.infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. Conexión a Base de Datos (PostgreSQL - Supabase)
        services.AddDbContext<RoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        // 2. Registro del Repositorio Genérico
        services.AddScoped(typeof(IContextGeneral<>), typeof(ContextGeneral<>));

        // 3. Registro de Contextos Específicos (Repositorios especializados)
        services.AddScoped<IMedicoContext, MedicoContext>();
        services.AddScoped<IPacienteContext, PacienteContext>();
        services.AddScoped<ICitaContext, CitaContext>();
        services.AddScoped<IConsultaContext, ConsultaContext>();
        services.AddScoped<IEspecialidadContext, EspecialidadContext>();
        services.AddScoped<IPagoContext, PagoContext>();

        return services;
    }
}