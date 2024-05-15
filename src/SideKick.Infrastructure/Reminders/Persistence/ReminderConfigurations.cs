using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SideKick.Domain.Reminders;

namespace SideKick.Infrastructure.Reminders.Persistence;

public class ReminderConfigurations : IEntityTypeConfiguration<Reminder>
{
    public void Configure(EntityTypeBuilder<Reminder> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .ValueGeneratedNever();

        builder.Property(r => r.UserId);

        builder.Property(r => r.SubscriptionId);

        builder.Property(r => r.DateTime);

        builder.Property(r => r.Text);
    }
}
