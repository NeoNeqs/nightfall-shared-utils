namespace SharedUtils.Networking
{
    public enum Packet
    {
        #region GatewayToAuthentication

        [PacketArgsCount(1u)]
        GatewayToAuthenticationTokenVarification = 0,

        [PacketArgsCount(3u)]
        GatewayToAuthenticationClientAuth,

        #endregion


        #region GameWorldToAuthentication

        [PacketArgsCount(2u)]
        GameWorldToAuthenticationTokenVerification,

        #endregion


        #region AuthenticationToGateway

        [PacketArgsCount(1u)]
        AuthenticationToGatewayTokenVerification,

        #endregion


        #region AuthenticationToGameWorld

        [PacketArgsCount(1u)]
        AuthenticationToGameWorldTokenVerification,

        #endregion


        #region AuthenticationToGateway

        [PacketArgsCount(3u)]
        AuthenticationToGatewayClientAuth,

        [PacketArgsCount(2u)]
        ClientToGatewayClientAuth,

        #endregion
        //[PacketArgsCount(1u)]
        //ForwardedClientVerificationToken,

        //[PacketArgsCount(2u)]
        //GatewayServerAuthResponse,

    }
}
