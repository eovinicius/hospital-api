using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Domain.Exceptions;

namespace SistemaHospitalar.Infrastructure.Presenters
{
    public class ResponseException : IActionResult
    {
        private List<string> _errors { get; set; }
        private int _statusCode { get; set; }

        public ResponseException(DomainException exception)
        {
            _errors = exception.Errors;
            _statusCode = exception.StatusCode;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var ResposeData =
                new ObjectResult(new ResponseObject(null, _errors))
                {
                    StatusCode = _statusCode,
                };

            return ResposeData.ExecuteResultAsync(context);
        }
    }
}
