using System.Diagnostics.CodeAnalysis;
using Value = System.Int64;

namespace Nightfall.SharedUtils.Logging
{
    [SuppressMessage("ReSharper", "BuiltInTypeReferenceStyle")]
    public struct Level
    {
        private Value InternalValue { set; get; }

        public const Value Debug = 0;
        public const Value Info = 1;
        public const Value Warn = 2;
        public const Value Error = 3;
        public const Value Critical = 4;

        public static implicit operator Level(Value value)
        {
            return new Level
            {
                InternalValue = value
            };
        }

        public static implicit operator Value(Level level)
        {
            return level.InternalValue;
        }

        public override string ToString()
        {
            return InternalValue switch
            {
                Debug => nameof(Debug),
                Info => nameof(Info),
                Warn => nameof(Warn),
                Error => nameof(Error),
                Critical => nameof(Critical),
                _ => string.Empty,
            };
        }
    }
}