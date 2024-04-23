using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Convenios;

[ApiController]
[Route("api")]
[Authorize(Roles = "Admin")]
[Tags("Convenios")]
public class CadastrarConvenioController : ControllerBase
{
    private readonly CadastrarConvenioUseCase _usecase;

    public CadastrarConvenioController(CadastrarConvenioUseCase usecase)
    {
        _usecase = usecase;
    }

    [HttpPost("convenios")]
    public async Task<IActionResult> Execute([FromBody] CadastrarConvenioInput input)
    {
        await _usecase.Handle(input);
        return Created();
    }
}
