using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Convenios;

[ApiController]
[Route("api/convenios")]
// [Authorize(Roles = "Admin")]
[Tags("Convenios")]
public class DesativarConvenioController : ControllerBase
{
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Handle([FromServices] DesativarConvenioUseCase useCase, [FromRoute] Guid id)
    {
        await useCase.Handle(id);
        return Ok(new ResponseObject("Convenio desativado com sucesso!"));
    }
}