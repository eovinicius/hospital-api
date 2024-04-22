using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos;
using SistemaHospitalar.Application.UseCases;

namespace SistemaHospitalar.Infrastructure.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]

public class CadastrarMedicoController : ControllerBase
{
    [HttpPost("cadastrar-medico")]
    public async Task<IActionResult> Execute([FromServices] CadastrarMedicoUseCase usecase, [FromBody] CadastrarMedicoInput input)
    {
        await usecase.Handle(input);
        return Created("", "");
    }

}