// using SideKick.Domain.Commitments;
// using TestCommon.TestConstants;

// namespace TestCommon.Commitments
// {
//     public static class CommitmentCommandFactory
//     {
//         public static CreateCommitmentCommand CreateCreateCommitmentCommand(
//             Guid? userId = null,
//             Habit? targetHabit = null,
//             int lengthInDays = 30)
//         {
//             return new CreateCommitmentCommand(
//                 userId ?? Constants.User.Id,
//                 targetHabit ?? new Habit("Default Habit"),
//                 lengthInDays);
//         }
//         // Add more commands as needed
//     }
// }