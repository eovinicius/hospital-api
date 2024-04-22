using SistemaHospitalar.Domain.Enums;

namespace SistemaHospitalar.Application.Dtos;
public record ListaCunsultasDeMedicoInput(Guid MedicoId, EStatusConsulta Status);