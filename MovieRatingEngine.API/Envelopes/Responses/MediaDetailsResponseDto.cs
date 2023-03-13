namespace MovieRatingEngine.API.Envelopes.Responses;

/// <summary>
/// The media details response DTO.
/// </summary>
public class MediaDetailsResponseDto
{
	/// <summary>
	/// Gets or sets the identifier.
	/// </summary>
	/// <value>
	/// The identifier.
	/// </value>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the media content's title.
	/// </summary>
	/// <value>
	/// The title.
	/// </value>
	public string? Title { get; set; }

	/// <summary>
	/// Gets or sets the media content's description.
	/// </summary>
	/// <value>
	/// The description.
	/// </value>
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the media's cover image url link.
	/// </summary>
	/// <value>
	/// The cover image url link.
	/// </value>
	public string? ImageUrl { get; set; }

	/// <summary>
	/// Gets or sets the media content's type.
	/// </summary>
	/// <value>
	/// The media content's type.
	/// </value>
	public string? MediaType { get; set; }

	/// <summary>
	/// Gets or sets the media content's average rating.
	/// </summary>
	/// <value>
	/// The media average rating.
	/// </value>
	public double AverageRating { get; set; } = 0;

	/// <summary>
	/// Gets or sets the release date of the media.
	/// </summary>
	/// <value>
	/// The release date.
	/// </value>
	public DateOnly? ReleaseDate { get; set; }

	/// <summary>
	/// Gets or sets the cast of the media.
	/// </summary>
	/// <value>
	/// The list of cast members.
	/// </value>
	public List<ActorResponseDto>? Cast { get; set; }
}
