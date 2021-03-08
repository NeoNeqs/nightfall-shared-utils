namespace SharedUtils.Networking
{
    public enum PacketType
    {
        [PacketArgsCount(1)] GatewayAuthentication = 0,
        [PacketArgsCount(1)] GameServerAuthentication = 1,
    }
}
