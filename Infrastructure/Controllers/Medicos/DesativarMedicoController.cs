using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Medicos;

[ApiController]
[Route("api/medicos")]
// [Authorize(Roles = "Admin")]
[Tags("Medicos")]
public class DesativarMedicoController : ControllerBase
{
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Execute([FromServices] DesativarMedicoUseCase useCase, [FromRoute] Guid id)
    {
        await useCase.Handle(id);
        return Ok(new ResponseObject("Médico desativado com sucesso!"));
    }
}