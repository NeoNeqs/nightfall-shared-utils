using System;
using Godot;
using Nightfall.SharedUtils.InfoCodes;

namespace Nightfall.SharedUtils.Net.Messaging
{
    /// <summary>
    /// This class represents and parses raw packet data.
    /// </summary>
    /// <remarks>
    /// It's lifetime is managed by Godot through reference counting (see <see cref="Godot.RefCounted"/> for more details).
    /// </remarks>
    public abstract partial class Message : RefCounted
    {
        public const byte PacketTypeSize = sizeof(int);

        protected byte[] Data { set; get; } = { };

        protected (byte[], NFError) PrepareBuffer<T>() where T : Message, new()
        {
            var data = new byte[PacketTypeSize + Data.Length];
            var (typeCode, error) = MessageFactory.GetTypeCodeOf<T>();

            if (error != NFError.Ok) return (data, error);
            var typeCodeBytes = BitConverter.GetBytes(typeCode);

            for (var i = 0; i < PacketTypeSize; i++)
            {
                data[i] = typeCodeBytes[i];
            }

            return (data, error);
        }

        public virtual (byte[], NFError) Serialize()
        {
            return (null, NFError.MessageEmpty);
        }

        public static (Message, NFError) Create(StreamPeerTCP streamPeer)
        {
            var result = streamPeer.GetData(streamPeer.GetAvailableBytes());

            var error = (Error) (long) result[0];
            var packetData = (byte[]) result[1];

            if (error != Error.Ok)
            {
                return (EmptyMessage.Empty, error);
            }

            switch (packetData.Length)
            {
                case 0:
                    return (EmptyMessage.Empty, NFError.NoDataSupplied);
                case < 5:
                    return (EmptyMessage.Empty, NFError.NotEnoughData);
            }

            var message = MessageFactory.GetMessage(BitConverter.ToInt32(packetData));
            var data = new byte[packetData.Length - PacketTypeSize];
            
            Buffer.BlockCopy(packetData, PacketTypeSize, data, 0, data.Length);
            message.Data = data;
            
            return (message, NFError.Ok);
        }
    }
}