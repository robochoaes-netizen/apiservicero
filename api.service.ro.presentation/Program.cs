using api.service.ro.infrastructure;
using api.service.ro.presentation.Endpoints;
using api.service.ro.application; // Importante para reconocer AddApplicationServices

var builder = WebApplication.CreateBuilder(args);

// 1. Registro de Servicios de las Capas
// Registrar Infraestructura (Contextos y Repositorios)
builder.Services.AddInfrastructure(builder.Configuration); 

// Registrar Aplicación (Handlers y Lógica de Negocio)
// Esto soluciona los errores de los Handlers que no se encontraban
builder.Services.AddApplicationServices(); 

// 2. Configuración de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Configuración del Pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    // Esto resuelve el error visual de Swagger en tu captura
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// 4. Mapeo de Endpoints
// Asegúrate de que estos métodos existan en tus clases estáticas de Endpoints
app.MapPacienteEndpoints();
app.MapCitaEndpoints();
app.MapMedicoEndpoints();
app.MapConsultaEndpoints();
app.MapPagoEndpoints();
app.MapEspecialidadEndpoints();

app.Run();