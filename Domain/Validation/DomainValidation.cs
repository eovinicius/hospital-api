using System.Text.RegularExpressions;
using SistemaHospitalar.Domain.Exceptions;

namespace SistemaHospitalar.Domain.Validation;
public class DomainValidation
{
    private readonly string _entityName;
    private readonly List<string> _errors = [];

    public DomainValidation(string entityName)
    {
        _entityName = entityName;
    }

    public void NotNull(object? target, string fildName)
    {
        if (target is null)
            _errors.Add($"{fildName} should not be null");
    }

    public void NotNullOrEmpty(string? target, string fildName)
    {
        if (string.IsNullOrWhiteSpace(target))
            _errors.Add($"{fildName} not be null or empty");
    }

    public void MinLength(string target, int minLenght, string fildName)
    {
        if (target.Length < minLenght)
            _errors.Add($"{fildName} must be at least {minLenght} characters");
    }

    public void MaxLength(string target, int maxLenght, string fildName)
    {
        if (target.Length > maxLenght)
            _errors.Add($"{fildName} must be at most {maxLenght} characters");
    }

    public void MinValue(decimal target, decimal minValue, string fildName)
    {
        if (target < minValue)
            _errors.Add($"{fildName} must be at least {minValue}");
    }
    public void Cpf(string target, string fildName)
    {
        if (!Regex.IsMatch(target, @"^[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}$"))
            _errors.Add($"{fildName} has an invalid CPF format");
    }

    public void Cnpj(string target, string fildName)
    {
        if (!Regex.IsMatch(target, @"^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}-[0-9]{2}$"))
            _errors.Add($"{fildName} has an invalid CNPJ format");
    }

    public void Check()
    {
        if (_errors.Count > 0) throw new DomainException(_entityName, _errors);
    }
}