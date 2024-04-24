using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Domain.Enums;

namespace SistemaHospitalar.Infrastructure.Controllers.Consultas;

[ApiController]
[Route("api/consultas")]
// [Authorize(Roles = "Admin, Medico")]
[Tags("Consultas")]
public class ListarConsultasDeMedicoController : ControllerBase
{
    [HttpGet("{medicoId:guid}/medicos")]
    public async Task<IActionResult> Execute([FromRoute] Guid medicoId, [FromServices] ListarConsultasDeMedicoUseCase usecase)
    {
        var input = new ListaCunsultasDeMedicoInput(medicoId);

        var consultas = await usecase.Execute(input);

        return Ok(consultas);
    }
}