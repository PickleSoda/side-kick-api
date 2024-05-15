using SideKick.Domain.Common;
using SideKick.Domain.Reminders;

namespace SideKick.Domain.Users.Events;

public record ReminderSetEvent(Reminder Reminder) : IDomainEvent;