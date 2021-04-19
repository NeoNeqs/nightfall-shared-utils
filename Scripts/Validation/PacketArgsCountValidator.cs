using SharedUtils.Common;
using SharedUtils.Networking;

namespace SharedUtils.Validation
{
    public class PacketArgsCountValidator : IValidatable<Packet, int>
    {
        public ErrorCode Validate(Packet packet, int toValidate)
        {
            uint? expectedArgsCount = EnumHelper.GetFirstAttributeOrNullOfType<PacketArgsCountAttribute>(packet)?.PacketArgsCount;

            if (expectedArgsCount == null) return ErrorCode.MissingAttribute;
            if (toValidate != expectedArgsCount) return ErrorCode.NotValid;

            return ErrorCode.Ok;
        }
    }
}
