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
                throw new System.IO.DirectoryNotFoundException($"Directory {path} does not exist");
        }

        protected abstract string GetCryptoKeyName();
        protected abstract string GetCertificateName();
        protected abstract void ConnectSignals(NetworkedPeerService to);
    }
}