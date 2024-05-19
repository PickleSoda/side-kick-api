using SideKick.Domain.ReminderSchedules;

namespace SideKick.Application.Common.Interfaces;

public interface IReminderSchedulesRepository
{
    Task AddAsync(ReminderSchedule reminderSchedule, CancellationToken cancellationToken);
    Task<ReminderSchedule?> GetByIdAsync(Guid reminderScheduleId, CancellationToken cancellationToken);
    Task<List<ReminderSchedule>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<ReminderSchedule>> ListByHabitIdAsync(Guid habitId, CancellationToken cancellationToken);
    Task RemoveAsync(ReminderSchedule reminderSchedule, CancellationToken cancellationToken);
    Task RemoveRangeAsync(List<ReminderSchedule> reminderSchedules, CancellationToken cancellationToken);
    Task UpdateAsync(ReminderSchedule reminderSchedule, CancellationToken cancellationToken);
}
