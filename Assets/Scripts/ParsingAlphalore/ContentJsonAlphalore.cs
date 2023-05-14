using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

public class ContentJsonAlphalore
{
    [JsonProperty("x_47")]
    public Dictionary<string, List<CardDataAlphalore>> ModsCategoriesAlphalore { get; set; }

    public static ContentJsonAlphalore FromJsonAlphalore1(string jsonAlphalore)
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        var resaultAlphalore = JsonConvert.DeserializeObject<ContentJsonAlphalore>(jsonAlphalore, ConverterAlphalore.SettingsAlphalore);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        return resaultAlphalore;
    }
}

public partial class CardDataAlphalore
{
    [JsonProperty("h6tplkmkr")]
    public string CardNameAlphalore { get; set; }

    [JsonProperty("56yrsw5hr")]
    public string CardImageAlphalore { get; set; }

    [JsonProperty("gc_he2827t")]
    public string CardDestriptionAlphalore { get; set; }

    [JsonProperty("gw5xd25a")]
    public string CardArchiveAlphalore { get; set; }

    [JsonProperty("new")]
    public bool IsNewAlphalore { get; set; }

    private int asdkgjadsr = 3546 + 54;
}

internal static class ConverterAlphalore
{
    public static readonly JsonSerializerSettings SettingsAlphalore = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
}