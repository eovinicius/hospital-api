using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Consultas;

[ApiController]
[Route("api/consultas")]
// [Authorize(Roles = "Admin, Medico")]
[Tags("Consultas")]
public class AtualizarConsultaController : ControllerBase
{
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Execute([FromBody] AtualizarConsultaInput input, [FromRoute] Guid id, [FromServices] AtualizarConsultaUseCase useCase)
    {
        await useCase.Execute(id, input.NovaDataHora);
        return Ok();
    }
}