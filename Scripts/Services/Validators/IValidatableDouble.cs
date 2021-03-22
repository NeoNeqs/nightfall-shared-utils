using SharedUtils.Common;

namespace SharedUtils.Services.Validators
{
    public interface IValidatableDouble<T, R>
    {
        ErrorCode Validate(T t, R r);
    }
}
