using System;

namespace SharedUtils.Networking
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PacketArgsCountAttribute : Attribute
    {
        public uint PacketArgsCount { get; set; }

        public PacketArgsCountAttribute(uint packetArgsCount) : base()
        {
            PacketArgsCount = packetArgsCount;
        }
    }
}