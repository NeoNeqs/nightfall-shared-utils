using Godot;
using SharedUtils.Common;

namespace SharedUtils.Services.Validators
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