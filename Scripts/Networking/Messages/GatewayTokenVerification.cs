using System;

namespace SharedUtils.Networking.Messages
{
    [Serializable]
    public class GatewayTokenVerification
    {
        public readonly string token;
    }
}
