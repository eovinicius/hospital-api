using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Convenios;

[ApiController]
[Route("api/convenios")]
// [Authorize(Roles = "Admin")]
[Tags("Convenios")]
public class ListarConveniosController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Handle([FromServices] ListarConveniosUseCase usecase, [FromQuery] Pagination input)
    {
        var convenios = await usecase.Handle(input);
        return Ok(new ResponseObject(convenios));
    }
}
