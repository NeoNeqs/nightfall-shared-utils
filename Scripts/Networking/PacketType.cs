namespace SharedUtils.Networking
{
    public enum PacketType
    {
        [PacketArgsCount(1u)] GatewayAuthentication = 0,
        [PacketArgsCount(1u)] GameServerAuthentication = 1,
    }
}
