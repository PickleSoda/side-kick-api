using ErrorOr;

using SideKick.Application.Common.Security.Request;
using SideKick.Application.Common.Security.Roles;

namespace SideKick.Application.Subscriptions.Commands.CancelSubscription;

[Authorize(Roles = Role.Admin)]
public record CancelSubscriptionCommand(Guid UserId, Guid SubscriptionId) : IAuthorizeableRequest<ErrorOr<Success>>;