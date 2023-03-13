using MovieRatingEngine.API.Enums;
using MovieRatingEngine.API.Models;

namespace MovieRatingEngine.API.Envelopes.Requests;

/// <summary>
/// The add actor request DTO.
/// </summary>
public class AddActorRequestDto
{
	/// <summary>
	/// Gets or sets the actor's first name.
	/// </summary>
	/// <value>
	/// The first name.
	/// </value>
	public string? FirstName { get; set; }

	/// <summary>
	/// Gets or sets the actor's last name.
	/// </summary>
	/// <value>
	/// The last name.
	/// </value>
	public string? LastName { get; set; }
}
