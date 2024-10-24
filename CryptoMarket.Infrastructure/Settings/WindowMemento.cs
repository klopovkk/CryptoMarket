using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CryptoMarket.Infrastructure.Settings;

internal abstract class WindowMemento
{
    [DataMember(Name = "left")]
    [JsonProperty]
    public double Left { get; set; }

    [DataMember(Name = "width")]
    [JsonProperty]
    public double Width { get; set; }

    [JsonProperty]
    [DataMember(Name = "top")]
    public double Top { get; set; }

    [JsonProperty]
    [DataMember(Name = "height")]
    public double Height { get; set; }

    [JsonProperty]
    [DataMember(Name = "isMaximized")]
    public bool IsMaximized { get; set; }
}