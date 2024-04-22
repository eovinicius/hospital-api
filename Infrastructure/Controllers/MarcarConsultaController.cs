using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers;
[ApiController]
[Route("api")]
[Authorize(Roles = "Admin, Medico, Paciente")]
public class MarcarConsultaController : ControllerBase
{
    [HttpPost("consultas")]
    public async Task<IActionResult> Execute([FromServices] MarcarConsultaUseCase usecase, [FromBody] MarcarConsultaInput input)
    {
        await usecase.Handle(input);
        return Ok();
    }
}