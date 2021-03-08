using SharedUtils.Common;

namespace SharedUtils.Services.Validators
{
    public interface IValidable<T>
    {
        ErrorCode IsValid(T toValidate);
    }
}