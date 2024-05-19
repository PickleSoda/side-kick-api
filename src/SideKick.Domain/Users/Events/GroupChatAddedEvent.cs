using SideKick.Domain.Common;
using SideKick.Domain.GroupChats;

namespace SideKick.Domain.Users.Events;
public record GroupChatAddedEvent(GroupChat GroupChat) : IDomainEvent;

