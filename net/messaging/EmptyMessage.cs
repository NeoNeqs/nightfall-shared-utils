namespace Nightfall.SharedUtils.Net.Messaging
{
    public sealed partial class EmptyMessage : Message
    {
        public static readonly EmptyMessage Empty = new();
    }
}