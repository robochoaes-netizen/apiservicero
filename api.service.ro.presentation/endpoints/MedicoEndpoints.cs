using api.service.ro.application.commons.dtos;
using api.service.ro.application.ifeatures; // Usamos el Handler
using Microsoft.AspNetCore.Mvc;

namespace api.service.ro.presentation.Endpoints
{
    public static class MedicoEndpoints
    {
        public static void MapMedicoEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/medicos").WithTags("Medicos");

            // 1. Obtener todos los médicos
            group.MapGet("/", async (IMedicoHandler handler) =>
            {
                var medicos = await handler.GetAll();
                return Results.Ok(medicos); // El handler ya devuelve DTOs
            });

            // 2. Obtener médico por ID
            group.MapGet("/{id}", async (int id, IMedicoHandler handler) =>
            {
                var medico = await handler.GetById(id);
                return medico is not null ? Results.Ok(medico) : Results.NotFound();
            });

            // 3. Crear médico
            group.MapPost("/", async ([FromBody] MedicoRequestDto medicoDto, IMedicoHandler handler) =>
            {
                var nuevoMedico = await handler.Insert(medicoDto);
                return Results.Created($"/api/medicos/{nuevoMedico.IdMedico}", nuevoMedico);
            });

            // 4. Actualizar médico
            group.MapPut("/{id}", async (int id, [FromBody] MedicoRequestDto medicoDto, IMedicoHandler handler) =>
            {
                // El handler encapsula la búsqueda, mapeo y deconstrucción de tuplas
                var (success, message) = await handler.UpdateAsync(medicoDto, id);
                return success ? Results.NoContent() : Results.BadRequest(message);
            });

            // 5. Eliminar médico
            group.MapDelete("/{id}", async (int id, IMedicoHandler handler, [FromQuery] bool softDelete = true) =>
            {
                var (success, message) = await handler.Delete(id, softDelete);
                return success ? Results.Ok(new { message = "Médico eliminado" }) : Results.NotFound(message);
            });
        }
    }
}