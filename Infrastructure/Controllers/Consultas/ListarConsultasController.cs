using Azure;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Domain.Enums;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.Controllers.Consultas;

[ApiController]
[Route("api/consultas")]
// [Authorize(Roles = "Admin, Medico")]
[Tags("Consultas")]
public class ListarConsultasController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Execute([FromServices] ListarConsultasUseCase usecase)
    {
        var consultas = await usecase.Handle();

        return Ok(new ResponseObject(consultas));
    }
}