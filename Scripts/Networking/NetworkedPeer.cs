using Godot;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using SharedUtils.Common;
using SharedUtils.Exception;
using SharedUtils.Loaders;
using SharedUtils.Logging;
using SharedUtils.Validation;

using static SharedUtils.Factory.SharedSingletonFactory;

using DirectoryNotFoundException = SharedUtils.Exception.DirectoryNotFoundException;
using ConnectionStatus = Godot.NetworkedMultiplayerPeer.ConnectionStatus;

namespace SharedUtils.Networking
{
    /// <summary>
    ///     A base class for network connections.
    /// </summary>
    public abstract class NetworkedPeer : Node
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
            maxAttempts = StandartConfigurationInstance.GetMaxAttempts(SharedGlobalDefinesInstance.MaxAttemptsDefault);

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
        protected void PacketReceived(PacketType packetType, byte[] bytes)
        {
            object @object = BinaryTools.Deserialize(bytes);

            OnPacketReceived(packetType, @object);
        }

        protected void Send(int peerId, object @object)
        {
            _ = RpcId(peerId, nameof(PacketReceived), BinaryTools.Serialize(@object));
        }

        protected abstract void OnPacketReceived(PacketType packetType, object @object);
        protected abstract string GetCertificateName();
        protected abstract void ConnectSignals();
        protected abstract int GetPort();
        protected abstract int GetMaxClients();
        protected abstract void Create();
    }
}