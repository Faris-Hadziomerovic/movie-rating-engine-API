using System.Globalization;

namespace MovieRatingEngine.API.Helpers.Exceptions.Generic;

/// <summary>
/// Remove entity exception class.
/// </summary>
public class RemoveEntityException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="RemoveEntityException"/> class.
	/// </summary>
	public RemoveEntityException()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="RemoveEntityException"/> class.
	/// </summary>
	/// <param name="message">The message to return.</param>
	public RemoveEntityException(string message) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="RemoveEntityException"/> class.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <param name="args">The arguments.</param>
	public RemoveEntityException(string message, params object[] args)
		: base(string.Format(CultureInfo.CurrentCulture, message, args))
	{
	}
}