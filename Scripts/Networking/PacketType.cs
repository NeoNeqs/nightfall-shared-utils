namespace SharedUtils.Networking
{
    public enum PacketType
    {
#if GATEWAY_SERVER || AUTHENTICATION_SERVER
        [PacketArgsCount(1u)]
        GatewayAuthentication = 0,
#endif

#if GAME_WORLD_SERVER || AUTHENTICATION_SERVER
        [PacketArgsCount(1u)] 
        GameServerAuthentication = 1,
#endif

#if CLIENT || GATEWAY_SERVER
        [PacketArgsCount(2u)]
        ClientToGatewayServerAuthentication = 2,

        [PacketArgsCount(1u)]
        GatewayServerToClientTokenForward = 3,
#endif

#if GATEWAY_SERVER || AUTHENTICATION_SERVER
        [PacketArgsCount(3u)]
        GatewayServerToAuthenticationServerAuthentication = 4,

        [PacketArgsCount(2u)]
        AuthenticationServerToGatewayServerResponse = 5,
#endif

#if GATEWAY_SERVER || GAME_WORLD_SERVER
        [PacketArgsCount(2u)]
        GatewayServerToGameWorldServerTokenForward = 6,
#endif

#if CLIENT || GAME_WORLD_SERVER
        [PacketArgsCount(1u)]
        ClientToGameWorldServerSendToken = 7,
#endif

    }
}
