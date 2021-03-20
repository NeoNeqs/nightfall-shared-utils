using Godot;

using SharedUtils.Common;
using SharedUtils.Exceptions;

namespace SharedUtils.Services
{
    public abstract class NetworkedPeer : Node
    {
        protected readonly NetworkedMultiplayerENet _peer;


        protected NetworkedPeer()
        {
            _peer = new NetworkedMultiplayerENet();
        }

        public override void _Process(float delta)
        {
            CustomMultiplayer.Poll();
        }

        protected virtual void Create()
        {
            CustomMultiplayer = new MultiplayerAPI
            {
                NetworkPeer = _peer,
                RootNode = this
            };
        }

        protected void SetupDTLS(string path)
        {
            _peer.DtlsVerify = false;
            _peer.UseDtls = true;
            if (!DirectoryUtils.DirExists(path)) throw new DirectoryNotFoundException($"Directory {path} does not exist");
        }

        protected abstract string GetCertificateName();
        protected abstract void ConnectSignals();
    }
}