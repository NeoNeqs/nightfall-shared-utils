namespace SharedUtils.Common
{
    public static class Messages
    {
        public static string PeerConnected(int peerId, string ipAddress)
        {
            return $"Peer 'id: {peerId}, ip: {ipAddress}' has connected";
        }

        public static string PeerDisconnected(int peerId, string ipAddress)
        {
            return $"Peer 'id: {peerId}, ip: {ipAddress}' has disconnected";
        }

        public static string GatewayAuthenticated(int peerId, string ipAddress)
        {
            return $"Peer 'id: {peerId}, ip: {ipAddress}' has been authenticated as a Gateway.";
        }

        public static string GameWorldAuthenticated(int peerId, string ipAddress)
        {
            return $"Peer 'id: {peerId}, ip: {ipAddress}' has been authenticated as a Game World.";
        }
    }
}
