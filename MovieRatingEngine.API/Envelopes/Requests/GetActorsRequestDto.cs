using MovieRatingEngine.API.Constants;

namespace MovieRatingEngine.API.Envelopes.Requests;

/// <summary>
/// The get actors request DTO.
/// </summary>
public class GetActorsRequestDto
{
	/// <summary>
	/// Gets or sets search request for actors query.
	/// </summary>
	/// <value>
	/// The search query.
	/// </value>
	public string? Search { get; set; }

	/// <summary>
	/// Gets or sets the maximum size of the response list. Defaults to <see cref="DefaultConstants.ActorResponseListLength"/>. Used for pagination.
	/// </summary>
	/// <value>
	/// The max response list length.
	/// </value>
	public int Size { get; set; } = DefaultConstants.ActorResponseListLength;

	/// <summary>
	/// Gets or sets the number of how many elements in the query should be skipped. This number will be multiplied by <see cref="Size"/>.
	/// Defaults to <see cref="DefaultConstants.ActorResponsePageNumber"/>. Used for pagination.
	/// </summary>
	/// <value>
	/// The page number.
	/// </value>
	public int Page { get; set; } = DefaultConstants.ActorResponsePageNumber;
}
