using ErrorOr;
using MediatR;
using SideKick.Application.Common.Interfaces;
using SideKick.Application.Common.Security.Permissions;
using SideKick.Application.Common.Security.Request;

namespace SideKick.Application.Habits.Commands.UpdateHabit
{
    [Authorize(Permissions = Permission.Habit.Update)]
    public record UpdateHabitCommand(Guid UserId, Guid Id, string Name, string Description) : IAuthorizeableRequest<ErrorOr<Success>>;

    public class UpdateHabitCommandHandler : IRequestHandler<UpdateHabitCommand, ErrorOr<Success>>
    {
        private readonly IHabitsRepository _habitsRepository;

        public UpdateHabitCommandHandler(IHabitsRepository habitsRepository)
        {
            _habitsRepository = habitsRepository;
        }

        public async Task<ErrorOr<Success>> Handle(UpdateHabitCommand request, CancellationToken cancellationToken)
        {
            var habit = await _habitsRepository.GetByIdAsync(request.Id, cancellationToken);
            if (habit == null)
            {
                return Error.NotFound("Habit not found.");
            }

            habit.Name = request.Name;
            habit.Description = request.Description;

            await _habitsRepository.UpdateAsync(habit, cancellationToken);
            return Result.Success;
        }
    }
}
