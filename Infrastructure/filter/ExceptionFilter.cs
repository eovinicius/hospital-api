using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SistemaHospitalar.Application.Exceptions;

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
        if (context.Exception is AlreadyRegisteredException)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
            context.Result = new BadRequestObjectResult(new { message = context.Exception.Message });
            _logger.LogWarning(context.Exception.Message);
            return;
        }
        if (context.Exception is InvalidDateTimeException)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(new { message = context.Exception.Message });
            _logger.LogWarning(context.Exception.Message);
            return;

        }
        if (context.Exception is DatetimeUnavailableException)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(new { message = context.Exception.Message });
            _logger.LogWarning(context.Exception.Message);
            return;

        }
        if (context.Exception is NotFoundException)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Result = new BadRequestObjectResult(new { message = context.Exception.Message });
            _logger.LogWarning(context.Exception.Message);
            return;
        }
        if (context.Exception is InvalidCredentialsException)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(new { message = context.Exception.Message });
            _logger.LogWarning(context.Exception.Message);
            return;
        }
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new BadRequestObjectResult(context.Exception.Message);
        Console.WriteLine(context.Exception.Message);
        _logger.LogError(context.Exception.Message);

    }
}