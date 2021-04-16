using SharedUtils.Common;

namespace SharedUtils.Validation
{
    public interface IValidatable<T>
    {
        ErrorCode IsValid(T toValidate);
    }
}