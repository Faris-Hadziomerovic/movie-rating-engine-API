using FluentValidation;
using MovieRatingEngine.API.Constants;
using MovieRatingEngine.API.Envelopes.Requests;

namespace MovieRatingEngine.API.Validators;

/// <summary>
/// Validator for the <see cref="GetActorsRequestDto"/>.
/// </summary>
public class GetActorsRequestDtoValidator : AbstractValidator<GetActorsRequestDto>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="GetActorsRequestDtoValidator"/> class.
	/// </summary>
	public GetActorsRequestDtoValidator()
	{
		RuleFor(x => x.Page).GreaterThanOrEqualTo(ValidatorConstants.MinRequestPageNumber);

		RuleFor(x => x.Size)
			.LessThanOrEqualTo(ValidatorConstants.MaxActorsSizeLength)
			.GreaterThanOrEqualTo(ValidatorConstants.MinActorsSizeLength);
	}
}
