using ErrorOr;
using MediatR;
using SideKick.Application.Common.Interfaces;
using SideKick.Domain.Habits;

namespace SideKick.Application.Habits.Queries.GetHabit
{
    public record GetHabitQuery(Guid Id) : IRequest<ErrorOr<HabitWithReminders>>;
    public class GetHabitQueryHandler : IRequestHandler<GetHabitQuery, ErrorOr<HabitWithReminders>>
    {
        private readonly IHabitsRepository _habitsRepository;
        private readonly IReminderSchedulesRepository _reminderSchedulesRepository;

        public GetHabitQueryHandler(IHabitsRepository habitsRepository, IReminderSchedulesRepository reminderSchedulesRepository)
        {
            _habitsRepository = habitsRepository;
            _reminderSchedulesRepository = reminderSchedulesRepository;
        }

        public async Task<ErrorOr<HabitWithReminders>> Handle(GetHabitQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine("GetHabit: " + request.Id);

            var habit = await _habitsRepository.GetByIdAsync(request.Id, cancellationToken);
            Console.WriteLine("Habit: " + habit);
            if (habit == null)
            {
                return Error.NotFound("Habit not found.");
            }

            var reminders = await _reminderSchedulesRepository.ListByHabitIdAsync(habit.Id, cancellationToken);
            Console.WriteLine("Reminders: " + reminders.Count);
            var habitWithReminders = new HabitWithReminders(habit, reminders);
            return habitWithReminders;
        }
    }
}
