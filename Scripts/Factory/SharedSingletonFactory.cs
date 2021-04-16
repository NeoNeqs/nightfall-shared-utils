using Godot;

using SharedUtils.Common;
using SharedUtils.Configuration;
using SharedUtils.Networking;

namespace SharedUtils.Factory
{
    public abstract class SharedSingletonFactory : Node 
    {
        public static NetworkedPeer NetworkedPeerInstance { get; protected set; }
        public static StandartConfiguration StandartConfigurationInstance { get; protected set; }
        public static SharedGlobalDefines SharedGlobalDefinesInstance { get; protected set; }


        public override void _Ready()
        {
            //instance = GetNodeOrNull<SharedSingletonFactory>(".");
            AddChild(NetworkedPeerInstance);
            AddChild(StandartConfigurationInstance);
        }
    }
}
