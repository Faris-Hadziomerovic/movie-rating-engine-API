namespace MovieRatingEngine.API.Envelopes.Requests;

/// <summary>
/// The add review request DTO.
/// </summary>
public class AddReviewRequestDto
{
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
	/// Gets or sets the user's identifier.
	/// This is optional to allow anonymous ratings.
	/// </summary>
	/// <value>
	/// The identifier of the user who posted the review.
	/// </value>
	public Guid? UserId { get; set; }
}
