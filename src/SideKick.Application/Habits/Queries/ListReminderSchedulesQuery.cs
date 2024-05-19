using ErrorOr;
using MediatR;
using SideKick.Application.Common.Interfaces;
using SideKick.Domain.ReminderSchedules;

namespace SideKick.Application.ReminderSchedules.Queries.ListReminderSchedules
{
    public record ListReminderSchedulesQuery() : IRequest<ErrorOr<List<ReminderSchedule>>>;

    public class ListReminderSchedulesQueryHandler : IRequestHandler<ListReminderSchedulesQuery, ErrorOr<List<ReminderSchedule>>>
    {
        private readonly IReminderSchedulesRepository _reminderSchedulesRepository;

        public ListReminderSchedulesQueryHandler(IReminderSchedulesRepository reminderSchedulesRepository)
        {
            _reminderSchedulesRepository = reminderSchedulesRepository;
        }

        public async Task<ErrorOr<List<ReminderSchedule>>> Handle(ListReminderSchedulesQuery request, CancellationToken cancellationToken)
        {
            var reminderSchedules = await _reminderSchedulesRepository.GetAllAsync(cancellationToken);
            Console.WriteLine("Reminder schedules: " + reminderSchedules.Count);
            if (reminderSchedules.Count == 0)
            {
                return Error.NotFound("No reminder schedules found.");
            }

            return reminderSchedules;
        }
    }
}
