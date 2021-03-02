
using Godot;

namespace SharedUtils.Scripts.Services.Validators
{
    public interface IValidable<T>
    {
        Error IsValid(T toValidate);
    }
}