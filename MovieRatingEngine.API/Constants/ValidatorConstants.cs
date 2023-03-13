namespace MovieRatingEngine.API.Constants;

/// <summary>
/// The validation constants class.
/// </summary>
public static class ValidatorConstants
{
	/// <summary>
	/// Minimum requested page number.
	/// </summary>
	public const int MinRequestPageNumber = 1;

	/// <summary>
	/// Minimum size of lookups response list length.
	/// </summary>
	public const int MinMediaLookupsSizeLength = 1;

	/// <summary>
	/// Maximun size of lookups response list length.
	/// </summary>
	public const int MaxMediaLookupsSizeLength = 20;

	/// <summary>
	/// Minimum size of actors response list length.
	/// </summary>
	public const int MinActorsSizeLength = 1;

	/// <summary>
	/// Maximun size of actors response list length.
	/// </summary>
	public const int MaxActorsSizeLength = 20;

	/// <summary>
	/// Minimum number of cast members.
	/// </summary>
	public const int MinNumberOfCastMembers = 2;

	/// <summary>
	/// Maximum title length.
	/// </summary>
	public const int MaxTitleLenght = 50;

	/// <summary>
	/// Minimum title length.
	/// </summary>
	public const int MinTitleLenght = 3;

	/// <summary>
	/// Maximum description length.
	/// </summary>
	public const int MaxDescriptionLenght = 999;

	/// <summary>
	/// Minimum description length.
	/// </summary>
	public const int MinDescriptionLenght = 10;

	/// <summary>
	/// Maximum review comment length.
	/// </summary>
	public const int MaxCommentLenght = 150;

	/// <summary>
	/// Minimum review comment length.
	/// </summary>
	public const int MinCommentLenght = 10;

	/// <summary>
	/// Maximum review score.
	/// </summary>
	public const int MaxRatingScore = 5;

	/// <summary>
	/// Minimum review score.
	/// </summary>
	public const int MinRatingScore = 1;
}
