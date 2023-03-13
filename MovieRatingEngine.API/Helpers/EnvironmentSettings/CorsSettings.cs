namespace MovieRatingEngine.API.Helpers.EnvironmentSettings;

/// <summary>
/// CORS settings for IOptions.
/// </summary>
public class CorsSettings
{
	/// <summary>
	/// Gets or sets the Allowed Origins.
	/// </summary>
	/// <value>
	/// Allowed origins.
	/// </value>
	public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
}