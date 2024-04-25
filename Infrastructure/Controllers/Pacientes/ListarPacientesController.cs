using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Pacientes;

[ApiController]
[Route("api/Pacientes")]
// [Authorize(Roles = "Admin")]
[Tags("Paciente")]
public class ListarPacientesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Execute([FromServices] ListarPacientesUseCase usecase)
    {
        var result = await usecase.Handle();
        return Ok(new ResponseObject(result));
    }
}