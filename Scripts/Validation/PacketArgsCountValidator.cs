using SharedUtils.Common;
using SharedUtils.Networking;

namespace SharedUtils.Validation
{
    public class PacketArgsCountValidator : IValidatableDouble<PacketType, int>
    {
        public ErrorCode Validate(PacketType packetType, int toValidate)
        {
            uint? expectedArgsCount = EnumHelper.GetFirstAttributeOrNullOfType<PacketArgsCountAttribute>(packetType)?.PacketArgsCount;

            if (expectedArgsCount == null) return ErrorCode.MissingAttribute;
            if (toValidate != expectedArgsCount) return ErrorCode.NotValid;

            return ErrorCode.Ok;
        }
    }
}
