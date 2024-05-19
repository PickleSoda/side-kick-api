using SideKick.Domain.Common;
using SideKick.Domain.ReminderSchedules;

namespace SideKick.Domain.Users.Events;

public record ReminderAddedToHabitEvent(ReminderSchedule Reminder) : IDomainEvent;
