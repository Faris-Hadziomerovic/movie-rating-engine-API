using FluentValidation;
using MovieRatingEngine.API.Constants;
using MovieRatingEngine.API.Envelopes.Requests;

namespace MovieRatingEngine.API.Validators;

/// <summary>
/// Validator for the <see cref="AddMediaRequestDto"/>.
/// </summary>
public class AddMediaRequestDtoValidator : AbstractValidator<AddMediaRequestDto>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AddMediaRequestDtoValidator"/> class.
	/// </summary>
	public AddMediaRequestDtoValidator()
	{
		RuleFor(x => x.Title).NotEmpty()
			.MaximumLength(ValidatorConstants.MaxTitleLenght)
			.MinimumLength(ValidatorConstants.MinTitleLenght);

		RuleFor(x => x.Description).NotEmpty()
			.MaximumLength(ValidatorConstants.MaxDescriptionLenght)
			.MinimumLength(ValidatorConstants.MinDescriptionLenght);

		RuleFor(x => x.ImageUrl).NotEmpty();

		RuleFor(x => x.MediaType).IsInEnum();

		RuleFor(x => x.Cast)
			.Must(x => x is not null && x.Count >= ValidatorConstants.MinNumberOfCastMembers)
			.WithMessage($"There should be at least {ValidatorConstants.MinNumberOfCastMembers} cast members.");
	}
}
