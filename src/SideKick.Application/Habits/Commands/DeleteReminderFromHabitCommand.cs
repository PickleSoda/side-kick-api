using ErrorOr;
using MediatR;
using SideKick.Application.Common.Interfaces;
namespace SideKick.Application.Habits.Commands.DeleteReminderFromHabit
{
    public record DeleteReminderFromHabitCommand(Guid HabitId, Guid ReminderId) : IRequest<ErrorOr<Success>>;

    public class DeleteReminderFromHabitCommandHandler : IRequestHandler<DeleteReminderFromHabitCommand, ErrorOr<Success>>
    {
        private readonly IHabitsRepository _habitsRepository;
        private readonly IMediator _mediator;

        public DeleteReminderFromHabitCommandHandler(IHabitsRepository habitsRepository, IMediator mediator)
        {
            _habitsRepository = habitsRepository;
            _mediator = mediator;
        }

        public async Task<ErrorOr<Success>> Handle(DeleteReminderFromHabitCommand request, CancellationToken cancellationToken)
        {
            var habit = await _habitsRepository.GetByIdAsync(request.HabitId, cancellationToken);
            if (habit == null)
            {
                return Error.NotFound("Habit not found.");
            }

            if (!habit.RemoveReminder(request.ReminderId))
            {
                return Error.NotFound("Reminder not found.");
            }

            await _habitsRepository.UpdateAsync(habit, cancellationToken);

            // Publish an event after successfully deleting the reminder from the habit
            // await _mediator.Publish(new ReminderRemovedFromHabitEvent(request.HabitId, request.ReminderId), cancellationToken);
            return Result.Success;
        }
    }
}
