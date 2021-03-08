using Godot;

using SharedUtils.Common;

namespace SharedUtils.Loaders
{
    public sealed class X509CertificateLoader
    {
        public static X509Certificate Load(string from, string what, out ErrorCode outError)
        {
            var x509Certificate = new X509Certificate();
            var certificateFile = from.PlusFile(what);
            var error = x509Certificate.Load(certificateFile);
            outError = (ErrorCode)((int)error);
            return x509Certificate;
        }
    }
}