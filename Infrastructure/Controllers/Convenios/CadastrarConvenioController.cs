using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Convenios;

[ApiController]
[Route("api/convenios")]
// [Authorize(Roles = "Admin")]
[Tags("Convenios")]
public class CadastrarConvenioController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Execute([FromBody] CadastrarConvenioInput input, [FromServices] CadastrarConvenioUseCase _usecase)
    {
        await _usecase.Handle(input);
        return Created("", new ResponseObject("Convenio cadastrado com sucesso!"));
    }
}
