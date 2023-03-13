using MovieRatingEngine.API.Envelopes.Requests;
using MovieRatingEngine.API.Envelopes.Responses;

namespace MovieRatingEngine.API.Services.Interfaces;

/// <summary>
/// The actor service interface.
/// </summary>
public interface IActorService
{
	/// <summary>
	/// Gets a list of actors that that match the parameters.
	/// </summary>
	/// <param name="getActorsRequestDto"> Represents the request for the actors query. </param>
	/// <returns>A list of <see cref="ActorResponseDto"/>s.</returns>
	Task<IEnumerable<ActorResponseDto>> GetActorsAsync(GetActorsRequestDto getActorsRequestDto);

	/// <summary>
	/// Gets an actor by its unique identifier. Throws if not found.
	/// </summary>
	/// <param name="id">The requested actor's id.</param>
	/// <returns>The requested actor as an <see cref="ActorResponseDto"/> object.</returns>
	Task<ActorResponseDto> GetActorByIdAsync(Guid id);

	/// <summary>
	/// Adds a new actor.
	/// </summary>
	/// <param name="addActorRequestDto"> The information of the new actor. </param>
	/// <returns>The newly added actor as an <see cref="ActorResponseDto"/> object.</returns>
	Task<ActorResponseDto?> AddActorAsync(AddActorRequestDto addActorRequestDto);
}
