namespace MovieRatingEngine.API.Envelopes.Responses;

/// <summary>
/// The review response DTO.
/// </summary>
public class ReviewResponseDto
{
	/// <summary>
	/// Gets or sets the identifier.
	/// </summary>
	/// <value>
	/// The identifier.
	/// </value>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the rating.
	/// </summary>
	/// <value>
	/// The rating.
	/// </value>
	public int Rating { get; set; }

	/// <summary>
	/// Gets or sets the comment.
	/// </summary>
	/// <value>
	/// The comment.
	/// </value>
	public string? Comment { get; set; }

	/// <summary>
	/// Gets or sets the media's identifier the rating belongs to.
	/// </summary>
	/// <value>
	/// The media's identifier the rating belongs to.
	/// </value>
	public Guid MediaId { get; set; }

	/// <summary>
	/// Gets or sets the media the rating belongs to.
	/// </summary>
	/// <value>
	/// The media the rating belongs to.
	/// </value>
	public string? MediaTitle { get; set; }

	/// <summary>
	/// Gets or sets the user's identifier.
	/// </summary>
	/// <value>
	/// The user's identifier.
	/// </value>
	public Guid? UserId { get; set; }
}
