using System.Globalization;
using MovieRatingEngine.API.Constants;
using MovieRatingEngine.API.Helpers.Exceptions.Generic;

namespace MovieRatingEngine.API.Helpers.Exceptions;

/// <summary>
/// Media not found exception class.
/// </summary>
public class MediaItemNotFoundException : EntityNotFoundException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="MediaItemNotFoundException"/> class.
	/// </summary>
	/// <param name="message">Message to return.</param>
	public MediaItemNotFoundException(string message = ExceptionMessageConstants.MediaNotFound) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="MediaItemNotFoundException"/> class.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <param name="args">The arguments.</param>
	public MediaItemNotFoundException(string message, params object[] args)
		: base(string.Format(CultureInfo.CurrentCulture, message, args))
	{
	}
}
