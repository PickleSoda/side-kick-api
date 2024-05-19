using ErrorOr;
using MediatR;
using SideKick.Application.Common.Interfaces;
using SideKick.Domain.Habits;
using SideKick.Domain.ReminderSchedules;

namespace SideKick.Application.Habits.Queries.ListHabits
{
    public record ListHabitsQuery : IRequest<ErrorOr<List<Habit>>>;

    public class ListHabitsQueryHandler : IRequestHandler<ListHabitsQuery, ErrorOr<List<Habit>>>
    {
        private readonly IHabitsRepository _habitsRepository;

        public ListHabitsQueryHandler(IHabitsRepository habitsRepository)
        {
            _habitsRepository = habitsRepository;
        }

        public async Task<ErrorOr<List<Habit>>> Handle(ListHabitsQuery request, CancellationToken cancellationToken)
        {
            var habits = await _habitsRepository.GetAllAsync(cancellationToken);
            Console.WriteLine("Habits: " + habits.Count);
            if (habits.Count == 0)
            {
                return Error.NotFound("No habits found.");
            }

            return habits;
        }
    }
}
