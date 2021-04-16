using Godot;

using SharedUtils.Common;

namespace SharedUtils.Loaders
{
    public sealed class X509CertificateLoader
    {
        public static X509Certificate Load(string from, string what, out ErrorCode outError)
        {
            X509Certificate x509Certificate = new X509Certificate();
            string certificateFile = from.PlusFile(what);
            Error error = x509Certificate.Load(certificateFile);
            outError = (int)error;
            return x509Certificate;
        }
    }
}