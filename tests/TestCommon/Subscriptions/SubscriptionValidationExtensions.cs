using SideKick.Application.Subscriptions.Commands.CreateSubscription;
using SideKick.Application.Subscriptions.Common;

using FluentAssertions;

namespace TestCommon.Subscriptions;

public static class SubscriptionValidationExtensions
{
    public static void AssertCreatedFrom(this SubscriptionResult subscriptionType, CreateSubscriptionCommand command)
    {
        subscriptionType.SubscriptionType.Should().Be(command.SubscriptionType);
        subscriptionType.UserId.Should().Be(command.UserId);
    }
}