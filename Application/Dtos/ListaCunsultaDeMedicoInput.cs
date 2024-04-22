using SistemaHospitalar.Domain.Enums;

namespace SistemaHospitalar.Application.Dtos;
public record ListaCunsultasDeMedicoInput(Guid MedicoId, EStatusAtendimento Status);