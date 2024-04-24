using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers.Convenios;

[ApiController]
[Route("api/convenios")]
// [Authorize(Roles = "Admin")]
[Tags("Convenios")]
public class ListarConveniosController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Handle([FromServices] ListarConveniosUseCase usecase)
    {
        var convenios = await usecase.Handle();
        return Ok(convenios);
    }
}
