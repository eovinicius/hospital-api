using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Pacientes;

[ApiController]
[Route("api/Pacientes")]
[Tags("Paciente")]
public class CadastrarPacienteController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Execute([FromBody] CadastrarPacienteInput request, [FromServices] CadastrarPacienteUseCase usecase)
    {
        await usecase.Handle(request);
        return Created("", "");
    }
}