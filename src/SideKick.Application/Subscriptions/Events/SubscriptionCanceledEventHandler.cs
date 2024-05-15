using MediatR;

using SideKick.Application.Common.Interfaces;
using SideKick.Domain.Users.Events;

namespace SideKick.Application.Subscriptions.Events;

public class SubscriptionCanceledEventHandler(IUsersRepository _usersRepository)
    : INotificationHandler<SubscriptionCanceledEvent>
{
    public async Task Handle(SubscriptionCanceledEvent notification, CancellationToken cancellationToken)
    {
        notification.User.DeleteAllReminders();

        await _usersRepository.RemoveAsync(notification.User, cancellationToken);
    }
}
