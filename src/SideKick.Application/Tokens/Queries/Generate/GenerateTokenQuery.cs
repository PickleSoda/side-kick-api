using ErrorOr;

using MediatR;

using SideKick.Application.Authentication.Queries.Login;
using SideKick.Domain.Users;

namespace SideKick.Application.Tokens.Queries.Generate;

public record GenerateTokenQuery(
    Guid? Id,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType,
    List<string> Permissions,
    List<string> Roles) : IRequest<ErrorOr<GenerateTokenResult>>;