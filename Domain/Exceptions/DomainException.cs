namespace SistemaHospitalar.Domain.Exceptions;

public class DomainException : Exception
{
    public string MessageLogger { get; set; }
    public int StatusCode { get; set; }
    public List<string> Errors { get; set; } = [];

    public DomainException(string messageLogger, List<string> errors, int statusCode = StatusCodes.Status400BadRequest) : base(messageLogger)
    {
        MessageLogger = messageLogger;
        Errors = errors;
        StatusCode = statusCode;
    }

    public DomainException(string messageLogger, string error, int statusCode = StatusCodes.Status400BadRequest) : base(messageLogger)
    {
        MessageLogger = messageLogger;
        StatusCode = statusCode;
        AddError(error);
    }

    public DomainException(string messageLogger, int statusCode = StatusCodes.Status400BadRequest) : base(messageLogger)
    {
        MessageLogger = messageLogger;
        StatusCode = statusCode;
        AddError(messageLogger);
    }

    private void AddError(string error)
    {
        Errors.Add(error);
    }

}