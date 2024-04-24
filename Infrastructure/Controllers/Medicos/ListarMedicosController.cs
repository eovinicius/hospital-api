using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Medicos;

[ApiController]
[Route("api/medicos")]
// [Authorize(Roles = "Admin")]
[Tags("Medicos")]
public class ListarMedicosController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> ListarMedicos([FromServices] ListarMedicosUseCase listarMedicosUseCase)
    {
        var medicos = await listarMedicosUseCase.Handle();
        return Ok(medicos);
    }
}