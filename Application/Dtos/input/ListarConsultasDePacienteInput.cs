using SistemaHospitalar.Domain.Enums;

namespace SistemaHospitalar.Application.Dtos.input;
public record ListarConsultasDePacienteInput(Guid PacienteId, EStatusAtendimento? Status);