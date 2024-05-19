using SideKick.Domain.Common;

namespace SideKick.Domain.Users.Events;
    public record ReminderRemovedFromHabitEvent(Guid ReminderScheduleId) : IDomainEvent;

