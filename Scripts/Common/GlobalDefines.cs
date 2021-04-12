using System.Diagnostics;

namespace SharedUtils.Common
{
    public static class GlobalDefines
    {
        public static readonly string GatewayTokenPrefix = "GATEWAY_TOKEN";
        public static readonly string GameWorldTokenPrefix = "GAME_WORLD_TOKEN";

        public const ushort MaxInputLength = 32;
        public const int MaxAttemptsDefault = 100;

        public const int DefaultInternalPort = 4444;
        public const int DefaultPublicPort = 4445;
        public const int DefaultGameWorldPort = 4446;
    }
}