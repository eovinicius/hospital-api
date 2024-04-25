using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Medicos;

[ApiController]
[Route("api/medicos")]
// [Authorize(Roles = "Admin")]
[Tags("Medicos")]
public class CadastrarMedicoController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Execute([FromServices] CadastrarMedicoUseCase usecase, [FromBody] CadastrarMedicoInput input)
    {
        await usecase.Handle(input);
        return Created("", new ResponseObject("Médico cadastrado com sucesso!"));
    }

}