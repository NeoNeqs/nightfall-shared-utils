namespace SharedUtils.Common
{
    public class SharedGlobalDefines
    {
        // TODO: distribute this amoung proper classes for each Authentication, Gateway, Client, etc.
        public readonly string GatewayTokenPrefix = "GATEWAY_TOKEN";
        public readonly string GameWorldTokenPrefix = "GAME_WORLD_TOKEN";

        public readonly ushort MaxInputLength = 32;
        public readonly int MaxAttemptsDefault = 100;

        public readonly int DefaultInternalPort = 4444;
        public readonly int DefaultPublicPort = 4445;
        public readonly int DefaultGameWorldPort = 4446;

    }
}