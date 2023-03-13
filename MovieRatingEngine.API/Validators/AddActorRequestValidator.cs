using FluentValidation;
using MovieRatingEngine.API.Envelopes.Requests;

namespace MovieRatingEngine.API.Validators;

/// <summary>
/// Validator for the <see cref="AddActorRequestDto"/>.
/// </summary>
public class AddActorRequestDtoValidator : AbstractValidator<AddActorRequestDto>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AddActorRequestDtoValidator"/> class.
	/// </summary>
	public AddActorRequestDtoValidator()
	{
		RuleFor(x => x.FirstName).NotEmpty();

		RuleFor(x => x.LastName).NotEmpty();
	}
}
