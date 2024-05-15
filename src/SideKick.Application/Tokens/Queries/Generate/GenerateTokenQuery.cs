using SideKick.Application.Authentication.Queries.Login;
using SideKick.Domain.Users;

using ErrorOr;

using MediatR;

namespace SideKick.Application.Tokens.Queries.Generate;

public record GenerateTokenQuery(
    Guid? Id,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType,
    List<string> Permissions,
    List<string> Roles) : IRequest<ErrorOr<GenerateTokenResult>>;