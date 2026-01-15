using api.service.ro.application.commons.dtos;
using api.service.ro.application.ifeatures; // Usamos la interfaz del handler
using Microsoft.AspNetCore.Mvc;

namespace api.service.ro.presentation.Endpoints
{
    public static class ConsultaEndpoints
    {
        public static void MapConsultaEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/consultas").WithTags("Consultas");

            // 1. Obtener todas las consultas
            group.MapGet("/", async (IConsultaHandler handler) =>
            {
                var consultas = await handler.GetAll();
                return Results.Ok(consultas);
            });

            // 2. Obtener consulta por ID
            group.MapGet("/{id}", async (int id, IConsultaHandler handler) =>
            {
                var consulta = await handler.GetById(id);
                return consulta is not null ? Results.Ok(consulta) : Results.NotFound();
            });

            // 3. Crear una nueva consulta
            group.MapPost("/", async ([FromBody] ConsultaRequestDto consultaDto, IConsultaHandler handler) =>
            {
                var nuevaConsulta = await handler.Insert(consultaDto);
                return Results.Created($"/api/consultas/{nuevaConsulta.IdConsulta}", nuevaConsulta);
            });

            // 4. Actualizar consulta existente
            group.MapPut("/{id}", async (int id, [FromBody] ConsultaRequestDto consultaDto, IConsultaHandler handler) =>
            {
                var (success, message) = await handler.UpdateAsync(consultaDto, id);
                return success ? Results.NoContent() : Results.BadRequest(message);
            });

            // 5. Eliminar consulta
            group.MapDelete("/{id}", async (int id, IConsultaHandler handler, [FromQuery] bool softDelete = true) =>
            {
                var (success, message) = await handler.Delete(id, softDelete);
                return success ? Results.Ok(new { message = "Consulta eliminada" }) : Results.NotFound(message);
            });
        }
    }
}