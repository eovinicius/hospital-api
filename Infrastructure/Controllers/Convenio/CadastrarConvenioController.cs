using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Convenios;

[ApiController]
[Route("api/convenios")]
[Authorize(Roles = "Admin")]
[Tags("Convenios")]
public class CadastrarConvenioController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Execute([FromBody] CadastrarConvenioInput input, [FromServices] CadastrarConvenioUseCase _usecase)
    {
        await _usecase.Handle(input);
        return Created();
    }
}
