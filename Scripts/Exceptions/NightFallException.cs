using Godot;
using System;

namespace SharedUtils.Scripts.Exceptions
{
    public class NightFallException : Exception
    {
        public NightFallException(string message) : base(message)
        { 
            GD.Print(message);
        }
    }
}