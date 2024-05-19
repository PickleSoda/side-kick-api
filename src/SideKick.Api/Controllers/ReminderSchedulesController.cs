using MediatR;
using Microsoft.AspNetCore.Mvc;
using SideKick.Application.ReminderSchedules.Common;
using SideKick.Application.ReminderSchedules.Queries.GetReminderSchedule;
using SideKick.Application.ReminderSchedules.Queries.ListReminderSchedules;
using SideKick.Contracts.Common;
using SideKick.Contracts.ReminderSchedules;
using DomainReminderType = SideKick.Domain.ReminderSchedules.ReminderTypes.ReminderType;

namespace SideKick.Api.Controllers
{
    [Route("api/reminderschedules")]
    public class ReminderSchedulesController : ApiController
    {
        private readonly ISender _mediator;

        public ReminderSchedulesController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{reminderScheduleId:guid}")]
        public async Task<IActionResult> GetReminderSchedule(Guid reminderScheduleId)
        {
            var query = new GetReminderScheduleQuery(reminderScheduleId);

            var result = await _mediator.Send(query);

            return result.Match(
                reminderSchedule => Ok(ToDto(ReminderScheduleResult.FromReminderSchedule(reminderSchedule))),
                Problem);
        }

        [HttpGet]
        public async Task<IActionResult> ListReminderSchedules()
        {
            var query = new ListReminderSchedulesQuery();

            var result = await _mediator.Send(query);

            return result.Match(
                reminderSchedules => Ok(reminderSchedules.ConvertAll(r => ToDto(ReminderScheduleResult.FromReminderSchedule(r)))),
                Problem);
        }

        private ReminderScheduleResponse ToDto(ReminderScheduleResult reminderSchedule) =>
            new(
                reminderSchedule.Id,
                reminderSchedule.TextTemplate,
                reminderSchedule.Time,
                reminderSchedule.RequiresConfirmation,
                reminderSchedule.IsActive,
                reminderSchedule.Priority,
                reminderSchedule.DayIndex,
                ToDto(reminderSchedule.ReminderType),
                reminderSchedule.DayOfCommitment,
                reminderSchedule.Mon,
                reminderSchedule.Tue,
                reminderSchedule.Wed,
                reminderSchedule.Thu,
                reminderSchedule.Fri,
                reminderSchedule.Sat,
                reminderSchedule.Sun);

        private static ReminderType ToDto(DomainReminderType reminderType) =>
            reminderType.Name switch
            {
                nameof(DomainReminderType.OneTime) => ReminderType.OneTime,
                nameof(DomainReminderType.Recurrent) => ReminderType.Recurrent,
                _ => throw new InvalidOperationException(),
            };
    }
}
