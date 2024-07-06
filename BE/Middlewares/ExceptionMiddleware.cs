using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BE.Middlewares
{
    public class ApiResult<T>
    {
        public bool? Success { get; set; }
        public T? Result { get; set; }
        public string? ErrorMessage { get; set; }
        public int? StatusCode { get; set; }
        public string? StackTrace { get; set; }

        public static ApiResult<T> Fail(Exception ex, int? statusCode = null)
        {
            return new ApiResult<T>
            {
                Success = false,
                ErrorMessage = ex.Message,
                StatusCode = statusCode,
                StackTrace = ex.StackTrace
            };
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException() : base("The requested resource was not found.")
        {
        }
        public NotFoundException(string message) : base(message)
        {
        }
        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    public class BadRequestException : Exception
    {
        public BadRequestException() : base("The request was malformed or invalid.")
        {
        }
        public BadRequestException(string message) : base(message)
        {
        }
        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    public class RequestValidationException : Exception
    {
        public RequestValidationException() : base("Request validation failed.")
        {
        }
        public RequestValidationException(string message) : base(message)
        {
        }
        public RequestValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public Dictionary<string, string[]> ProblemDetails { get; set; }
    }

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IDictionary<Type, Func<HttpContext, Exception, Task>> _exceptionHandlers = new Dictionary<Type, Func<HttpContext, Exception, Task>>
        {
            { typeof(NotFoundException), HandleNotFoundExceptionAsync },
            { typeof(BadRequestException), HandleBadRequestExceptionAsync },
            { typeof(RequestValidationException), HandleRequestValidationExceptionAsync }
        };

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"An error occurred: {e.Message}");
                Debug.WriteLine($"Stack trace: {e.StackTrace}");
                await HandleExceptionAsync(context, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            var type = ex.GetType();
            
            if (_exceptionHandlers.TryGetValue(type, out var handler))
            {
                await handler.Invoke(context, ex);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await WriteExceptionMessageAsync(context, ex);
            }
        }

        private static async Task HandleNotFoundExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await WriteExceptionMessageAsync(context, ex);
        }

        private static async Task HandleBadRequestExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await WriteExceptionMessageAsync(context, ex);
        }

        private static async Task HandleRequestValidationExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            var exception = ex as RequestValidationException;
            var result = new ApiResult<Dictionary<string, string[]>>
            {
                Result = exception?.ProblemDetails
            };
            await context.Response.Body.WriteAsync(SerializeToUtf8BytesWeb(result));
        }

        private static async Task WriteExceptionMessageAsync(HttpContext context, Exception ex)
        {
            await context.Response.Body.WriteAsync(SerializeToUtf8BytesWeb(ApiResult<string>.Fail(ex)));
        }

        private static byte[] SerializeToUtf8BytesWeb<T>(T value)
        {
            return JsonSerializer.SerializeToUtf8Bytes(value, new JsonSerializerOptions(JsonSerializerDefaults.Web));
        }
    }
}
