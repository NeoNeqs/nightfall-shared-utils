using Godot;
using System;

namespace SharedUtils.Exceptions
{
    public class NightFallException : Exception
    {
        public NightFallException(string message) : base(message)
        { 
            //GD.LogError(message);
        }
    }
}