namespace MovieRatingEngine.API.Envelopes.Responses;

/// <summary>
/// The actor response DTO.
/// </summary>
public class ActorResponseDto
{
	/// <summary>
	/// Gets or sets the identifier.
	/// </summary>
	/// <value>
	/// The identifier.
	/// </value>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the actor's full name.
	/// </summary>
	/// <value>
	/// The full name.
	/// </value>
	public string? Name { get; set; }
}
