using MovieRatingEngine.API.Envelopes.Requests;
using MovieRatingEngine.API.Envelopes.Responses;

namespace MovieRatingEngine.API.Services.Interfaces;

/// <summary>
/// The media service interface.
/// </summary>
public interface IMediaService
{
	/// <summary>
	/// Gets a list of media lookups that fit the parameters.
	/// </summary>
	/// <param name="getMediaLookupsRequest"> Represents the request for media lookup information. </param>
	/// <returns>A list of <see cref="MediaLookupResponseDto"/>s.</returns>
	Task<IEnumerable<MediaLookupResponseDto>> GetMediaLookupsAsync(GetMediaLookupsRequestDto getMediaLookupsRequest);

	/// <summary>
	/// Gets the total number of media items.
	/// </summary>
	/// <returns>The total number of media items.</returns>
	Task<int> GetMediaCountAsync();

	/// <summary>
	/// Gets a specific media item's full details. Throws if not found.
	/// </summary>
	/// <param name="id">The requested media's id.</param>
	/// <returns>The requested <see cref="MediaDetailsResponseDto"/>.</returns>
	Task<MediaDetailsResponseDto> GetMediaDetailsByIdAsync(Guid id);

	/// <summary>
	/// Adds a new media item.
	/// </summary>
	/// <param name="addMediaRequestDto"> The request data. See <see cref="AddMediaRequestDto"/> for more info. </param>
	/// <returns> The newly added media item as a <see cref="MediaDetailsResponseDto"/> object. </returns>
	Task<MediaDetailsResponseDto?> AddMediaAsync(AddMediaRequestDto addMediaRequestDto);

	/// <summary>
	/// Adds a review for a specific media item. Throws if not found.
	/// </summary>
	/// <param name="addReviewRequestDto"> The request data. See <see cref="AddReviewRequestDto"/> for more info. </param>
	/// <returns> The newly added review as a <see cref="ReviewResponseDto"/> object. </returns>
	Task<ReviewResponseDto> PostReviewByIdAsync(AddReviewRequestDto addReviewRequestDto);
}
