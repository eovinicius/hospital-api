using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Consultas;

[ApiController]
[Route("api/consultas")]
// [Authorize(Roles = "Admin, Medico")]
[Tags("Consultas")]
public class DetalhesConsultaController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Handle([FromServices] DetalhesConsultaUseCase useCase, [FromRoute] Guid id)
    {
        await useCase.Handle(id);
        return Ok();
    }
}