using ErrorOr;
using SideKick.Domain.Common;

namespace SideKick.Domain.Reminders;

public class Reminder : Entity
{
    public Guid UserId { get; private set; }

    public Guid SubscriptionId { get; private set; }

    public DateTime DateTime { get; private set; }

    public DateOnly Date => DateOnly.FromDateTime(DateTime.Date);

    public string Text { get; } = null!;

    public bool IsDismissed { get; private set; }

    public Guid CommitmentId { get; private set; }

    public Reminder(
        Guid userId,
        Guid subscriptionId,
        string text,
        DateTime dateTime,
        Guid? commitmentId = null,
        Guid? id = null)
            : base(id ?? Guid.NewGuid())
    {
        UserId = userId;
        SubscriptionId = subscriptionId;
        Text = text;
        DateTime = dateTime;
        CommitmentId = commitmentId ?? Guid.Empty;
    }

    public ErrorOr<Success> Dismiss()
    {
        if (IsDismissed)
        {
            return Error.Conflict(description: "Reminder already dismissed");
        }

        IsDismissed = true;

        return Result.Success;
    }

    // Ensure this parameterless constructor is only for EF purposes if using EF
    private Reminder()
    {
    }
}
