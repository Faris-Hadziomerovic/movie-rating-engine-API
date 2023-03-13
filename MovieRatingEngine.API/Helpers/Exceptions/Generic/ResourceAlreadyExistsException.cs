using System.Globalization;

namespace MovieRatingEngine.API.Helpers.Exceptions.Generic;

/// <summary>
/// Resource already exists exception class.
/// </summary>
public class ResourceAlreadyExistsException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ResourceAlreadyExistsException"/> class.
	/// </summary>
	public ResourceAlreadyExistsException()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ResourceAlreadyExistsException"/> class.
	/// </summary>
	/// <param name="message">The message to return.</param>
	public ResourceAlreadyExistsException(string message) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ResourceAlreadyExistsException"/> class.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <param name="args">The arguments.</param>
	public ResourceAlreadyExistsException(string message, params object[] args)
		: base(string.Format(CultureInfo.CurrentCulture, message, args))
	{
	}
}