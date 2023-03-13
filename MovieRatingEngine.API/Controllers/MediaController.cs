using Microsoft.AspNetCore.Mvc;
using MovieRatingEngine.API.Constants;
using MovieRatingEngine.API.Envelopes.Requests;
using MovieRatingEngine.API.Envelopes.Responses;
using MovieRatingEngine.API.Helpers.Exceptions.Generic;
using MovieRatingEngine.API.Services.Interfaces;

namespace MovieRatingEngine.API.Controllers;

/// <summary>
/// The controller for handling media related requests.
/// </summary>
[Route(EndpointConstants.Version1)]
[ApiController]
public class MediaController : Controller
{
	private readonly IMediaService _mediaService;

	/// <summary>
	/// Initializes a new instance of the <see cref="MediaController"/> class.
	/// </summary>
	/// <param name="mediaService">The media service.</param>
	public MediaController(IMediaService mediaService)
	{
		_mediaService = mediaService;
	}

	/// <summary>
	/// Retrieves a list of media lookups based on the provided request DTO.
	/// </summary>
	/// <param name="getMediaLookupsRequestDto">The request DTO containing search parameters.
	/// See <see cref="GetMediaLookupsRequestDto"/> for more information. </param>
	/// <returns> HTTP response with a list of media lookup response DTOs. </returns>
	[HttpGet]
	public async Task<ActionResult<IEnumerable<MediaLookupResponseDto>>> GetMediaLookupListByRequestDtoAsync(
		[FromQuery] GetMediaLookupsRequestDto getMediaLookupsRequestDto)
	{
		return Ok(await _mediaService.GetMediaLookupsAsync(getMediaLookupsRequestDto));
	}

	/// <summary>
	/// Gets a specific media item's full details.
	/// </summary>
	/// <param name="id">The requested media's id.</param>
	/// <returns> HTTP response with the requested <see cref="MediaDetailsResponseDto"/>.</returns>
	[HttpGet("{id:guid}")]
	public async Task<ActionResult<MediaDetailsResponseDto>> GetMediaDetailsByIdAsync([FromRoute] Guid id)
	{
		try
		{
			return Ok(await _mediaService.GetMediaDetailsByIdAsync(id));
		}
		catch (EntityNotFoundException ex)
		{
			return NotFound(ex.Message);
		}
	}

	/// <summary>
	/// Adds a new media item.
	/// </summary>
	/// <param name="addMediaRequestDto"> The request data. See <see cref="AddMediaRequestDto"/> for more information. </param>
	/// <returns> HTTP response with the newly added media item as a <see cref="MediaDetailsResponseDto"/> object. </returns>
	[HttpPost]
	public async Task<ActionResult<MediaDetailsResponseDto>> AddMediaAsync(
		[FromBody] AddMediaRequestDto addMediaRequestDto)
	{
		try
		{
			return Ok(await _mediaService.AddMediaAsync(addMediaRequestDto));
		}
		catch (ResourceAlreadyExistsException ex)
		{
			return Conflict(ex.Message);
		}
	}

	/// <summary>
	/// Adds a review for a specific media item. Throws if not found.
	/// </summary>
	/// <param name="addReviewRequestDto"> The request data. See <see cref="AddReviewRequestDto"/> for more information. </param>
	/// <returns> HTTP response with the newly added review as a <see cref="ReviewResponseDto"/> object. </returns>
	[HttpPost("review")]
	public async Task<ActionResult<ReviewResponseDto>> AddReviewAsync(
		[FromBody] AddReviewRequestDto addReviewRequestDto)
	{
		try
		{
			return Ok(await _mediaService.PostReviewByIdAsync(addReviewRequestDto));
		}
		catch (EntityNotFoundException ex)
		{
			return NotFound(ex.Message);
		}
	}
}
