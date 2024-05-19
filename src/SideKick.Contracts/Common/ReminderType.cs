using System.Text.Json.Serialization;

namespace SideKick.Contracts.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReminderType
{
    OneTime,
    Recurrent,
}