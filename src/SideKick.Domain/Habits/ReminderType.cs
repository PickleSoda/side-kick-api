using Ardalis.SmartEnum;

namespace SideKick.Domain.ReminderSchedules.ReminderTypes;

public abstract class ReminderType : SmartEnum<ReminderType>
    {
        protected ReminderType(string name, int value)
            : base(name, value) { }

        public static readonly ReminderType OneTime = new OneTimeType();
        public static readonly ReminderType Recurrent = new RecurrentType();

        public abstract int GetReminderLimit();

        private sealed class OneTimeType : ReminderType
        {
            public OneTimeType()
            : base(nameof(OneTime), 0) { }

            public override int GetReminderLimit() => 1; // Example limit for OneTime
        }

        private sealed class RecurrentType : ReminderType
        {
            public RecurrentType()
            : base(nameof(Recurrent), 1) { }

            public override int GetReminderLimit() => int.MaxValue; // Example limit for Recurrent
        }
    }