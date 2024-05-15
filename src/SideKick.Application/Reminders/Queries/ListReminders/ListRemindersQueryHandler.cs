using ErrorOr;

using MediatR;

using SideKick.Application.Common.Interfaces;
using SideKick.Domain.Reminders;

namespace SideKick.Application.Reminders.Queries.ListReminders;

public class ListRemindersQueryHandler(IRemindersRepository _remindersRepository) : IRequestHandler<ListRemindersQuery, ErrorOr<List<Reminder>>>
{
    public async Task<ErrorOr<List<Reminder>>> Handle(ListRemindersQuery request, CancellationToken cancellationToken)
    {
        return await _remindersRepository.ListBySubscriptionIdAsync(request.SubscriptionId, cancellationToken);
    }
}
