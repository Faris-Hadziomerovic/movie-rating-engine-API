using System.Text.Json.Serialization;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MovieRatingEngine.API.Constants;
using MovieRatingEngine.API.DataAccess;
using MovieRatingEngine.API.Envelopes.Requests;
using MovieRatingEngine.API.Extensions;
using MovieRatingEngine.API.Helpers;
using MovieRatingEngine.API.Helpers.EnvironmentSettings;
using MovieRatingEngine.API.Middleware.ExceptionHandling.Extensions;
using MovieRatingEngine.API.Services;
using MovieRatingEngine.API.Services.Interfaces;
using MovieRatingEngine.API.Validators;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MovieRatingEngine.API;

/// <summary>
/// Class that adds services.
/// </summary>
internal static class HostingExtensions
{
	/// <summary>
	/// Configures the services.
	/// </summary>
	/// <param name="builder">Application builder.</param>
	/// <returns>Web application.</returns>
	public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
	{
		builder.Services.AddControllers();

		builder.Services.AddEndpointsApiExplorer();

		// Adding swagger and enabling log in with swagger
		builder.Services.AddSwaggerGen(options =>
			options.MapType<DateOnly>(() => new OpenApiSchema
			{
				Type = "string",
				Format = "date",
				Example = new OpenApiString("2022-01-01"),
			}));

		builder.Services.AddCors(options =>
		{
			options.AddDefaultPolicy(
				corsPolicyBuilder =>
				{
					var allowedOrigins = builder.Configuration.GetSection(nameof(CorsSettings))
						.Get<CorsSettings>().AllowedOrigins;

					corsPolicyBuilder.WithOrigins(allowedOrigins)
						.AllowAnyHeader()
						.WithMethods(
							HttpMethodConstants.Get,
							HttpMethodConstants.Post)
						.AllowCredentials();
				});
		});

		builder.Services.AddAuthentication();

		// Adding database Context
		builder.Services.AddDbContext<DatabaseContext>(options =>
		{
			var defaultConnection = builder.Configuration
				.GetSection(nameof(ConnectionStrings))
				.Get<ConnectionStrings>()
				.DefaultConnection;

			if (defaultConnection is not null)
			{
				options.UseNpgsql(defaultConnection);
			}
		});

		builder.ConfigureCustomDependencies();

		builder.ConfigureIOptionDependencies();

		return builder.Build();
	}

	/// <summary>
	/// Configures the pipeline.
	/// </summary>
	/// <param name="app">Web application.</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation with web application.</returns>
	public static WebApplication ConfigurePipeline(this WebApplication app)
	{
		// Seeds database (Make sure to comment/delete before deploy!!!!!!!!)
		SeedDatabase(app);

		app.UseHttpLogging();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment() || app.Environment.IsLocal())
		{
			app.UseSwagger();
			app.UseSwaggerUI(options => options.DocExpansion(DocExpansion.None));
		}

		app.ConfigureExceptionMiddleware();

		app.UseHttpsRedirection();

		app.UseCors();

		app.UseAuthorization();

		app.UseAuthentication();

		app.MapControllers();

		return app;
	}

	/// <summary>
	/// Configures any custom dependencies required by the application.
	/// </summary>
	/// <param name="builder"> The <see cref="WebApplicationBuilder"/> instance. </param>
	/// <returns> The same <see cref="WebApplicationBuilder"/> instance. </returns>
	private static WebApplicationBuilder ConfigureCustomDependencies(this WebApplicationBuilder builder)
	{
		// Register validator dependencies
		builder.Services.AddScoped<IValidator<GetMediaLookupsRequestDto>, GetMediaLookupsRequestDtoValidator>();
		builder.Services.AddScoped<IValidator<GetActorsRequestDto>, GetActorsRequestDtoValidator>();
		builder.Services.AddScoped<IValidator<AddActorRequestDto>, AddActorRequestDtoValidator>();

		// Register other dependencies that need resolving
		builder.Services.AddTransient<IMediaService, MediaService>();
		builder.Services.AddTransient<IActorService, ActorService>();

		return builder;
	}

	/// <summary>
	/// Configures the database context for the application.
	/// </summary>
	/// <param name="builder"> The <see cref="WebApplicationBuilder"/> instance. </param>
	/// <returns> The same <see cref="WebApplicationBuilder"/> instance. </returns>
	private static WebApplicationBuilder ConfigureDatabaseContext(this WebApplicationBuilder builder)
	{
		// Add the DatabaseContext service to the service collection using the default connection string from the configuration.
		builder.Services.AddDbContext<DatabaseContext>(options =>
		{
			var defaultConnection = builder.Configuration
				.GetSection(nameof(ConnectionStrings))
				.Get<ConnectionStrings>()
				.DefaultConnection;

			if (defaultConnection is not null)
			{
				options.UseNpgsql(defaultConnection);
			}
		});

		return builder;
	}

	/// <summary>
	/// Configures the application settings from configuration files.
	/// </summary>
	/// <param name="builder"> The <see cref="WebApplicationBuilder"/> instance. </param>
	/// <returns> The same <see cref="WebApplicationBuilder"/> instance. </returns>
	private static WebApplicationBuilder ConfigureIOptionDependencies(this WebApplicationBuilder builder)
	{
		// Configure the ConnectionStrings, CorsSettings, and SeedSettings options using the Configuration object.
		builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));
		builder.Services.Configure<CorsSettings>(builder.Configuration.GetSection(nameof(CorsSettings)));
		builder.Services.Configure<SeedSettings>(builder.Configuration.GetSection(nameof(SeedSettings)));

		// Add the Options service to the service collection.
		builder.Services.AddOptions();

		return builder;
	}

	/// <summary>
	/// Seeds the database with default data.
	/// </summary>
	/// <param name="app"> The <see cref="IHost"/> instance. </param>
	private static void SeedDatabase(IHost app)
	{
		using var scope = app.Services.CreateScope();
		var services = scope.ServiceProvider;
		var loggerFactory = services.GetRequiredService<ILoggerFactory>();
		var logger = loggerFactory.CreateLogger("app");

		try
		{
			var databaseContext = services.GetRequiredService<DatabaseContext>();

			// TODO: Add code to seed the database with default data.

			logger.LogInformation("Finished Seeding Default Data");
			logger.LogInformation("Application Starting");
		}
		catch (Exception ex)
		{
			logger.LogWarning(ex, "An error occurred seeding the DB");
		}
	}
}
