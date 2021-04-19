using SharedUtils.Common;

namespace SharedUtils.Validation
{
    public interface IValidatable<T>
    {
        ErrorCode IsValid(T t);
    }

    public interface IValidatable<T, R>
    {
        ErrorCode Validate(T t, R r);
    }
}