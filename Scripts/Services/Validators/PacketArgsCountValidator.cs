using SharedUtils.Common;
using SharedUtils.Networking;

namespace SharedUtils.Services.Validators
{
    public class PacketArgsCountValidator : IValidatableDouble<PacketType, int>
    {
        public ErrorCode Validate(PacketType packetType, int toValidate)
        {
            uint? expectedArgsCount = EnumHelper.GetAttributeOrNullOfType<PacketArgsCountAttribute>(packetType)?.PacketArgsCount;

            if (expectedArgsCount == null) return ErrorCode.MissingAttribute;
            if (toValidate != expectedArgsCount) return ErrorCode.NotValid;

            return ErrorCode.Ok;
        }
    }
}
