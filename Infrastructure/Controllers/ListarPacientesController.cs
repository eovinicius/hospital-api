using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class ListarPacientesController : ControllerBase
{
    [HttpGet("pacientes")]
    public async Task<IActionResult> Execute([FromServices] ListarPacientesUseCase usecase) => Ok(await usecase.Handle());

}