using ErrorOr;
using MediatR;
using SideKick.Application.Common.Interfaces;
using SideKick.Domain.ReminderSchedules;
using SideKick.Domain.ReminderSchedules.ReminderTypes;

namespace SideKick.Application.Habits.Commands.AddReminderToHabit
{
    public record AddReminderToHabitCommand(
        Guid HabitId,
        string Text,
        DateTime ReminderTime,
        ReminderType ReminderType,
        bool RequiresConfirmation,
        bool IsActive,
        int Priority,
        int DayIndex,
        int? DayOfCommitment = null,
        bool? Mon = null,
        bool? Tue = null,
        bool? Wed = null,
        bool? Thu = null,
        bool? Fri = null,
        bool? Sat = null,
        bool? Sun = null) : IRequest<ErrorOr<ReminderSchedule>>;

    public class AddReminderToHabitCommandHandler : IRequestHandler<AddReminderToHabitCommand, ErrorOr<ReminderSchedule>>
    {
        private readonly IHabitsRepository _habitsRepository;

        public AddReminderToHabitCommandHandler(IHabitsRepository habitsRepository)
        {
            _habitsRepository = habitsRepository;
        }

        public async Task<ErrorOr<ReminderSchedule>> Handle(AddReminderToHabitCommand request, CancellationToken cancellationToken)
        {
            var habit = await _habitsRepository.GetByIdAsync(request.HabitId, cancellationToken);
            if (habit == null)
            {
                return Error.NotFound("Habit not found.");
            }

            ReminderSchedule reminder;

            if (request.ReminderType == ReminderType.OneTime)
            {
                if (request.DayOfCommitment == null)
                {
                    return Error.Validation("DayOfCommitment is required for one-time reminders.");
                }

                reminder = ReminderSchedule.CreateOneTimeReminder(
                    Guid.NewGuid(),
                    request.Text,
                    TimeOnly.FromDateTime(request.ReminderTime),
                    request.RequiresConfirmation,
                    request.IsActive,
                    request.HabitId,
                    request.DayOfCommitment.Value,
                    request.Priority,
                    request.DayIndex);
            }
            else if (request.ReminderType == ReminderType.Recurrent)
            {
                reminder = ReminderSchedule.CreateRecurrentReminder(
                    Guid.NewGuid(),
                    request.Text,
                    TimeOnly.FromDateTime(request.ReminderTime),
                    request.RequiresConfirmation,
                    request.IsActive,
                    request.HabitId,
                    request.Mon ?? false,
                    request.Tue ?? false,
                    request.Wed ?? false,
                    request.Thu ?? false,
                    request.Fri ?? false,
                    request.Sat ?? false,
                    request.Sun ?? false,
                    request.Priority,
                    request.DayIndex);
            }
            else
            {
                return Error.Validation("Invalid reminder type.");
            }

            habit.AddReminder(reminder);

            await _habitsRepository.UpdateAsync(habit, cancellationToken);
            return reminder;
        }
    }
}
