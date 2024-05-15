using ErrorOr;

using SideKick.Application.Common.Security.Permissions;
using SideKick.Application.Common.Security.Policies;
using SideKick.Application.Common.Security.Request;
using SideKick.Domain.Reminders;

namespace SideKick.Application.Reminders.Queries.ListReminders;

[Authorize(Permissions = Permission.Reminder.Get, Policies = Policy.SelfOrAdmin)]
public record ListRemindersQuery(Guid UserId, Guid SubscriptionId) : IAuthorizeableRequest<ErrorOr<List<Reminder>>>;