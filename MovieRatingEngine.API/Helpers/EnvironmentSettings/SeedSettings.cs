namespace MovieRatingEngine.API.Helpers.EnvironmentSettings;

/// <summary>
/// Represents the seed settings for the application.
/// </summary>
public class SeedSettings
{
	/// <summary>
	/// Gets or sets a value indicating whether the constants should be seeded.
	/// </summary>
	/// <value>
	/// <see langword="true"/> if the constants should be seeded; otherwise, <see langword="false"/>.
	/// </value>
	public bool? ShouldSeedConstants { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the movies should be seeded.
	/// </summary>
	/// <value>
	/// <see langword="true"/> if the movies should be seeded; otherwise, <see langword="false"/>.
	/// </value>
	public bool? ShouldSeedMovies { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the TV shows should be seeded.
	/// </summary>
	/// <value>
	/// <see langword="true"/> if the TV shows should be seeded; otherwise, <see langword="false"/>.
	/// </value>
	public bool? ShouldSeedTvShows { get; set; }
}
