namespace SistemaHospitalar.Infrastructure.Presenters;
public class ResponseObject
{
    public object? Value { get; set; }
    public List<string> Errors { get; set; }
    public bool IsValid => Errors.Count == 0;

    public ResponseObject(object? value = null, List<string>? errors = null)
    {
        Value = value ?? null;
        Errors = errors ?? [];
    }
}