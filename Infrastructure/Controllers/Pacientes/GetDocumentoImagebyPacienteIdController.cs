using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

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
        Console.WriteLine(result);
        return File(System.IO.File.ReadAllBytes(result), "image/jpeg");
    }
}
