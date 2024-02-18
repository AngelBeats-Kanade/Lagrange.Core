using Lagrange.Core.Message;

namespace Lagrange.Core.Event.EventArg;

public class FriendMessageEvent(MessageChain chain) : EventBase
{
    public MessageChain Chain { get; set; } = chain;
}