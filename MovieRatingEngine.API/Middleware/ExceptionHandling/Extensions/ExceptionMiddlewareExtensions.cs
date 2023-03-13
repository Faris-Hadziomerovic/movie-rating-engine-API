namespace MovieRatingEngine.API.Middleware.ExceptionHandling.Extensions;

/// <summary>
/// Extension method to configure exception handling middleware for an <see cref="IApplicationBuilder"/>.
/// </summary>
public static class ExceptionMiddlewareExtensions
{
	/// <summary>
	/// Configures exception handling middleware for an <see cref="IApplicationBuilder"/>.
	/// </summary>
	/// <param name="appBuilder"> The <see cref="IApplicationBuilder"/> instance. </param>
	public static void ConfigureExceptionMiddleware(this IApplicationBuilder appBuilder)
	{
		appBuilder.UseMiddleware<ExceptionHandlingMiddleware>();
	}
}
