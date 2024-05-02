using SistemaHospitalar.Domain.Enums;

namespace SistemaHospitalar.Application.Dtos.input;

public record ListarConsultaPacienteInput
(
    string? PacienteId,
    string? ConsultaId,
    EStatusAtendimento? StatusAtendimento,
    DateTime? DataInicio,
    DateTime? DataFim
);