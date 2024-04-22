using SistemaHospitalar.Domain.Enums;

namespace SistemaHospitalar.Application.Dtos;
public record ListarConsultasDePacienteInput(Guid PacienteId, EStatusConsulta? Status);