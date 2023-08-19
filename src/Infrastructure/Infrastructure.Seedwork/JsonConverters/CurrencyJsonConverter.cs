using System.Text.Json;
using System.Text.Json.Serialization;
using Infrastructure.Seedwork.DataTypes;

namespace Infrastructure.Seedwork.JsonConverters;

public sealed class CurrencyJsonConverter : JsonConverter<Currency>
{
    public override Currency Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString()!;
        return Currency.Create(value);
    }

    public override void Write(Utf8JsonWriter writer, Currency currency, JsonSerializerOptions options)
    {
        writer.WriteStringValue(currency.Key);
    }
}