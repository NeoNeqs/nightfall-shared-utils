using Godot;
using SharedUtils.Logging;
using System;

namespace SharedUtils.Exceptions
{
    public class NightFallException : Exception
    {
        public NightFallException(string message) : base(message)
        {
        }
    }
}