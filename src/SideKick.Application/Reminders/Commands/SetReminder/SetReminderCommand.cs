using ErrorOr;

using SideKick.Application.Common.Security.Permissions;
using SideKick.Application.Common.Security.Policies;
using SideKick.Application.Common.Security.Request;
using SideKick.Domain.Reminders;

namespace SideKick.Application.Reminders.Commands.SetReminder;

[Authorize(Permissions = Permission.Reminder.Set, Policies = Policy.SelfOrAdmin)]
public record SetReminderCommand(Guid UserId, Guid SubscriptionId, string Text, DateTime DateTime)
    : IAuthorizeableRequest<ErrorOr<Reminder>>;