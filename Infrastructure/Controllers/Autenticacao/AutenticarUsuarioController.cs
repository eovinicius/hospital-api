using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Autenticacao;

[ApiController]
[Route("api")]
[Tags("Autenticacao")]
public class AutenticarUsuarioController : ControllerBase
{


    [HttpPost("login")]
    public async Task<IActionResult> Execute
    (
        [FromBody] AutenticarUsuarioInput input,
        [FromServices] AutenticarUsuarioUseCase useCase
    )
    {
        var result = await useCase.Handle(input);
        return Ok(new ResponseObject(result));
    }
}