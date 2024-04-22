using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class ListarConveniosController : ControllerBase
{
    [HttpGet("convenios")]
    public async Task<IActionResult> Handle([FromServices] ListarConveniosUseCase usecase)
    {
        var convenios = await usecase.Handle();
        return Ok(convenios);
    }
}
