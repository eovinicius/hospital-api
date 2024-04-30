using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Exames;

[ApiController]
[Route("api/[controller]")]
// [Authorize(Roles = "Medico, Admin")]
[Tags("Exames")]
public class DetalhesExameController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Execute([FromServices] DetalhesExameUseCase useCase, [FromRoute] Guid id)
    {
        var exame = await useCase.Execute(id);

        return Ok(new ResponseObject(exame));
    }
}