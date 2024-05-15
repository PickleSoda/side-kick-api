using SideKick.Domain.Common;

namespace SideKick.Domain.Users.Events;

public record ReminderDeletedEvent(Guid ReminderId) : IDomainEvent;