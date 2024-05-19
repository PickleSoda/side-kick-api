using ErrorOr;
using MediatR;
using SideKick.Application.Common.Interfaces;
using SideKick.Application.Common.Security.Permissions;
using SideKick.Application.Common.Security.Request;
using SideKick.Domain.Habits;
using SideKick.Domain.Reminders;

namespace SideKick.Application.Habits.Commands.CreateHabit
{
    [Authorize(Permissions = Permission.Habit.Create)]
    public record CreateHabitCommand(string Name, string Description) : IRequest<ErrorOr<Habit>>;

    public class CreateHabitCommandHandler : IRequestHandler<CreateHabitCommand, ErrorOr<Habit>>
    {
        private readonly IHabitsRepository _habitsRepository;

        public CreateHabitCommandHandler(IHabitsRepository habitsRepository)
        {
            _habitsRepository = habitsRepository;
        }

        public async Task<ErrorOr<Habit>> Handle(CreateHabitCommand request, CancellationToken cancellationToken)
        {
            var habit = new Habit(Guid.NewGuid(), request.Name, request.Description);

            await _habitsRepository.AddAsync(habit, cancellationToken);
            return habit;
        }
    }
}
