using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers;
[ApiController]
[Route("api")]
[Authorize(Roles = "Admin, Medico")]
public class DetalhesPacienteController : ControllerBase
{
    [HttpGet]
    [Route("pacientes/{id:guid}")]
    public async Task<IActionResult> Execute([FromRoute] Guid id, [FromServices] DetalhesPacienteUseCase usecase) => Ok(await usecase.Handle(id));
}