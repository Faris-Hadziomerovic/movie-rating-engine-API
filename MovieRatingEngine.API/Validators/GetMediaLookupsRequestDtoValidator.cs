using FluentValidation;
using MovieRatingEngine.API.Constants;
using MovieRatingEngine.API.Envelopes.Requests;

namespace MovieRatingEngine.API.Validators;

/// <summary>
/// Validator for the <see cref="GetMediaLookupsRequestDto"/>.
/// </summary>
public class GetMediaLookupsRequestDtoValidator : AbstractValidator<GetMediaLookupsRequestDto>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="GetMediaLookupsRequestDtoValidator"/> class.
	/// </summary>
	public GetMediaLookupsRequestDtoValidator()
	{
		RuleFor(x => x.Page).GreaterThanOrEqualTo(ValidatorConstants.MinRequestPageNumber);

		RuleFor(x => x.Size)
			.LessThanOrEqualTo(ValidatorConstants.MaxMediaLookupsSizeLength)
			.GreaterThanOrEqualTo(ValidatorConstants.MinMediaLookupsSizeLength);
	}
}
