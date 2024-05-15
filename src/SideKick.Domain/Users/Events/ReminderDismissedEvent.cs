using SideKick.Domain.Common;

namespace SideKick.Domain.Users.Events;

public record ReminderDismissedEvent(Guid ReminderId) : IDomainEvent;