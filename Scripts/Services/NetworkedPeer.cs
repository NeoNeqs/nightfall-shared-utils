using Godot;

using SharedUtils.Common;
using SharedUtils.Exceptions;
using SharedUtils.Loaders;
using SharedUtils.Networking;

namespace SharedUtils.Services
{
    /// <summary>
    ///     A base class for network connections.
    /// </summary>
    public abstract class NetworkedPeer<T> : GodotSingleton<T> where T : Node
    {
        protected readonly NetworkedMultiplayerENet _peer;

        /// <summary>
        ///     Returns id of last rpc sender.
        /// </summary>
        protected int RpcSenderId => CustomMultiplayer.GetRpcSenderId();

        protected NetworkedPeer()
        {
            _peer = new NetworkedMultiplayerENet();
        }

        public override void _Ready() => ConnectSignals();
        
        public override void _Process(float delta)
        {
            CustomMultiplayer.Poll();
        }

        [Remote]
        protected void OnPeerPacket(PacketType packetType, object arg1) => PeerPacket(packetType, arg1);
        [Remote]
        protected void OnPeerPacket(PacketType packetType, object arg1, object arg2) => PeerPacket(packetType, arg1, arg2);
        [Remote]
        protected void OnPeerPacket(PacketType packetType, object arg1, object arg2, object arg3) => PeerPacket(packetType, arg1, arg2, arg3);
        [Remote]
        protected void OnPeerPacket(PacketType packetType, object arg1, object arg2, object arg3, object arg4) => PeerPacket(packetType, arg1, arg2, arg3, arg4);
        [Remote]
        protected void OnPeerPacket(PacketType packetType, object arg1, object arg2, object arg3, object arg4, object arg5) => PeerPacket(packetType, arg1, arg2, arg3, arg4, arg5);

        protected virtual void Create()
        {
            CustomMultiplayer = new MultiplayerAPI
            {
                NetworkPeer = _peer,
                RootNode = this
            };
        }

        protected virtual string SetupDTLS()
        {
            string path = "user://DTLS/";

            _peer.DtlsVerify = false;
            _peer.UseDtls = true;

            // It's ok to throw here because DTLS is requried for network to work.
            if (!DirectoryUtils.DirExists(path)) throw new DirectoryNotFoundException($"Directory {path} does not exist");

            _peer.SetDtlsCertificate(X509CertificateLoader.Load(path, GetCertificateName(), out ErrorCode error));

            // Again, it's ok to throw here.
            if (error != ErrorCode.Ok) throw new X509CertificateNotFoundException($"Failed to load x509 certificate from '{path.PlusFile(GetCertificateName())}'");

            return path;
        }

        /// <summary>
        ///     Sends args to peerId. Actually calls OnPeerPacket method remotely on peerId.
        /// </summary>
        protected virtual void Send(int peerId, params object[] args)
        {
            RpcId(peerId, nameof(OnPeerPacket), args);
        }

        protected bool ValidateArgCount(PacketType packetType, int toValidate)
        {
            uint? expectedArgsCount = EnumHelper.GetAttributeOrNullOfType<PacketArgsCountAttribute>(packetType)?.PacketArgsCount;
#if DEBUG
            if (expectedArgsCount == null)
            {
                return false;
            }
#endif
            if (toValidate != expectedArgsCount) return false;

            return true;
        }

        protected abstract void PeerPacket(PacketType packetType, params object[] args);
        protected abstract string GetCertificateName();
        protected abstract void ConnectSignals();
    }
}