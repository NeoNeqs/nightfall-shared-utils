namespace SharedUtils.Logging.Strings
{
    public static class ErrorMessages
    {
        public static readonly string GeneralException = "General Exception was thrown: ";

        public static string GatewayIdAlreadyExists(int peerId, string ipAddress, string token)
        {
            return $"Peer 'id: {peerId}, ip: {ipAddress}' tried to authenticate as a Gateway with the 'token: {token}', but the Gateway with that id already exists.";
        }

        public static string GameWorldIdAlreadyExists(int peerId, string ipAddress, string token)
        {
            return $"Peer 'id: {peerId}, ip: {ipAddress}' tried to authenticate as a Game World with the 'token: {token}', but the Game World with that id already exists.'";
        }

        public static string GatewayInvalidToken(int peerId, string ipAddress, string token)
        {
            return $"Peer 'id: {peerId}, ip: {ipAddress}' sent invalid Gateway 'token: {token}'";
        }

        public static string GameWorldInvalidToken(int peerId, string ipAddress, string token)
        {
            return $"Peer 'id: {peerId}, ip: {ipAddress}' sent invalid Game World 'token: {token}'";
        }

        public static string GatewayTokenAlreadyInUse(int peerId, string ipAddress, string token)
        {
            return $"Peer 'id: {peerId}, ip: {ipAddress}' sent a valid Gateway 'token: {token}' that is already in use. ";
        }

        public static string GameWorldTokenAlreadyInUse(int peerId, string ipAddress, string token)
        {
            return $"Peer 'id: {peerId}, ip: {ipAddress}' sent a valid Game World 'token: {token}' that is already in use. ";
        }
    }
}
