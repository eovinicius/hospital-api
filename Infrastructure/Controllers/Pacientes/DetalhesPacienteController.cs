using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Pacientes;

[ApiController]
[Route("api/Pacientes")]
[Authorize(Roles = "Admin, Medico")]
[Tags("Paciente")]
public class DetalhesPacienteController : ControllerBase
{
    [HttpGet]

    [Route("{id:guid}")]

    public async Task<IActionResult> Execute([FromRoute] Guid id, [FromServices] DetalhesPacienteUseCase usecase) => Ok(await usecase.Handle(id));
}