using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers;

[ApiController]
[Route("api")]
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
        return Ok(result);
    }
}