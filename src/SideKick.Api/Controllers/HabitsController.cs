using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using SideKick.Application.Habits.Commands.AddReminderToHabit;
using SideKick.Application.Habits.Commands.CreateHabit;
using SideKick.Application.Habits.Commands.DeleteHabit;
using SideKick.Application.Habits.Queries.GetHabit;
using SideKick.Application.Habits.Queries.ListHabits;
using SideKick.Contracts.Common;

using SideKick.Contracts.Habits;
using SideKick.Contracts.ReminderSchedules;
using SideKick.Domain.Habits;
using SideKick.Domain.ReminderSchedules;
using DomainReminderType = SideKick.Domain.ReminderSchedules.ReminderTypes.ReminderType;

namespace SideKick.Api.Controllers
{
    [Route("api/habits")]
    public class HabitsController : ApiController
    {
        private readonly ISender _mediator;

        public HabitsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHabit(CreateHabitRequest request)
        {
            Console.WriteLine("CreateHabitRequest: " + request);
            var command = new CreateHabitCommand(request.Name, request.Description);

            var result = await _mediator.Send(command);

            return result.Match(
                habit => CreatedAtAction(
                    actionName: nameof(GetHabit),
                    routeValues: new { HabitId = habit.Id },
                    value: ToDto(habit)),
                Problem);
        }

        [HttpPost("{habitId:guid}/reminders")]
        public async Task<IActionResult> AddReminderToHabit(Guid habitId, AddReminderToHabitRequest request)
        {
            if (!DomainReminderType.TryFromName(request.ReminderType.ToString(), out var reminderType))
            {
                return Problem(
                    statusCode: StatusCodes.Status400BadRequest,
                    detail: "Invalid reminder type");
            }

            var command = new AddReminderToHabitCommand(
                habitId,
                request.TextTemplate,
                request.ReminderTime,
                reminderType,
                request.RequiresConfirmation,
                request.IsActive,
                request.Priority,
                request.DayIndex,
                request.DayOfCommitment,
                request.Mon,
                request.Tue,
                request.Wed,
                request.Thu,
                request.Fri,
                request.Sat,
                request.Sun);

            var result = await _mediator.Send(command);

            return result.Match(
                reminder => CreatedAtAction(
                    actionName: nameof(GetHabit),
                    routeValues: new { HabitId = habitId },
                    value: reminder.Id),
                Problem);
        }

        [HttpDelete("{habitId:guid}")]
        public async Task<IActionResult> DeleteHabit(Guid habitId)
        {
            var command = new DeleteHabitCommand(habitId);

            var result = await _mediator.Send(command);

            return result.Match(
                _ => NoContent(),
                Problem);
        }

        [HttpGet("{habitId:guid}")]
        public async Task<IActionResult> GetHabit(Guid habitId)
        {
            var query = new GetHabitQuery(habitId);

            var result = await _mediator.Send(query);

            return result.Match(
                habit => Ok(ToDto(habit)),
                Problem);
        }

        [HttpGet]
        public async Task<IActionResult> ListHabits()
        {
            var query = new ListHabitsQuery();

            var result = await _mediator.Send(query);

            Console.WriteLine("ListHabitsQuery: " + query);

            return result.Match(
                habits => Ok(habits.ConvertAll(ToDto)),
                Problem);
        }

        private HabitResponse ToDto(Habit habit)
        {
            return new HabitResponse(
                habit.Id,
                habit.Name,
                habit.Description);
        }

        private ReminderScheduleResponse ToDto(ReminderSchedule reminderSchedule)
        {
        return new ReminderScheduleResponse(
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
}

        private static ReminderType ToDto(DomainReminderType reminderType) =>
            reminderType.Name switch
            {
                nameof(DomainReminderType.OneTime) => ReminderType.OneTime,
                nameof(DomainReminderType.Recurrent) => ReminderType.Recurrent,
                _ => throw new InvalidOperationException(),
            };
    }
}
