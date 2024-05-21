using MediatR;

using SideKick.Application.Common.Interfaces;
using SideKick.Domain.Users.Events;

namespace SideKick.Application.Habits.Events;

public class ReminderAddedToHabitEventHandler(IReminderSchedulesRepository _reminderSchedulesRepository) : INotificationHandler<ReminderAddedToHabitEvent>
{
    public async Task Handle(ReminderAddedToHabitEvent @event, CancellationToken cancellationToken)
    {
        await _reminderSchedulesRepository.AddAsync(@event.ReminderSchedule, cancellationToken);
    }
}