using ErrorOr;
using MediatR;
using SideKick.Application.Common.Interfaces;
using SideKick.Domain.ReminderSchedules;

namespace SideKick.Application.Habits.Queries.GetRemindersByHabit
{
    public record GetRemindersByHabitQuery(Guid HabitId) : IRequest<ErrorOr<List<ReminderSchedule>>>;

    public class GetRemindersByHabitQueryHandler : IRequestHandler<GetRemindersByHabitQuery, ErrorOr<List<ReminderSchedule>>>
    {
        private readonly IHabitsRepository _habitsRepository;
        private readonly IReminderSchedulesRepository _reminderSchedulesRepository;

        public GetRemindersByHabitQueryHandler(IHabitsRepository habitsRepository, IReminderSchedulesRepository reminderSchedulesRepository)
        {
            _habitsRepository = habitsRepository;
            _reminderSchedulesRepository = reminderSchedulesRepository;
        }

        public async Task<ErrorOr<List<ReminderSchedule>>> Handle(GetRemindersByHabitQuery request, CancellationToken cancellationToken)
        {
            var habit = await _habitsRepository.GetByIdAsync(request.HabitId, cancellationToken);
            if (habit == null)
            {
                return Error.NotFound("Habit not found.");
            }

            var reminderSchedules = await _reminderSchedulesRepository.ListByHabitIdAsync(habit.Id, cancellationToken);
            return reminderSchedules;
        }
    }
}
