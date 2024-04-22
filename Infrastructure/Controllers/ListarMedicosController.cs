using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class ListarMedicosController : ControllerBase
{

    [HttpGet("medicos")]
    public async Task<IActionResult> ListarMedicos([FromServices] ListarMedicosUseCase listarMedicosUseCase) => Ok(await listarMedicosUseCase.Handle());
}