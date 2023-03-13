using System.Globalization;

namespace MovieRatingEngine.API.Helpers.Exceptions.Generic;

/// <summary>
/// A general error class that should be handled only by the exception middleware.
/// </summary>
public class InternalServerError : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="InternalServerError"/> class.
	/// </summary>
	public InternalServerError()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="InternalServerError"/> class.
	/// </summary>
	/// <param name="message">The message to return.</param>
	public InternalServerError(string message) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="InternalServerError"/> class.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <param name="args">The arguments.</param>
	public InternalServerError(string message, params object[] args)
		: base(string.Format(CultureInfo.CurrentCulture, message, args))
	{
	}
}
