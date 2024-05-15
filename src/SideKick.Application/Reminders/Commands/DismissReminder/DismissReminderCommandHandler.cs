using ErrorOr;

using MediatR;

using SideKick.Application.Common.Interfaces;

namespace SideKick.Application.Reminders.Commands.DismissReminder;

public class DismissReminderCommandHandler(
    IUsersRepository _usersRepository)
        : IRequestHandler<DismissReminderCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DismissReminderCommand request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Error.NotFound(description: "Reminder not found");
        }

        var dismissReminderResult = user.DismissReminder(request.ReminderId);

        if (dismissReminderResult.IsError)
        {
            return dismissReminderResult.Errors;
        }

        await _usersRepository.UpdateAsync(user, cancellationToken);

        return Result.Success;
    }
}
