using System;
using Nightfall.SharedUtils.Collections;
using Nightfall.SharedUtils.InfoCodes;

namespace Nightfall.SharedUtils.Net.Messaging
{
    public static class MessageFactory
    {
        private static readonly BiDirectionalMap<int, Type> RegisteredMessageTypes = new();
        
        public static NFError RegisterMessage<T>() where T : Message, new()
        {
            var messageType = typeof(T);
            var messageTypeCode = messageType.Name.GetHashCode();
            
            return RegisteredMessageTypes.Add(messageTypeCode, messageType);
        }

        public static (int, NFError) GetTypeCodeOf<T>() where T : Message, new()
        {
            var error = RegisteredMessageTypes.TryGetKey(typeof(T), out var key);

            return (key, error);
        }

        public static Message GetMessage(int typeCode)
        {
            RegisteredMessageTypes.TryGetValue(typeCode, out var type);

            if (type is null)
            {
                return EmptyMessage.Empty;
            }

            return (Message) Activator.CreateInstance(type);
        }

        public static NFError UnregisterMessage<T>() where T : Message, new()
        {
            return RegisteredMessageTypes.Remove(typeof(T));
        }

        public static NFError UnregisterMessage(int typeCode)
        {
            return RegisteredMessageTypes.Remove(typeCode);
        }
    }
}