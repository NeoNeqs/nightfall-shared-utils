using Godot;
using SharedUtils.Scripts.Common;

namespace SharedUtils.Scripts.Services.Validators
{
    public sealed class PathValidator : IValidable<string>
    {
        public ErrorCode IsValid(string toValidate)
        {
            if (!(toValidate.IsAbsPath() || toValidate.IsRelPath())) return ErrorCode.DirBadPath;
            return ErrorCode.Ok;
        }
    }
}