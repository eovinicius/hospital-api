using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Pacientes;

[ApiController]
[Route("api/pacientes")]
// [Authorize(Roles = "Admin, Medico")]
[Tags("Paciente")]
public class DetalhesPacienteController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Execute([FromRoute] Guid id, [FromServices] DetalhesPacienteUseCase usecase)
    {
        var result = await usecase.Handle(id);
        return Ok(new ResponseObject(result));
    }
}