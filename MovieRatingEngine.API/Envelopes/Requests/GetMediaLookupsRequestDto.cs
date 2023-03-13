using MovieRatingEngine.API.Constants;
using MovieRatingEngine.API.Enums;

namespace MovieRatingEngine.API.Envelopes.Requests;

/// <summary>
/// The media lookups request DTO.
/// </summary>
public class GetMediaLookupsRequestDto
{
	/// <summary>
	/// Gets or sets search request for media lookup information.
	/// If it's ommited then the return will depend on the <seealso cref="SearchShows"/> parameter.
	/// </summary>
	/// <value>
	/// The search query.
	/// </value>
	public string? Search { get; set; }

	/// <summary>
	/// Gets or sets the flag that represents if a tv show list should be returned, if it's false or ommited then a movie list will be returned by default.
	/// The <see cref="Search"/> query overrides this parameter, thus it will only be taken into account if the search parameter is empty or null.
	/// </summary>
	/// <value>
	/// Flag for showing tv show over movies.
	/// </value>
	public bool? SearchShows { get; set; } = false;

	/// <summary>
	/// Gets or sets which media type should be returned.
	/// The <see cref="Search"/> query overrides this parameter, thus it will only be taken into account if the search parameter is empty or null.
	/// Defaults to <see cref="MediaType.Movie"/>.
	/// </summary>
	/// <value>
	/// Media type to be retured.
	/// </value>
	public MediaType? MediaContentType { get; set; } = MediaType.Movie;

	/// <summary>
	/// Gets or sets the maximum size of the response list. Defaults to <see cref="DefaultConstants.MediaLookupResponseListLength"/>. Used for pagination.
	/// </summary>
	/// <value>
	/// The max response list length.
	/// </value>
	public int Size { get; set; } = DefaultConstants.MediaLookupResponseListLength;

	/// <summary>
	/// Gets or sets the number of how many elements in the query should be skipped. This number will be multiplied by <see cref="Size"/>.
	/// Defaults to <see cref="DefaultConstants.MediaLookupResponsePageNumber"/>. Used for pagination.
	/// </summary>
	/// <value>
	/// The page number.
	/// </value>
	public int Page { get; set; } = DefaultConstants.MediaLookupResponsePageNumber;
}
