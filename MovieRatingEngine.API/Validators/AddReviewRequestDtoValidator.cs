using FluentValidation;
using MovieRatingEngine.API.Constants;
using MovieRatingEngine.API.Envelopes.Requests;

namespace MovieRatingEngine.API.Validators;

/// <summary>
/// Validator for the <see cref="AddReviewRequestDto"/>.
/// </summary>
public class AddReviewRequestDtoValidator : AbstractValidator<AddReviewRequestDto>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AddReviewRequestDtoValidator"/> class.
	/// </summary>
	public AddReviewRequestDtoValidator()
	{
		RuleFor(x => x.MediaId).NotEmpty();

		RuleFor(x => x.Rating)
			.GreaterThanOrEqualTo(ValidatorConstants.MinRatingScore)
			.LessThanOrEqualTo(ValidatorConstants.MaxRatingScore);

		RuleFor(x => x.Comment)
			.MaximumLength(ValidatorConstants.MaxCommentLenght)
			.MinimumLength(ValidatorConstants.MinCommentLenght)
			.Unless(x => string.IsNullOrWhiteSpace(x.Comment));
	}
}
