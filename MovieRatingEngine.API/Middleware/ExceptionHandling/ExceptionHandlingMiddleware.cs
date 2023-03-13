using System.Net;
using FluentValidation;

namespace MovieRatingEngine.API.Middleware.ExceptionHandling;

/// <summary>
/// The exception middleware.
/// </summary>
public class ExceptionHandlingMiddleware
{
	private readonly RequestDelegate _next;

	/// <summary>
	/// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware"/> class.
	/// </summary>
	/// <param name="next">The request delegate.</param>
	public ExceptionHandlingMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	/// <summary>
	/// Invokes the next middleware in the pipeline, handling any exceptions that occur.
	/// </summary>
	/// <param name="httpContext"> The current <see cref="HttpContext"/> instance. </param>
	/// <exception cref="ArgumentNullException"> Thrown when <paramref name="httpContext"/> is null. </exception>
	/// <returns> A <see cref="Task"/> representing the asynchronous operation. </returns>
	public async Task InvokeAsync(HttpContext httpContext)
	{
		if (httpContext is null)
		{
			throw new ArgumentNullException(nameof(httpContext), "Catastrophic failure! The HttpContext is null.");
		}

		try
		{
			await _next(httpContext);
		}
		catch (ArgumentNullException ex)
		{
			await HandleBadRequestExceptionAsync(httpContext, ex, true);
		}
		catch (ValidationException ex)
		{
			await HandleBadRequestExceptionAsync(httpContext, ex, true);
		}
		catch (Exception ex)
		{
			await HandleInternalServerErrorAsync(httpContext, ex, true);
		}
	}

	/// <summary>
	/// Handles unhandled exceptions and returns status code 500.
	/// </summary>
	/// <param name="httpContext"> The current <see cref="HttpContext"/> instance. </param>
	/// <param name="exception"> The <see cref="Exception"/> that caused the internal server error. </param>
	/// <param name="showTrueException">Flag indicating whether to show the true exception message in the response message.</param>
	/// <returns> A task representing the asynchronous operation. </returns>
	private static async Task HandleInternalServerErrorAsync(HttpContext httpContext, Exception exception, bool showTrueException = false)
	{
		httpContext.Response.ContentType = "application/json";
		httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

		await httpContext.Response.WriteAsync(new ExceptionDetails
		{
			StatusCode = httpContext.Response.StatusCode,
			Message = showTrueException ? exception.Message : "Internal Server Error.",
		}.ToString());
	}

	/// <summary>
	/// Handles argument null and validation exceptions (both are due to bad request) and returns status code 400.
	/// </summary>
	/// <param name="httpContext"> The current <see cref="HttpContext"/> instance. </param>
	/// <param name="exception"> The exception. </param>
	/// <param name="showTrueException">Flag indicating whether to show the true exception message in the response message.</param>
	/// <returns> A task representing the asynchronous operation. </returns>
	private static async Task HandleBadRequestExceptionAsync(HttpContext httpContext, Exception exception, bool showTrueException = false)
	{
		httpContext.Response.ContentType = "application/json";
		httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

		await httpContext.Response.WriteAsync(new ExceptionDetails
		{
			StatusCode = httpContext.Response.StatusCode,
			Message = showTrueException ? exception.Message : "Bad Client Request.",
		}.ToString());
	}
}
