using System.Text.Json;

namespace MovieRatingEngine.API.Middleware.ExceptionHandling;

/// <summary>
/// Exception details class.
/// </summary>
public class ExceptionDetails
{
	/// <summary>
	/// Gets or sets the HTTP status code of the response.
	/// </summary>
	/// <value>
	/// The status code.
	/// </value>
	public int StatusCode { get; set; }

	/// <summary>
	/// Gets or sets the error message of the response.
	/// </summary>
	/// <value>
	/// The message.
	/// </value>
	public string? Message { get; set; }

	/// <summary>
	/// Serializes this <see cref="ExceptionDetails"/> instance into a JSON string.
	/// </summary>
	/// <returns> A JSON string representing this <see cref="ExceptionDetails"/> instance. </returns>
	public override string ToString()
	{
		return JsonSerializer.Serialize(this);
	}
}
