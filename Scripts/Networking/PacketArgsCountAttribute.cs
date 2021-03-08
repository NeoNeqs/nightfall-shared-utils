using System;

namespace SharedUtils.Networking
{
    public class PacketArgsCountAttribute : Attribute
    {
        public uint PacketCount { get; set; }

        public PacketArgsCountAttribute(uint packetCount) : base()
        {
            PacketCount = packetCount;
        }
    }
}