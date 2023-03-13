using MovieRatingEngine.API.Constants;

namespace MovieRatingEngine.API.Extensions;

/// <summary>
/// Contains extension for <see cref="IHostEnvironment"/> class.
/// </summary>
public static class EnvironmentExtensions
{
	/// <summary>
	/// Checks if the current host environment name is Local.
	/// </summary>
	/// <param name="hostEnvironment">An instance of IHostEnvironment.</param>
	/// <returns>True if the environment name is Local, otherwise false.</returns>
	public static bool IsLocal(this IHostEnvironment hostEnvironment)
	{
		return hostEnvironment.IsEnvironment(EnvironmentConstants.Local);
	}
}