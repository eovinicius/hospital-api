using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers;
[ApiController]
[Route("api")]
public class CadastrarPacienteController : ControllerBase
{
    [HttpPost("pacientes")]
    public async Task<IActionResult> Execute([FromBody] CadastrarPacienteInput request, [FromServices] CadastrarPacienteUseCase usecase)
    {
        await usecase.Handle(request);
        return Created("", "");
    }
}