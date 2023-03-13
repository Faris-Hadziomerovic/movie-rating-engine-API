using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using MovieRatingEngine.API.Constants;

namespace MovieRatingEngine.API.Helpers;

/// <summary>
/// Json to DateOnly converter.
/// </summary>
public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
	/// <summary>
	/// Reads the Date only.
	/// </summary>
	/// <param name="reader">The Utf8JsonReader reader.</param>
	/// <param name="typeToConvert">The type to convert.</param>
	/// <param name="options">The Json Serializer Options.</param>
	/// <returns> The parsed date only.</returns>
	public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return DateOnly.ParseExact(
			reader.GetString() !,
			FormatConstants.IsoDateOnlyFormatConstant,
			CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Writes the Date only.
	/// </summary>
	/// <param name="writer">The Utf 8 Json Writer.</param>
	/// <param name="value">The date only.</param>
	/// <param name="options">The Json Serializer Option.</param>
	public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
	{
		var isoDate = value.ToString(FormatConstants.IsoDateOnlyFormatConstant);
		writer.WriteStringValue(value.ToString(isoDate, CultureInfo.InvariantCulture));
	}
}
