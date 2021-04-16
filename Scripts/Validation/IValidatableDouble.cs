using SharedUtils.Common;

namespace SharedUtils.Validation
{
    public interface IValidatableDouble<T, R>
    {
        ErrorCode Validate(T t, R r);
    }
}
