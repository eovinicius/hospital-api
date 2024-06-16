using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Pacientes;

[ApiController]
[Route("api/pacientes/document")]
// [Authorize(Roles = "Admin, Medico")]
[Tags("Paciente")]
public class GetDocumentoImagebyPacienteIdController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Execute([FromRoute] Guid id, [FromServices] GetDocumentoImagebyPacienteIdUseCase usecase)
    {
        var result = await usecase.Handle(id);
        return File(System.IO.File.ReadAllBytes(result), "image/jpeg");
    }
}
