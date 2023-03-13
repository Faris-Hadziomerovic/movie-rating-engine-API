using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieRatingEngine.API.DataAccess;
using MovieRatingEngine.API.Enums;
using MovieRatingEngine.API.Envelopes.Requests;
using MovieRatingEngine.API.Envelopes.Responses;
using MovieRatingEngine.API.Helpers.Exceptions;
using MovieRatingEngine.API.Models;
using MovieRatingEngine.API.Services.Interfaces;

namespace MovieRatingEngine.API.Services;

/// <summary>
/// The media service.
/// </summary>
/// <seealso cref="IMediaService"/>
public class MediaService : IMediaService
{
	private readonly DatabaseContext _databaseContext;
	private readonly IValidator<GetMediaLookupsRequestDto> _getMediaLookupsRequestDtoValidator;
	private readonly IValidator<AddMediaRequestDto> _addMediaRequestDtoValidator;
	private readonly IValidator<AddReviewRequestDto> _addReviewRequestDtoValidator;

	/// <summary>
	/// Initializes a new instance of the <see cref="MediaService"/> class.
	/// </summary>
	/// <param name="databaseContext">The database context.</param>
	/// /// <param name="getValidator">Validation service for get media lookups requests.</param>
	/// <param name="addMediaValidator">Validation service for add media item requests.</param>
	/// <param name="addReviewValidator">Validation service for add review requests.</param>
	public MediaService(
	    DatabaseContext databaseContext,
	    IValidator<GetMediaLookupsRequestDto> getValidator,
	    IValidator<AddMediaRequestDto> addMediaValidator,
	    IValidator<AddReviewRequestDto> addReviewValidator)
	{
		_databaseContext = databaseContext;

		_getMediaLookupsRequestDtoValidator = getValidator;
		_addMediaRequestDtoValidator = addMediaValidator;
		_addReviewRequestDtoValidator = addReviewValidator;
	}

	/// <inheritdoc/>
	public async Task<MediaDetailsResponseDto> GetMediaDetailsByIdAsync(Guid id)
	{
		var result = await _databaseContext.MediaItems
			.Where(m => m.Id == id)
			.Select(m => new MediaDetailsResponseDto
			{
				Id = m.Id,
				Title = m.Title,
				Description = m.Description,
				ImageUrl = m.ImageUrl,
				MediaType = m.MediaType == MediaType.Movie ? "Movie" : "TV Show",
				ReleaseDate = m.ReleaseDate,
				AverageRating = m.Reviews!.Count > 0 ? m.Reviews.Average(r => r.Rating) : 0,
				Cast = m.Cast!.Select(x => new ActorResponseDto
				{
					Id = x.Id,
					Name = $"{x.FirstName} {x.LastName}",
				}).ToList(),
			})
			.FirstOrDefaultAsync();

		if (result is null)
		{
			throw new MediaItemNotFoundException();
		}

		return result;
	}

	/// <inheritdoc/>
	public async Task<IEnumerable<MediaLookupResponseDto>> GetMediaLookupsAsync(GetMediaLookupsRequestDto getMediaLookupsRequest)
	{
		await _getMediaLookupsRequestDtoValidator.ValidateAndThrowAsync(getMediaLookupsRequest);

		var skip = (getMediaLookupsRequest.Page - 1) * getMediaLookupsRequest.Size;

		var query = _databaseContext.MediaItems.AsQueryable();

		if (string.IsNullOrWhiteSpace(getMediaLookupsRequest.Search))
		{
			MediaType requestedMediaType =
				getMediaLookupsRequest.SearchShows ?? false ? MediaType.TvShow : MediaType.Movie;

			query = query.Where(m => m.MediaType == requestedMediaType);
		}
		else
		{
			query = query.Where(m => m.Title!.ToLower().Contains(getMediaLookupsRequest.Search!.ToLower()) ||
			                         m.Description!.ToLower().Contains(getMediaLookupsRequest.Search!.ToLower()));
		}

		// TODO return cast ???
		var result = await query
			.Select(m => new MediaLookupResponseDto
			{
				Id = m.Id,
				Title = m.Title,
				MediaType = m.MediaType == MediaType.Movie ? "Movie" : "TV Show",
				ReleaseDate = m.ReleaseDate,
				AverageRating = m.Reviews!.Count > 0 ? m.Reviews.Average(r => r.Rating) : 0,
			})
			.Skip(skip)
			.Take(getMediaLookupsRequest.Size)
			.OrderByDescending(m => m.AverageRating)
			.ToListAsync();

		return result;
	}

	/// <inheritdoc/>
	public async Task<int> GetMediaCountAsync()
	{
		return await _databaseContext.MediaItems.CountAsync();
	}

	/// <inheritdoc/>
	public async Task<MediaDetailsResponseDto?> AddMediaAsync(AddMediaRequestDto addMediaRequestDto)
	{
		await _addMediaRequestDtoValidator.ValidateAndThrowAsync(addMediaRequestDto);

		var actorsToAdd = await _databaseContext.Actors
			.Where(a => addMediaRequestDto.Cast!.Contains(a.Id))
			.ToListAsync();

		if (actorsToAdd.Count != addMediaRequestDto.Cast!.Count)
		{
			throw new ArgumentException("One or more actor Ids are invalid");
		}

		var mediaItem = new Media
		{
			Id = Guid.NewGuid(),
			Title = addMediaRequestDto.Title,
			Description = addMediaRequestDto.Description,
			ImageUrl = addMediaRequestDto.ImageUrl,
			MediaType = addMediaRequestDto.MediaType,
			ReleaseDate = addMediaRequestDto.ReleaseDate,
			Cast = new List<Actor>(),
		};

		_databaseContext.MediaItems.Add(mediaItem);

		await _databaseContext.SaveChangesAsync();

		foreach (var actor in actorsToAdd)
		{
			mediaItem.Cast.Add(actor);
		}

		await _databaseContext.SaveChangesAsync();

		return new MediaDetailsResponseDto
		{
			Id = mediaItem.Id,
			Title = mediaItem.Title,
			Description = mediaItem.Description,
			ImageUrl = mediaItem.ImageUrl,
			AverageRating = 0,
			MediaType = mediaItem.MediaType == MediaType.Movie ? "Movie" : "TV Show",
			ReleaseDate = mediaItem.ReleaseDate,
			Cast = actorsToAdd.Select(a =>
				new ActorResponseDto
				{
					Id = a.Id,
					Name = $"{a.FirstName} {a.LastName}",
				}).ToList(),
		};
	}

	/// <inheritdoc/>
	public async Task<ReviewResponseDto> PostReviewByIdAsync(AddReviewRequestDto addReviewRequestDto)
	{
		await _addReviewRequestDtoValidator.ValidateAndThrowAsync(addReviewRequestDto);

		var mediaItem = await _databaseContext.MediaItems.FirstOrDefaultAsync(m => m.Id == addReviewRequestDto.MediaId);

		if (mediaItem is null)
		{
			throw new MediaItemNotFoundException();
		}

		var review = new Review
		{
			Id = Guid.NewGuid(),
			MediaId = mediaItem.Id,
			Rating = addReviewRequestDto.Rating,
			Comment = addReviewRequestDto.Comment,
			UserId = addReviewRequestDto.UserId,
		};

		_databaseContext.Reviews.Add(review);

		await _databaseContext.SaveChangesAsync();

		return new ReviewResponseDto
		{
			Id = review.Id,
			Rating = review.Rating,
			MediaId = mediaItem.Id,
			MediaTitle = mediaItem.Title,
			Comment = review.Comment,
			UserId = review.UserId,
		};
	}
}
