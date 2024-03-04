using System.Text.Json.Serialization;

namespace Lagrange.OneBot.Core.Entity.Notify;

[Serializable]
public class OneBotFriendRequest(uint selfId, uint userId, string flag) : OneBotRequest(selfId, "friend", "", flag)
{
    [JsonPropertyName("user_id")] public uint UserId { get; set; } = userId;
}