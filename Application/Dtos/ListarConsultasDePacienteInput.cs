using SistemaHospitalar.Domain.Enums;

namespace SistemaHospitalar.Application.Dtos;
public record ListarConsultasDePacienteInput(Guid PacienteId, EStatusAtendimento? Status);