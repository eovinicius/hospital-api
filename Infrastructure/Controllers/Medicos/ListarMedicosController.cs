using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Repositories;
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
    public async Task<IActionResult> ListarMedicos([FromServices] ListarMedicosUseCase listarMedicosUseCase, [FromQuery] Pagination input)
    {
        var medicos = await listarMedicosUseCase.Handle(input);
        return Ok(new ResponseObject(medicos));
    }
}