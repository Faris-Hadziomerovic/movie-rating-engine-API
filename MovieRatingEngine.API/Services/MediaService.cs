using Microsoft.EntityFrameworkCore;
using MovieRatingEngine.API.Constants;
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

	/// <summary>
	/// Initializes a new instance of the <see cref="MediaService"/> class.
	/// </summary>
	/// <param name="databaseContext">The database context.</param>
	public MediaService(DatabaseContext databaseContext)
	{
		_databaseContext = databaseContext;
	}

	/// <inheritdoc/>
	public async Task<MediaDetailsResponseDto> GetMediaDetailsByIdAsync(Guid id)
	{
		// TODO return cast
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
			})
			.FirstOrDefaultAsync();

		if (result is null)
		{
			throw new MediaItemNotFoundException();
		}

		return result;
	}

	/// <inheritdoc/>
	public async Task<IEnumerable<MediaLookupResponseDto>> GetMediaLookupsAsync(string? search, bool? searchShows, int size, int page)
	{
		// TODO return cast
		// TODO implement size and take
		// TODO implement search
		var result = await _databaseContext.MediaItems
			.Select(m => new MediaLookupResponseDto
			{
				Id = m.Id,
				Title = m.Title,
				MediaType = m.MediaType == MediaType.Movie ? "Movie" : "TV Show",
				ReleaseDate = m.ReleaseDate,
				AverageRating = m.Reviews!.Count > 0 ? m.Reviews.Average(r => r.Rating) : 0,
			})
			.OrderByDescending(m => m.AverageRating)
			.ToListAsync();

		return result;
	}

	/// <inheritdoc/>
	public async Task<IEnumerable<MediaLookupResponseDto>> GetMediaLookupsByDTOAsync(GetMediaLookupsRequestDto getMediaLookupsRequest)
	{
		var size = getMediaLookupsRequest.Size;
		var page = getMediaLookupsRequest.Page;

		if (string.IsNullOrWhiteSpace(getMediaLookupsRequest.Search))
		{
			Console.WriteLine($"Search: {getMediaLookupsRequest.Search}");
		}
		else
		{
			Console.WriteLine($"Filter: {(getMediaLookupsRequest.SearchShows ?? false ? MediaType.TvShow : MediaType.Movie)}");
			Console.WriteLine($"MediaContentType: {getMediaLookupsRequest.MediaContentType}");
		}

		Console.WriteLine($"Size: {getMediaLookupsRequest.Size}");
		Console.WriteLine($"Page: {getMediaLookupsRequest.Page}");
		Console.WriteLine($"From: {((page - 1) * size) + 1}");
		Console.WriteLine($"To: {page * size}");

		// TODO return cast
		// TODO implement size and take
		// TODO implement search
		var result = await _databaseContext.MediaItems
			.Select(m => new MediaLookupResponseDto
			{
				Id = m.Id,
				Title = m.Title,
				MediaType = m.MediaType == MediaType.Movie ? "Movie" : "TV Show",
				ReleaseDate = m.ReleaseDate,
				AverageRating = m.Reviews!.Count > 0 ? m.Reviews.Average(r => r.Rating) : 0,
			})
			.OrderByDescending(m => m.AverageRating)
			.ToListAsync();

		return result;
	}

	/// <inheritdoc/>
	public async Task<MediaDetailsResponseDto?> AddMediaAsync(AddMediaRequestDto addMediaRequestDto)
	{
		var actorsToAdd = await _databaseContext.Actors
			.Where(a => addMediaRequestDto.Cast!.Contains(a.Id))
			.ToListAsync();

		if (actorsToAdd.Count < ValidatorConstants.MinNumberOfCastMembers)
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
