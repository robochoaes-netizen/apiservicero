using api.service.ro.application.commons.dtos;
using api.service.ro.application.ifeatures; // Usamos el Handler
using Microsoft.AspNetCore.Mvc;

namespace api.service.ro.presentation.Endpoints
{
    public static class PacienteEndpoints
    {
        public static void MapPacienteEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/pacientes").WithTags("Pacientes");

            // 1. Obtener todos los pacientes
            group.MapGet("/", async (IPacienteHandler handler) =>
            {
                var pacientes = await handler.GetAll();
                return Results.Ok(pacientes);
            });

            // 2. Obtener por ID
            group.MapGet("/{id}", async (int id, IPacienteHandler handler) =>
            {
                var paciente = await handler.GetById(id);
                return paciente is not null ? Results.Ok(paciente) : Results.NotFound();
            });

            // 3. Crear paciente
            group.MapPost("/", async ([FromBody] PacienteRequestDto pacienteDto, IPacienteHandler handler) =>
            {
                var nuevo = await handler.Insert(pacienteDto);
                return Results.Created($"/api/pacientes/{nuevo.IdPaciente}", nuevo);
            });

            // 4. Actualizar paciente
            group.MapPut("/{id}", async (int id, [FromBody] PacienteRequestDto pacienteDto, IPacienteHandler handler) =>
            {
                // El handler encapsula el mapeo y la deconstrucción de la tupla
                var (success, message) = await handler.UpdateAsync(pacienteDto, id);
                return success ? Results.NoContent() : Results.BadRequest(message);
            });

            // 5. Eliminar paciente
            group.MapDelete("/{id}", async (int id, IPacienteHandler handler, [FromQuery] bool softDelete = true) =>
            {
                var (success, message) = await handler.Delete(id, softDelete);
                return success ? Results.Ok(new { message = "Paciente eliminado correctamente" }) : Results.NotFound(message);
            });
        }
    }
}