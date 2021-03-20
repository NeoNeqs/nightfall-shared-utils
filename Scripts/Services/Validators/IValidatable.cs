using SharedUtils.Common;

namespace SharedUtils.Services.Validators
{
    public interface IValidatable<T>
    {
        ErrorCode IsValid(T toValidate);
    }
}