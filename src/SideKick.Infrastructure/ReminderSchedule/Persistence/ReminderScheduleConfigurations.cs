using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SideKick.Domain.ReminderSchedules;
using SideKick.Domain.ReminderSchedules.ReminderTypes;

namespace SideKick.Infrastructure.ReminderSchedules.Persistence;

public class ReminderScheduleConfigurations : IEntityTypeConfiguration<ReminderSchedule>
{
    public void Configure(EntityTypeBuilder<ReminderSchedule> builder)
    {
        builder.HasKey(rs => rs.Id);

        builder.Property(rs => rs.Id).ValueGeneratedNever();

        builder.Property(rs => rs.TextTemplate).IsRequired();

        builder.Property(rs => rs.Time).IsRequired();

        builder.Property(rs => rs.RequiresConfirmation).IsRequired();

        builder.Property(rs => rs.IsActive).IsRequired();

        builder.Property(rs => rs.HabitId).IsRequired();

        builder.Property(rs => rs.Priority).IsRequired();

        builder.Property(rs => rs.DayIndex).IsRequired();

        builder
            .Property(rs => rs.ReminderType)
            .HasConversion(v => v.Value, v => ReminderType.FromValue(v))
            .IsRequired();

        builder.Property(rs => rs.DayOfCommitment).IsRequired();

        builder.Property(rs => rs.Mon);
        builder.Property(rs => rs.Tue);
        builder.Property(rs => rs.Wed);
        builder.Property(rs => rs.Thu);
        builder.Property(rs => rs.Fri);
        builder.Property(rs => rs.Sat);
        builder.Property(rs => rs.Sun);
    }
}
