using Godot;

using GatewayServer.AutoLoad;

using SharedUtils.Common;
using SharedUtils.Exceptions;
using SharedUtils.Loaders;
using SharedUtils.Networking;
using SharedUtils.Services.Validators;

using ConnectionStatus = Godot.NetworkedMultiplayerPeer.ConnectionStatus;
using SharedUtils.Logging;

namespace SharedUtils.Services
{
    /// <summary>
    ///     A base class for network connections.
    /// </summary>
    public abstract class NetworkedPeer<T> : GodotSingleton<T> where T : Node
    {
        protected NetworkedMultiplayerENet _peer;

        private int attempts;

        private int maxAttempts;

        public NetworkedPeer()
        {
            attempts = 0;
        }

        public override void _EnterTree()
        {
            maxAttempts = ClientConfiguration.Singleton.GetMaxAttempts(GlobalDefines.MaxAttemptsDefault);

            CreateInternal();
        }

        public override void _Process(float delta)
        {
            CustomMultiplayer.Poll();
        }

        private void CreateInternal()
        {
            _peer = new NetworkedMultiplayerENet
            {
                DtlsVerify = false,
                UseDtls = true
            };

            _ = SetupDTLS();

            Create();

            CustomMultiplayer = new MultiplayerAPI
            {
                NetworkPeer = _peer
            };

            CustomMultiplayer.SetRootNode(this);

            ConnectSignals();
        }

        protected void Reconnect()
        {
            if (attempts > maxAttempts)
            {
                Logger.Warn($"The number of attempts to reconnect exceeded {maxAttempts}");
                return;
            }

            if (GetConnectionStatus() == ConnectionStatus.Connected)
            {
                CloseConnection();
            }

            CreateInternal();
            Logger.Info($"Reconnect attempt #{attempts}");
            attempts++;
        }

        protected virtual string SetupDTLS()
        {
            string path = "user://DTLS/";

            // It's ok to throw here because DTLS is requried for network to work.
            if (!DirectoryUtils.DirExists(path))
            {
                throw new DirectoryNotFoundException(path);
            }

            _peer.SetDtlsCertificate(X509CertificateLoader.Load(path, GetCertificateName(), out ErrorCode error));

            // Again, it's ok to throw here.
            if (error != ErrorCode.Ok)
            {
                throw new X509CertificateNotFoundException(path.PlusFile(GetCertificateName()));
            }

            return path;
        }

        protected void CloseConnection()
        {
            _peer.CloseConnection();
        }

        protected ConnectionStatus GetConnectionStatus()
        {
            return _peer.GetConnectionStatus();
        }

        protected bool IsArgsCountCorrect(PacketType packetType, int length)
        {
            PacketArgsCountValidator packetArgsCountValidator = new PacketArgsCountValidator();
            return packetArgsCountValidator.Validate(packetType, length) == ErrorCode.Ok;
        }

        [Remote]
        protected void PacketReceived(PacketType packetType, object arg1)
        {
            OnPacketReceivedInternal(packetType, arg1);
        }

        [Remote]
        protected void PacketReceived(PacketType packetType, object arg1, object arg2)
        {
            OnPacketReceivedInternal(packetType, arg1, arg2);
        }

        [Remote]
        protected void PacketReceived(PacketType packetType, object arg1, object arg2, object arg3)
        {
            OnPacketReceivedInternal(packetType, arg1, arg2, arg3);
        }

        [Remote]
        protected void PacketReceived(PacketType packetType, object arg1, object arg2, object arg3, object arg4)
        {
            OnPacketReceivedInternal(packetType, arg1, arg2, arg3, arg4);
        }

        [Remote]
        protected void PacketReceived(PacketType packetType, object arg1, object arg2, object arg3, object arg4, object arg5)
        {
            OnPacketReceivedInternal(packetType, arg1, arg2, arg3, arg4, arg5);
        }

        private void OnPacketReceivedInternal(PacketType packetType, params object[] args)
        {
            if (IsArgsCountCorrect(packetType, args.Length))
            {
                OnPacketReceived(packetType, args);
                return;
            }
#if DEBUG
            Logger.Warn($"Peer 'id: {CustomMultiplayer.GetRpcSenderId()}' sent 'packetType: {packetType}' with wrong number of arguments ({args.Length})");
#endif
        }
        protected abstract void OnPacketReceived(PacketType packetType, params object[] args);
        protected abstract string GetCertificateName();
        protected abstract void ConnectSignals();
        protected abstract int GetPort();
        protected abstract void Create();
    }
}