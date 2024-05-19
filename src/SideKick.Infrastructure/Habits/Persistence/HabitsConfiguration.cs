using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SideKick.Domain.Habits;
using SideKick.Domain.ReminderSchedules;

using SideKick.Infrastructure.Common.Persistence;

namespace SideKick.Infrastructure.Habits.Persistence;

public class HabitsConfiguration : IEntityTypeConfiguration<Habit>
{
    public void Configure(EntityTypeBuilder<Habit> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(h => h.Id)
            .ValueGeneratedNever();

        builder.Property(h => h.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(h => h.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property<List<Guid>>("_reminderIds")
            .HasColumnName("ReminderIds")
            .HasListOfIdsConverter();

        // Configure navigation property for ReminderSchedules (if applicable)
        // If the relationship is managed through foreign keys, adjust accordingly.
        builder.HasMany<ReminderSchedule>()
            .WithOne()
            .HasForeignKey(rs => rs.HabitId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
