using api.service.ro.application.commons.dtos;
using api.service.ro.application.ifeatures;
using Microsoft.AspNetCore.Mvc;

namespace api.service.ro.presentation.Endpoints
{
    public static class CitaEndpoints
    {
        public static void MapCitaEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/citas").WithTags("Citas");

            // 1. Obtener todas las citas
            group.MapGet("/", async (ICitaHandler handler) =>
            {
                var citas = await handler.GetAll();
                return Results.Ok(citas);
            });

            // 2. Obtener cita por ID
            group.MapGet("/{id}", async (int id, ICitaHandler handler) =>
            {
                var cita = await handler.GetById(id);
                return cita is not null ? Results.Ok(cita) : Results.NotFound();
            });

            // 3. Crear una nueva cita
            group.MapPost("/", async ([FromBody] CitaRequestDto citaDto, ICitaHandler handler) =>
            {
                var nuevaCita = await handler.Insert(citaDto);
                return Results.Created($"/api/citas/{nuevaCita.IdCita}", nuevaCita);
            });

            // 4. Actualizar cita
            group.MapPut("/{id}", async (int id, [FromBody] CitaRequestDto citaDto, ICitaHandler handler) =>
            {
                var (success, message) = await handler.UpdateAsync(citaDto, id);
                return success ? Results.NoContent() : Results.BadRequest(message);
            });

            // 5. Eliminar cita
            group.MapDelete("/{id}", async (int id, ICitaHandler handler, [FromQuery] bool softDelete = true) =>
            {
                var (success, message) = await handler.Delete(id, softDelete);
                return success ? Results.Ok(new { message = "Cita eliminada correctamente" }) : Results.NotFound(message);
            });
        }
    }
}