using System.Globalization;

namespace MovieRatingEngine.API.Helpers.Exceptions.Generic;

/// <summary>
/// Forbidden exception class.
/// </summary>
public class ForbiddenException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ForbiddenException"/> class.
	/// </summary>
	public ForbiddenException()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ForbiddenException"/> class.
	/// </summary>
	/// <param name="message">The message to return.</param>
	public ForbiddenException(string message) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ForbiddenException"/> class.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <param name="args">The arguments.</param>
	public ForbiddenException(string message, params object[] args)
		: base(string.Format(CultureInfo.CurrentCulture, message, args))
	{
	}
}