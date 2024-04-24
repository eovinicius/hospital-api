using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Exames;

[ApiController]
[Route("api/exames")]
// [Authorize(Roles = "Medico, Admin")]
[Tags("Exames")]
public class MarcarExameController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Execute([FromBody] MarcarExameInput request, [FromServices] MarcarExameUseCase useCase)
    {
        // var userId = User.Claims
        // .FirstOrDefault(x => x.Type == "ID")?.Value;

        await useCase.Handle(request);

        return Created("", "");
    }
}