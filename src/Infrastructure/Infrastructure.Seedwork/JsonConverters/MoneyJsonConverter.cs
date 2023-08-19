using System.Text.Json;
using System.Text.Json.Serialization;
using Infrastructure.Seedwork.DataTypes;

namespace Infrastructure.Seedwork.JsonConverters;

public sealed class MoneyJsonConverter : JsonConverter<Money>
{
    public override Money Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var moneyDTO = JsonSerializer.Deserialize<MoneyDTO>(ref reader, options)!;
        var currency = Currency.Create(moneyDTO.Currency);
        
        return Money.Create(moneyDTO.Amount, currency);
    }

    public override void Write(Utf8JsonWriter writer, Money value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, typeof(Money), options);
    }

    private class MoneyDTO
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; } = null!;
    }
}