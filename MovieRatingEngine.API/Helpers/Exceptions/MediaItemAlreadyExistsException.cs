using System.Globalization;
using MovieRatingEngine.API.Constants;
using MovieRatingEngine.API.Helpers.Exceptions.Generic;

namespace MovieRatingEngine.API.Helpers.Exceptions;

/// <summary>
/// Media item already exists exception class.
/// </summary>
public class MediaItemAlreadyExistsException : ResourceAlreadyExistsException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="MediaItemAlreadyExistsException"/> class.
	/// </summary>
	/// <param name="message">Message to return.</param>
	public MediaItemAlreadyExistsException(string message = ExceptionMessageConstants.MediaAlreadyExists) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="MediaItemAlreadyExistsException"/> class.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <param name="args">The arguments.</param>
	public MediaItemAlreadyExistsException(string message, params object[] args)
		: base(string.Format(CultureInfo.CurrentCulture, message, args))
	{
	}
}
