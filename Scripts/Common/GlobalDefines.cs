namespace SharedUtils.Common
{
    public static class GlobalDefines
    {
        // TODO: distribute this amoung proper classes for each Authentication, Gateway, Client, etc.
        public const string GatewayTokenPrefix = "GATEWAY_TOKEN";
        public const string GameWorldTokenPrefix = "GAME_WORLD_TOKEN";

        public const ushort MaxInputLength = 32;
        public const int MaxAttemptsDefault = 100;

        public const int InternalPortDefault = 4444;
        public const int PublicPortDefault = 4445;
        public const int GameWorldPortDefault = 4446;

        public const string AuthenticationGatewayCertificateName = "ag.crt";
        public const string AuthenticationGatewayCryptoKeyName = "ag.key";
    }
}