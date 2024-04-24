using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Laudos;

[ApiController]
[Route("api/laudos")]
// [Authorize(Roles = "Medico, Admin")]
[Tags("Laudos")]
public class RegistrarLaudoController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Execute([FromServices] RegistrarLaudoUseCase useCase, [FromForm] RegistrarLaudoInput input)
    {
        await useCase.Handle(input);

        return Created("", "Laudo cadastrado com sucesso.");
    }
}