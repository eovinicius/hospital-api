using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Pacientes;

[ApiController]
[Route("api/Pacientes")]
[Tags("Paciente")]
[Authorize(Roles = "Admin")]
public class ListarPacientesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Execute([FromServices] ListarPacientesUseCase usecase) => Ok(await usecase.Handle());
}