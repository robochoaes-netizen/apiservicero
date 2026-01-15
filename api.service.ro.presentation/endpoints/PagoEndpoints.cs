using api.service.ro.application.commons.dtos;
using api.service.ro.application.ifeatures; // Usamos el Handler
using Microsoft.AspNetCore.Mvc;

namespace api.service.ro.presentation.Endpoints
{
    public static class PagoEndpoints
    {
        public static void MapPagoEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/pagos").WithTags("Pagos");

            // 1. Obtener todos los pagos
            group.MapGet("/", async (IPagoHandler handler) =>
            {
                var pagos = await handler.GetAll();
                return Results.Ok(pagos);
            });

            // 2. Obtener pago por ID
            group.MapGet("/{id}", async (int id, IPagoHandler handler) =>
            {
                var pago = await handler.GetById(id);
                return pago is not null ? Results.Ok(pago) : Results.NotFound();
            });

            // 3. Registrar un nuevo pago
            group.MapPost("/", async ([FromBody] PagoRequestDto pagoDto, IPagoHandler handler) =>
            {
                var nuevoPago = await handler.Insert(pagoDto);
                return Results.Created($"/api/pagos/{nuevoPago.IdPago}", nuevoPago);
            });

            // 4. Actualizar información de pago
            group.MapPut("/{id}", async (int id, [FromBody] PagoRequestDto pagoDto, IPagoHandler handler) =>
            {
                // El handler encapsula la lógica de búsqueda y mapeo
                var (success, message) = await handler.UpdateAsync(pagoDto, id);
                return success ? Results.NoContent() : Results.BadRequest(message);
            });

            // 5. Eliminar pago
            group.MapDelete("/{id}", async (int id, IPagoHandler handler, [FromQuery] bool softDelete = true) =>
            {
                var (success, message) = await handler.Delete(id, softDelete);
                return success ? Results.Ok(new { message = "Pago eliminado correctamente" }) : Results.NotFound(message);
            });
        }
    }
}