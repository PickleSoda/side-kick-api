using Microsoft.EntityFrameworkCore;
using SideKick.Application.Common.Interfaces;
using SideKick.Domain.Habits;
using SideKick.Infrastructure.Common;

namespace SideKick.Infrastructure.Habits.Persistence;

public class HabitsRepository : IHabitsRepository
{
    private readonly AppDbContext _dbContext;

    public HabitsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Habit habit, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(habit, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Habit?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Habits.FirstOrDefaultAsync(h => h.Id == id, cancellationToken);
    }

    public async Task<List<Habit>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Habits.ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Habit habit, CancellationToken cancellationToken)
    {
        _dbContext.Update(habit);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(Habit habit, CancellationToken cancellationToken)
    {
        _dbContext.Remove(habit);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    // public async Task<List<Habit>> GetHabitsWithRemindersAsync(CancellationToken cancellationToken)
    // {
    //     return await _dbContext.Habits.Include(h => h.Reminders).ToListAsync(cancellationToken);
    // }

    // public async Task RemoveReminderFromHabitAsync(
    //     Guid habitId,
    //     Guid reminderId,
    //     CancellationToken cancellationToken)
    // {
    //     var habit = await _dbContext
    //         .Habits.Include(h => h.Reminders)
    //         .FirstOrDefaultAsync(h => h.Id == habitId, cancellationToken);
    //     if (habit != null)
    //     {
    //         var reminder = habit.Reminders.FirstOrDefault(r => r.Id == reminderId);
    //         if (reminder != null)
    //         {
    //             habit.Reminders.Remove(reminder);
    //             await _dbContext.SaveChangesAsync(cancellationToken);
    //         }
        // }
    // }
}
