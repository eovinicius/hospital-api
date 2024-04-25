using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Convenios;

[ApiController]
[Route("api/convenios")]
// [Authorize(Roles = "Admin")]
[Tags("Convenios")]
public class DetalhesConvenioController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Handle([FromServices] DetalhesConvenioUseCase useCase, [FromRoute] Guid id)
    {
        var convenio = await useCase.Handle(id);
        return Ok(new ResponseObject(convenio));
    }
}