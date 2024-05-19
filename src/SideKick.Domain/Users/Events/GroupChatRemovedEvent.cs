using SideKick.Domain.Common;

namespace SideKick.Domain.Users.Events;
public record GroupChatRemovedEvent(Guid GroupChatId, Guid UserId) : IDomainEvent;

