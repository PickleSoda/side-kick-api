using Microsoft.EntityFrameworkCore;
using SideKick.Application.Common.Interfaces;
using SideKick.Domain.ReminderSchedules;
using SideKick.Infrastructure.Common;

namespace SideKick.Infrastructure.ReminderSchedules.Persistence;

public class ReminderSchedulesRepository : IReminderSchedulesRepository
{
    private readonly AppDbContext _dbContext;

    public ReminderSchedulesRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(ReminderSchedule reminderSchedule, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(reminderSchedule, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<ReminderSchedule?> GetByIdAsync(Guid reminderScheduleId, CancellationToken cancellationToken)
    {
        return await _dbContext.ReminderSchedules.FindAsync(reminderScheduleId, cancellationToken);
    }

    public async Task<List<ReminderSchedule>> ListByHabitIdAsync(Guid habitId, CancellationToken cancellationToken)
    {
        return await _dbContext.ReminderSchedules
            .AsNoTracking()
            .Where(rs => rs.HabitId == habitId)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<ReminderSchedule>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.ReminderSchedules
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task RemoveAsync(ReminderSchedule reminderSchedule, CancellationToken cancellationToken)
    {
        _dbContext.Remove(reminderSchedule);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveRangeAsync(List<ReminderSchedule> reminderSchedules, CancellationToken cancellationToken)
    {
        _dbContext.RemoveRange(reminderSchedules);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(ReminderSchedule reminderSchedule, CancellationToken cancellationToken)
    {
        _dbContext.Update(reminderSchedule);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
