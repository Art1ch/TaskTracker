using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace TaskTracker.Api.Middlewares;

internal sealed class GlobalExceptionMiddleware
{
    private readonly IStringLocalizer<GlobalExceptionMiddleware> _stringLocalizer;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(
        IStringLocalizer<GlobalExceptionMiddleware> stringLocalizer,
        ILogger<GlobalExceptionMiddleware> logger,
        RequestDelegate next
    )
    {
        _logger = logger;
        _stringLocalizer = stringLocalizer;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(exception, context);
        }
    }

    private async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        int status;
        string errorTitle;
        string detail;

        switch (exception)
        {
            case ValidationException validationException:
                status = StatusCodes.Status400BadRequest;
                errorTitle = _stringLocalizer.GetString("VALIDATION_ERROR");
                detail = string.Join(";", validationException.Errors.Select(x => _stringLocalizer.GetString(x.ErrorCode)));
                break;

            case InvalidOperationException invalidOperationException:
                status = StatusCodes.Status404NotFound;
                errorTitle = _stringLocalizer.GetString("NOT_FOUND_ERROR");
                detail = invalidOperationException.Message;
                break;

            default:
                status = StatusCodes.Status500InternalServerError;
                errorTitle = _stringLocalizer.GetString("SERVER_ERROR");
                detail = exception.Message;
                break;
        }

        var problemDetails = new ProblemDetails()
        {
            Status = status,
            Title = errorTitle,
            Detail = detail
        };

        _logger.LogInformation(exception.Message, detail);

        await context.Response.WriteAsJsonAsync(problemDetails);
    }
}
