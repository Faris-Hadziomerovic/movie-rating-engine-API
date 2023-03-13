namespace MovieRatingEngine.API.Envelopes.Responses;

/// <summary>
/// The media lookup response DTO.
/// </summary>
public class MediaLookupResponseDto
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
	/// Gets or sets the media content's image url.
	/// </summary>
	/// <value>
	/// The image url.
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
}
