using ErrorOr;
using MediatR;
using SideKick.Application.Common.Interfaces;
using SideKick.Domain.ReminderSchedules;

namespace SideKick.Application.ReminderSchedules.Queries.GetReminderSchedule
{
    public record GetReminderScheduleQuery(Guid ReminderScheduleId) : IRequest<ErrorOr<ReminderSchedule>>;

    public class GetReminderScheduleQueryHandler : IRequestHandler<GetReminderScheduleQuery, ErrorOr<ReminderSchedule>>
    {
        private readonly IReminderSchedulesRepository _reminderSchedulesRepository;

        public GetReminderScheduleQueryHandler(IReminderSchedulesRepository reminderSchedulesRepository)
        {
            _reminderSchedulesRepository = reminderSchedulesRepository;
        }

        public async Task<ErrorOr<ReminderSchedule>> Handle(GetReminderScheduleQuery request, CancellationToken cancellationToken)
        {
            var reminderSchedule = await _reminderSchedulesRepository.GetByIdAsync(request.ReminderScheduleId, cancellationToken);
            if (reminderSchedule == null)
            {
                return Error.NotFound("Reminder schedule not found.");
            }

            return reminderSchedule;
        }
    }
}
