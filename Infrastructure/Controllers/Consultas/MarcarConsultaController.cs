using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Consultas;

[ApiController]
[Route("api/consultas")]
// [Authorize(Roles = "Admin, Medico, Paciente")]
[Tags("Consultas")]
public class MarcarConsultaController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Execute([FromServices] MarcarConsultaUseCase usecase, [FromBody] MarcarConsultaInput input)
    {
        await usecase.Handle(input);
        return Created("", "Consulta marcada com sucesso.");
    }
}