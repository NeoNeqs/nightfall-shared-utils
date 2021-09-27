using System;
using Godot;

namespace Nightfall.SharedUtils
{
    public partial class NFGuid : RefCounted
    {
        private NFGuid() { }
        public Guid Guid { private set; get; }

        public static NFGuid NewGuid()
        {
            var nfGuid = new NFGuid
            {
                Guid = Guid.NewGuid()
            };
        
            return nfGuid;
        }
    }
}