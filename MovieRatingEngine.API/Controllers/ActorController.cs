using Microsoft.AspNetCore.Mvc;
using MovieRatingEngine.API.Constants;
using MovieRatingEngine.API.Envelopes.Requests;
using MovieRatingEngine.API.Envelopes.Responses;
using MovieRatingEngine.API.Helpers.Exceptions.Generic;
using MovieRatingEngine.API.Services.Interfaces;

namespace MovieRatingEngine.API.Controllers;

/// <summary>
/// The controller for handling actor related requests.
/// </summary>
[Route(EndpointConstants.Version1)]
[ApiController]
public class ActorController : Controller
{
	private readonly IActorService _actorService;

	/// <summary>
	/// Initializes a new instance of the <see cref="ActorController"/> class.
	/// </summary>
	/// <param name="actorService">The actor service.</param>
	public ActorController(IActorService actorService)
	{
		_actorService = actorService;
	}

	/// <summary>
	/// Retrieves a list of actors based on the provided request DTO.
	/// </summary>
	/// <param name="getActorsRequestDto"> The request data. See <see cref="GetActorsRequestDto"/> for more information. </param>
	/// <returns> HTTP response with a list of actor response DTOs. </returns>
	[HttpGet]
	public async Task<ActionResult<IEnumerable<ActorResponseDto>>> GetActorsAsync(
		[FromQuery] GetActorsRequestDto getActorsRequestDto)
	{
		return Ok(await _actorService.GetActorsAsync(getActorsRequestDto));
	}

	/// <summary>
	/// Gets a specific actor.
	/// </summary>
	/// <param name="id"> The requested actors's id. </param>
	/// <returns> HTTP response with the requested actor as an <see cref="ActorResponseDto"/> object. </returns>
	[HttpGet("{id}")]
	public async Task<ActionResult<ActorResponseDto>> GetActorByIdAsync([FromRoute] Guid id)
	{
		try
		{
			return Ok(await _actorService.GetActorByIdAsync(id));
		}
		catch (EntityNotFoundException ex)
		{
			return NotFound(ex.Message);
		}
	}

	/// <summary>
	/// Adds a new actor.
	/// </summary>
	/// <param name="addActorRequestDto"> The request data. See <see cref="AddActorRequestDto"/> for more information. </param>
	/// <returns> HTTP response with the newly added actor as an <see cref="ActorResponseDto"/> object. </returns>
	[HttpPost]
	public async Task<ActionResult<ActorResponseDto>> AddActorAsync([FromBody] AddActorRequestDto addActorRequestDto)
	{
		try
		{
			return Ok(await _actorService.AddActorAsync(addActorRequestDto));
		}
		catch (ResourceAlreadyExistsException ex)
		{
			return Conflict(ex.Message);
		}
	}
}
