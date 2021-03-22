namespace SharedUtils.Networking
{
    public enum PacketType
    {
        [PacketArgsCount(1u)]
        GatewayServerAuth = 1,

        [PacketArgsCount(1u)]
        GameWorldServerAuth = 2,

        [PacketArgsCount(2u)]
        ClientPartialAuth = 3,

        [PacketArgsCount(3u)]
        GatewayServerAuthForward = 4,

        [PacketArgsCount(3u)]
        AuthenticationServerAuthResponse = 5,

        [PacketArgsCount(1u)]
        AuthenticationServerSendToken = 6,

        [PacketArgsCount(2u)]
        GatewayServerAuthResponse = 7,

    }
}
