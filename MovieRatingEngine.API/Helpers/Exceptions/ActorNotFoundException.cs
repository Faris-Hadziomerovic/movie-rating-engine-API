using System.Globalization;
using MovieRatingEngine.API.Constants;
using MovieRatingEngine.API.Helpers.Exceptions.Generic;

namespace MovieRatingEngine.API.Helpers.Exceptions;

/// <summary>
/// Actor not found exception class.
/// </summary>
public class ActorNotFoundException : EntityNotFoundException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ActorNotFoundException"/> class.
	/// </summary>
	/// <param name="message">Message to return.</param>
	public ActorNotFoundException(string message = ExceptionMessageConstants.ActorNotFound) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ActorNotFoundException"/> class.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <param name="args">The arguments.</param>
	public ActorNotFoundException(string message, params object[] args)
		: base(string.Format(CultureInfo.CurrentCulture, message, args))
	{
	}
}
