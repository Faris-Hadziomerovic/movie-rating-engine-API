using System.Globalization;
using MovieRatingEngine.API.Constants;
using MovieRatingEngine.API.Helpers.Exceptions.Generic;

namespace MovieRatingEngine.API.Helpers.Exceptions;

/// <summary>
/// Actor already exists exception class.
/// </summary>
public class ActorAlreadyExistsException : ResourceAlreadyExistsException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ActorAlreadyExistsException"/> class.
	/// </summary>
	/// <param name="message">Message to return.</param>
	public ActorAlreadyExistsException(string message = ExceptionMessageConstants.ActorAlreadyExists) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ActorAlreadyExistsException"/> class.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <param name="args">The arguments.</param>
	public ActorAlreadyExistsException(string message, params object[] args)
		: base(string.Format(CultureInfo.CurrentCulture, message, args))
	{
	}
}
