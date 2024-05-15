// using FluentAssertions;
// using SideKick.Application.Commitments.Commands.CreateCommitment;
// using SideKick.Domain.Commitments;

// namespace TestCommon.Commitments
// {
//     public static class CommitmentValidator
//     {
//         public static void AssertCreatedFrom(this Commitment commitment, CreateCommitmentCommand command)
//         {
//             commitment.CreatorId.Should().Be(command.UserId);
//             commitment.TargetHabit.Should().Be(command.TargetHabit);
//             commitment.LengthInDays.Should().Be(command.LengthInDays);
//             commitment.Status.Should().Be(CommitmentStatus.Pending);
//         }
//     }
// }
