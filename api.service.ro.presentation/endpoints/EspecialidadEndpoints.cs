using api.service.ro.application.commons.dtos;
using api.service.ro.application.ifeatures; // Usamos la interfaz del handler
using Microsoft.AspNetCore.Mvc;

namespace api.service.ro.presentation.Endpoints
{
    public static class EspecialidadEndpoints
    {
        public static void MapEspecialidadEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/especialidades").WithTags("Especialidades");

            // 1. Obtener todas las especialidades
            group.MapGet("/", async (IEspecialidadHandler handler) =>
            {
                var especialidades = await handler.GetAll();
                return Results.Ok(especialidades);
            });

            // 2. Obtener especialidad por ID
            group.MapGet("/{id}", async (int id, IEspecialidadHandler handler) =>
            {
                var especialidad = await handler.GetById(id);
                return especialidad is not null ? Results.Ok(especialidad) : Results.NotFound();
            });

            // 3. Crear una nueva especialidad
            group.MapPost("/", async ([FromBody] EspecialidadRequestDto especialidadDto, IEspecialidadHandler handler) =>
            {
                var nueva = await handler.Insert(especialidadDto);
                return Results.Created($"/api/especialidades/{nueva.IdEspecialidad}", nueva);
            });

            // 4. Actualizar especialidad
            group.MapPut("/{id}", async (int id, [FromBody] EspecialidadRequestDto especialidadDto, IEspecialidadHandler handler) =>
            {
                // El handler maneja internamente la búsqueda y el mapeo
                var (success, message) = await handler.UpdateAsync(especialidadDto, id);
                return success ? Results.NoContent() : Results.BadRequest(message);
            });

            // 5. Eliminar especialidad
            group.MapDelete("/{id}", async (int id, IEspecialidadHandler handler, [FromQuery] bool softDelete = true) =>
            {
                var (success, message) = await handler.Delete(id, softDelete);
                return success ? Results.Ok(new { message = "Especialidad eliminada" }) : Results.NotFound(message);
            });
        }
    }
}