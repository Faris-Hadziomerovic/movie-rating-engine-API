using MovieRatingEngine.API.Enums;
using MovieRatingEngine.API.Models;

namespace MovieRatingEngine.API.Envelopes.Requests;

/// <summary>
/// The add media item request DTO.
/// </summary>
public class AddMediaRequestDto
{
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
	public MediaType MediaType { get; set; }

	/// <summary>
	/// Gets or sets the release date of the media.
	/// </summary>
	/// <value>
	/// The release date.
	/// </value>
	public DateOnly? ReleaseDate { get; set; }

	/// <summary>
	/// Gets or sets the cast by their Ids.
	/// </summary>
	/// <value>
	/// The list of cast member Ids.
	/// </value>
	public List<Guid>? Cast { get; set; }
}
