using System;
using System.Net;
using Newtonsoft.Json;

[JsonModel]
public class IPAddressJsonConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(IPAddress);
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		string text = ((value is IPAddress iPAddress) ? iPAddress.ToString() : null);
		writer.WriteValue(text);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)reader.TokenType != 9)
		{
			return null;
		}
		if (!IPAddress.TryParse((string)reader.Value, out var address))
		{
			return null;
		}
		return address;
	}
}
