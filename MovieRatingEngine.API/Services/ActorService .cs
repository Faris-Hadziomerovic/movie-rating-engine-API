using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieRatingEngine.API.DataAccess;
using MovieRatingEngine.API.Envelopes.Requests;
using MovieRatingEngine.API.Envelopes.Responses;
using MovieRatingEngine.API.Helpers.Exceptions;
using MovieRatingEngine.API.Models;
using MovieRatingEngine.API.Services.Interfaces;

namespace MovieRatingEngine.API.Services;

/// <summary>
/// The actor service.
/// </summary>
/// <seealso cref="IActorService"/>
public class ActorService : IActorService
{
	private readonly DatabaseContext _databaseContext;
	private readonly IValidator<GetActorsRequestDto> _getActorsRequestDtoValidator;
	private readonly IValidator<AddActorRequestDto> _addActorRequestDtoValidator;

	/// <summary>
	/// Initializes a new instance of the <see cref="ActorService"/> class.
	/// </summary>
	/// <param name="databaseContext">The database context.</param>
	/// <param name="getValidator">Validation service for get actor requests.</param>
	/// <param name="addValidator">Validation service for add actor requests.</param>
	public ActorService(
		DatabaseContext databaseContext,
		IValidator<GetActorsRequestDto> getValidator,
		IValidator<AddActorRequestDto> addValidator)
	{
		_databaseContext = databaseContext;
		_getActorsRequestDtoValidator = getValidator;
		_addActorRequestDtoValidator = addValidator;
	}

	/// <inheritdoc/>
	public async Task<ActorResponseDto> GetActorByIdAsync(Guid id)
	{
		var result = await _databaseContext.Actors
			.Where(a => a.Id == id)
			.Select(a => new ActorResponseDto
				{
					Id = a.Id,
					Name = $"{a.FirstName} {a.LastName}",
				})
			.FirstOrDefaultAsync();

		if (result is null)
		{
			throw new ActorNotFoundException();
		}

		return result;
	}

	/// <inheritdoc/>
	public async Task<IEnumerable<ActorResponseDto>> GetActorsAsync(GetActorsRequestDto getActorsRequestDto)
	{
		await _getActorsRequestDtoValidator.ValidateAndThrowAsync(getActorsRequestDto);

		var skip = (getActorsRequestDto.Page - 1) * getActorsRequestDto.Size;

		var query = string.IsNullOrEmpty(getActorsRequestDto.Search) ?
			_databaseContext.Actors :
			_databaseContext.Actors.Where(a =>
				a.FirstName!.ToLower().StartsWith(getActorsRequestDto.Search!.ToLower()) ||
				a.LastName!.ToLower().StartsWith(getActorsRequestDto.Search!.ToLower()));

		var result = await query
			.OrderBy(a => a.FirstName)
			.Skip(skip)
			.Take(getActorsRequestDto.Size)
			.Select(a => new ActorResponseDto
			{
				Id = a.Id,
				Name = $"{a.FirstName} {a.LastName}",
			})
			.ToListAsync();

		return result;
	}

	/// <inheritdoc/>
	public async Task<ActorResponseDto?> AddActorAsync(AddActorRequestDto addActorRequestDto)
	{
		await _addActorRequestDtoValidator.ValidateAndThrowAsync(addActorRequestDto);

		var actorExists = await _databaseContext.Actors.AnyAsync(a =>
			a.FirstName!.ToLower() == addActorRequestDto.FirstName!.ToLower() &&
			a.LastName!.ToLower() == addActorRequestDto.LastName!.ToLower());

		if (actorExists)
		{
			throw new ActorAlreadyExistsException();
		}

		var actor = new Actor
		{
			Id = Guid.NewGuid(),
			FirstName = addActorRequestDto.FirstName,
			LastName = addActorRequestDto.LastName,
		};

		_databaseContext.Actors.Add(actor);

		await _databaseContext.SaveChangesAsync();

		return new ActorResponseDto
		{
			Id = actor.Id,
			Name = $"{actor.FirstName} {actor.LastName}",
		};
	}
}
