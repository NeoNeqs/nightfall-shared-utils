using Godot;
using ServersUtils.Scripts.Logging;

namespace SharedUtils.Scripts.Loaders
{
    public sealed class X509CertificateLoader
    {
        public static X509Certificate Load(string from, string what, out Error outError)
        {
            var x509Certificate = new X509Certificate();
            var certificateFile = from.PlusFile(what);
            var error = x509Certificate.Load(certificateFile);
            if (error != Error.Ok)
            {
                ServerLogger.GetLogger.Error($"Could not load key file {ProjectSettings.GlobalizePath(certificateFile)}. Error code: {error}");
            }
            outError = error;
            return x509Certificate;
        }
    }
}