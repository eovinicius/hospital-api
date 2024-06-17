using Azure;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Domain.Enums;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Consultas;

[ApiController]
[Route("api/consultas")]
// [Authorize(Roles = "Admin, Medico", "Paciente")]
[Tags("Consultas")]
public class ListarConsultasByPacienteController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Execute([FromServices] ListarConsultasByPacienteUseCase usecase, [FromQuery] Pagination input)
    {
        var pacientId = User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
        if (pacientId == null)
        {
            return Unauthorized();
        }
        var consultas = await usecase.Handle(input, new Guid(pacientId));
        return Ok(new ResponseObject(consultas));
    }
}