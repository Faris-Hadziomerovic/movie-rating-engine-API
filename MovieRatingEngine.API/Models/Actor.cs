namespace MovieRatingEngine.API.Models;

/// <summary>
/// The actor model.
/// </summary>
public class Actor
{
	/// <summary>
	/// Gets or sets the identifier.
	/// </summary>
	/// <value>
	/// The identifier.
	/// </value>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the actor's first name.
	/// </summary>
	/// <value>
	/// The first name.
	/// </value>
	public string? FirstName { get; set; }

	/// <summary>
	/// Gets or sets the actor's last name.
	/// </summary>
	/// <value>
	/// The last name.
	/// </value>
	public string? LastName { get; set; }

	/// <summary>
	/// Gets or sets the acting history of the actor.
	/// </summary>
	/// <value>
	/// List of all media the actor has participated in.
	/// </value>
	public virtual ICollection<Media>? ActingHistory { get; set; }
}
