using SharedUtils.Scripts.Common;

namespace SharedUtils.Scripts.Services.Validators
{
    public interface IValidable<T>
    {
        ErrorCode IsValid(T toValidate);
    }
}