using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Medicos;

[ApiController]
[Route("api/medicos")]
// [Authorize(Roles = "Admin")]
[Tags("Medicos")]
public class DetalhesMedicoController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Execute([FromServices] DetalhesMedicoUseCase useCase, [FromRoute] Guid id)
    {
        var medico = await useCase.Handle(id);
        return Ok(new ResponseObject(medico));
    }
}