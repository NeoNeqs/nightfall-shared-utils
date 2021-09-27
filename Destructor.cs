using System;

namespace Nightfall.SharedUtils
{
    public sealed class Destructor
    {
        private readonly Action _action;

        public Destructor(Action action)
        {
            _action = action;
        }

        ~Destructor()
        {
            _action();
        }
    }
}