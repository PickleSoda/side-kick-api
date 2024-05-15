using MediatR;

using SideKick.Application.Common.Interfaces;
using SideKick.Domain.Users.Events;

namespace SideKick.Application.Reminders.Events;

public class ReminderSetEventHandler(IRemindersRepository _remindersRepository) : INotificationHandler<ReminderSetEvent>
{
    public async Task Handle(ReminderSetEvent @event, CancellationToken cancellationToken)
    {
        await _remindersRepository.AddAsync(@event.Reminder, cancellationToken);
    }
}
