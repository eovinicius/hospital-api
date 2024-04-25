using Azure;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Exames;

[ApiController]
[Route("api/exames")]
// [Authorize(Roles = "Medico, Admin")]
[Tags("Exames")]
public class ListarExamesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Execute([FromServices] ListarExamesUseCase useCase)
    {
        var exames = await useCase.Handle();

        return Ok(new ResponseObject(exames));
    }
}