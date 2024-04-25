using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

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
        return Ok(new ResponseObject(medicos));
    }
}