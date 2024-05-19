using ErrorOr;
using MediatR;
using SideKick.Application.Common.Interfaces;
using SideKick.Application.Common.Security.Permissions;
using SideKick.Application.Common.Security.Request;

namespace SideKick.Application.Habits.Commands.DeleteHabit
{
    [Authorize(Permissions = Permission.Habit.Delete)]
    public record DeleteHabitCommand(Guid Id)
        : IRequest<ErrorOr<Success>>;

    public class DeleteHabitCommandHandler : IRequestHandler<DeleteHabitCommand, ErrorOr<Success>>
    {
        private readonly IHabitsRepository _habitsRepository;

        public DeleteHabitCommandHandler(IHabitsRepository habitsRepository)
        {
            _habitsRepository = habitsRepository;
        }

        public async Task<ErrorOr<Success>> Handle(
            DeleteHabitCommand request,
            CancellationToken cancellationToken)
        {
            var habit = await _habitsRepository.GetByIdAsync(request.Id, cancellationToken);
            if (habit == null)
            {
                return Error.NotFound("Habit not found.");
            }

            await _habitsRepository.RemoveAsync(habit, cancellationToken);
            return Result.Success;
        }
    }
}
