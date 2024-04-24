using System.Text.RegularExpressions;
using SistemaHospitalar.Domain.Exceptions;

namespace SistemaHospitalar.Domain.Validation;
public class DomainValidation
{
    public static void NotNull(object? target, string fildName)
    {
        if (target is null)
            throw new DomainEntityException($"{fildName} should not be null");
    }

    public static void NotNullOrEmpty(string? target, string fildName)
    {
        if (string.IsNullOrWhiteSpace(target))
            throw new DomainEntityException($"{fildName} not be null or empty");
    }

    public static void MinLength(string? target, int minLenght, string fildName)
    {
        if (target!.Length < minLenght)
            throw new DomainEntityException($"{fildName} must be at least {minLenght} characters");
    }

    public static void MaxLength(string? target, int maxLenght, string fildName)
    {
        if (target!.Length > maxLenght)
            throw new DomainEntityException($"{fildName} must be at most {maxLenght} characters");
    }

    public static void MinValue(decimal target, decimal minValue, string fildName)
    {
        if (target < minValue)
            throw new DomainEntityException($"{fildName} must be at least {minValue}");
    }
    public static void Cpf(string target, string fildName)
    {
        if (target.Length != 11)
            throw new DomainEntityException($"{fildName} must have 11 characters");

        if (!Regex.IsMatch(target, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
            throw new DomainEntityException($"{fildName} is invalid");
    }

    public static void Cnpj(string target, string fildName)
    {
        if (target.Length != 14)
            throw new DomainEntityException($"{fildName} must have 14 characters");

        if (!Regex.IsMatch(target, @"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$"))
            throw new DomainEntityException($"{fildName} is invalid");
    }
}