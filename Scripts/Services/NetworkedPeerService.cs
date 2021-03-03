using Godot;

using SharedUtils.Scripts.Logging;
using SharedUtils.Scripts.Common;

namespace SharedUtils.Scripts.Services
{
    public abstract class NetworkedPeerService : Service
    {
        protected readonly NetworkedMultiplayerENet _peer;


        protected NetworkedPeerService()
        {
            _peer = new NetworkedMultiplayerENet();
        }

        public override void _EnterTree()
        {
            SetupDTLS("user://DTLS/");
        }

        protected virtual void Create()
        {
            GetTree().NetworkPeer = _peer;
        }

        protected virtual void SetupDTLS(string path)
        {
            _peer.DtlsVerify = false;
            _peer.UseDtls = true;
            if (!DirectoryUtils.DirExists(path))
            {
                Logger.Error($"Directory {ProjectSettings.GlobalizePath(path)} doesn't exist!. Abording");
                QuitIfError((int)Error.FileBadPath);
            }
        }
    }
}