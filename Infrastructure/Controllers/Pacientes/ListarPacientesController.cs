using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.Repositories;
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
    public async Task<IActionResult> Execute([FromServices] ListarPacientesUseCase usecase, [FromQuery] Pagination input)
    {
        var result = await usecase.Handle(input);
        return Ok(new ResponseObject(result));
    }
}