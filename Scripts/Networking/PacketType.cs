namespace SharedUtils.Networking
{
    public enum PacketType
    {
        [PacketArgsCount(1u)]
        GatewayTokenVerification,

        [PacketArgsCount(1u)]
        GameWorldTokenVerification,

        [PacketArgsCount(1u)]
        TokenVerificationResponse,

        [PacketArgsCount(2u)]
        ClientPartialAuth,

        [PacketArgsCount(3u)]
        ForwardedClientVerification,

        [PacketArgsCount(3u)]
        ForwardedClientVerificationResponse,

        [PacketArgsCount(1u)]
        ForwardedClientVerificationToken,

        [PacketArgsCount(2u)]
        GatewayServerAuthResponse,

    }
}
