using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Pacientes;

[ApiController]
[Route("api/pacientes")]
[Tags("Paciente")]
public class CadastrarPacienteController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Execute([FromForm] CadastrarPacienteInput request, [FromServices] CadastrarPacienteUseCase usecase)
    {
        await usecase.Handle(request);
        return Created("", new ResponseObject("Paciente cadastrado com sucesso!"));
    }
}