using System.Globalization;
using MovieRatingEngine.API.Constants;

namespace MovieRatingEngine.API.Helpers.Exceptions.Generic;

/// <summary>
/// Unauthorized exception class.
/// </summary>
public class UnauthorizedException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
	/// </summary>
	/// <param name="message">The message to return.</param>
	public UnauthorizedException(string message = ExceptionMessageConstants.Unauthorized) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <param name="args">The arguments.</param>
	public UnauthorizedException(string message, params object[] args)
		: base(string.Format(CultureInfo.CurrentCulture, message, args))
	{
	}
}