using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SistemaHospitalar.Domain.Exceptions;
using SistemaHospitalar.Infrastructure.Presenters;

namespace SistemaHospitalar.Infrastructure.filter;
public class ExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
    }
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DomainException)
        {
            var exception = context.Exception as DomainException;
            var result = new ResponseException(exception!);
            context.Result = result;
            _logger.LogWarning(context.Exception.Message);
            return;
        }

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new BadRequestObjectResult(context.Exception.Message);
        Console.WriteLine(context.Exception.Message);
        _logger.LogError(context.Exception.Message);

    }
}