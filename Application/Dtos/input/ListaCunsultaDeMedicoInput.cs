using SistemaHospitalar.Domain.Enums;

namespace SistemaHospitalar.Application.Dtos.input;
public record ListaCunsultasDeMedicoInput(Guid MedicoId, EStatusAtendimento? Status = null);