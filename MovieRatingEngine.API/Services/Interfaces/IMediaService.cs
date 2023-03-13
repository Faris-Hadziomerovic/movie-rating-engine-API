using MovieRatingEngine.API.Constants;
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
	/// <param name="search">
	/// Search request for media lookup information.
	/// If it's ommited then the return will depend on the <seealso href="searchShows"/> parameter.
	/// </param>
	/// <param name="searchShows">
	/// Flag that represents if a tv show list should be returned, thus if it's false or ommited then a movie list will be returned by default.
	/// The <see href="search"/> query overrides this parameter, it will only be taken into account if the search parameter is empty or null.
	/// </param>
	/// <param name="size"> Maximum size of the response list. Defaults to <see cref="DefaultConstants.MediaLookupResponseListLength"/>. </param>
	/// <param name="page">
	/// Defines how many elements in the query should be skipped multiplied by <see href="size"/>. Used for pagination.
	/// Defaults to <see cref="DefaultConstants.MediaLookupResponsePageNumber"/>.
	/// </param>
	/// <returns>A list of <see cref="MediaLookupResponseDto"/>s.</returns>
	Task<IEnumerable<MediaLookupResponseDto>> GetMediaLookupsAsync(string? search, bool? searchShows, int size, int page);

	/// <summary>
	/// Gets a list of media lookups that fit the parameters.
	/// </summary>
	/// <param name="getMediaLookupsRequest"> Represents the request for media lookup information. </param>
	/// <returns>A list of <see cref="MediaLookupResponseDto"/>s.</returns>
	Task<IEnumerable<MediaLookupResponseDto>> GetMediaLookupsByDTOAsync(GetMediaLookupsRequestDto getMediaLookupsRequest);

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
