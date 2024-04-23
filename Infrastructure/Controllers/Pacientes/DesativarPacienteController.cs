using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Pacientes;

[ApiController]
[Route("api/pacientes")]
[Authorize(Roles = "Admin")]
[Tags("Paciente")]
public class DesativarPacienteController : ControllerBase
{
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Execute([FromServices] DesativarPacienteUseCase useCase, [FromRoute] Guid id)
    {
        await useCase.Execute(id);
        return Ok();
    }
}