using Microsoft.EntityFrameworkCore;

using SideKick.Application.Common.Interfaces;
using SideKick.Domain.Reminders;
using SideKick.Infrastructure.Common;

namespace SideKick.Infrastructure.Reminders.Persistence;

public class RemindersRepository(AppDbContext _dbContext) : IRemindersRepository
{
    public async Task AddAsync(Reminder reminder, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(reminder, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Reminder?> GetByIdAsync(Guid reminderId, CancellationToken cancellationToken)
    {
        return await _dbContext.Reminders.FindAsync(reminderId, cancellationToken);
    }

    public async Task<List<Reminder>> ListBySubscriptionIdAsync(Guid subscriptionId, CancellationToken cancellationToken)
    {
        return await _dbContext.Reminders
            .AsNoTracking()
            .Where(reminder => reminder.SubscriptionId == subscriptionId)
            .ToListAsync(cancellationToken);
    }

    public async Task RemoveAsync(Reminder reminder, CancellationToken cancellationToken)
    {
        _dbContext.Remove(reminder);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveRangeAsync(List<Reminder> reminders, CancellationToken cancellationToken)
    {
        _dbContext.RemoveRange(reminders, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Reminder reminder, CancellationToken cancellationToken)
    {
        _dbContext.Update(reminder);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
