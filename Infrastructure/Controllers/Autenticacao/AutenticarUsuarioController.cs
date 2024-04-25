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
    private readonly AutenticarUsuarioUseCase _usecase;

    public AutenticarUsuarioController(AutenticarUsuarioUseCase usecase)
    {
        _usecase = usecase;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Execute([FromBody] AutenticarUsuarioInput input)
    {
        var result = await _usecase.Handle(input);
        return Ok( new ResponseObject(result));
    }
}