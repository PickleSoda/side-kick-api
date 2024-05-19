using ErrorOr;
using MediatR;
using SideKick.Application.Common.Interfaces;
using SideKick.Domain.Habits;

namespace SideKick.Application.Habits.Queries.GetHabit
{
    public record GetHabitQuery(Guid Id) : IRequest<ErrorOr<Habit>>;

    public class GetHabitQueryHandler : IRequestHandler<GetHabitQuery, ErrorOr<Habit>>
    {
        private readonly IHabitsRepository _habitsRepository;

        public GetHabitQueryHandler(IHabitsRepository habitsRepository)
        {
            _habitsRepository = habitsRepository;
        }

        public async Task<ErrorOr<Habit>> Handle(GetHabitQuery request, CancellationToken cancellationToken)
        {
            var habit = await _habitsRepository.GetByIdAsync(request.Id, cancellationToken);
            if (habit == null)
            {
                return Error.NotFound("Habit not found.");
            }

            return habit;
        }
    }
}
