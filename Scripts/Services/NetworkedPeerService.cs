using Godot;

using SharedUtils.Scripts.Common;

namespace SharedUtils.Scripts.Services
{
    public abstract class NetworkedPeerService : Node
    {
        protected readonly NetworkedMultiplayerENet _peer;


        protected NetworkedPeerService()
        {
            _peer = new NetworkedMultiplayerENet();
        }

        protected virtual void Create()
        {
            GetTree().NetworkPeer = _peer;
        }

        protected virtual Error SetupDTLS(string path)
        {
            _peer.DtlsVerify = false;
            _peer.UseDtls = true;
            if (!DirectoryUtils.DirExists(path))
                return Error.FileBadPath;
            return Error.Ok;
        }

        protected abstract string GetCryptoKeyName();
        protected abstract string GetCertificateName();
    }
}