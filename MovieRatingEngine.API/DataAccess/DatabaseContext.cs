using Microsoft.EntityFrameworkCore;
using MovieRatingEngine.API.Models;

#nullable disable

namespace MovieRatingEngine.API.DataAccess;

/// <summary>
/// Database context class.
/// It will use Postgres Database.
/// </summary>
public class DatabaseContext : DbContext
{
	/// <summary>
	/// Initializes a new instance of the <see cref="DatabaseContext"/> class.
	/// </summary>
	/// <param name="options">Database context options.</param>
	public DatabaseContext(DbContextOptions options) : base(options)
	{
	}

	/// <summary>
	/// Gets or sets the media content items.
	/// </summary>
	/// <value>
	/// The media content items.
	/// </value>
	public DbSet<Media> MediaItems { get; set; }

	/// <summary>
	/// Gets or sets the actors.
	/// </summary>
	/// <value>
	/// The actors.
	/// </value>
	public DbSet<Actor> Actors { get; set; }

	/// <summary>
	/// Gets or sets the reviews.
	/// </summary>
	/// <value>
	/// The reviews.
	/// </value>
	public DbSet<Review> Reviews { get; set; }
}
