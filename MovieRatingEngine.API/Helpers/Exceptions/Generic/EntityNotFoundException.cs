using System.Globalization;

namespace MovieRatingEngine.API.Helpers.Exceptions.Generic;

/// <summary>
/// Entity not found exception class.
/// </summary>
public class EntityNotFoundException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
	/// </summary>
	public EntityNotFoundException()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
	/// </summary>
	/// <param name="message">The message to return.</param>
	public EntityNotFoundException(string message) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <param name="args">The arguments.</param>
	public EntityNotFoundException(string message, params object[] args)
		: base(string.Format(CultureInfo.CurrentCulture, message, args))
	{
	}
}
