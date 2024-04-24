using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Medicos;

[ApiController]
[Route("api/medicos")]
// [Authorize(Roles = "Admin")]
[Tags("Medicos")]
public class DetalhesMedicoController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Execute([FromServices] DetalhesMedicoUseCase useCase, [FromRoute] Guid id) => Ok(await useCase.Handle(id));
}