using SharedUtils.Exceptions;

namespace SharedUtils.Exceptions
{
    public class X509CertificateNotFoundException : NightFallException
    {

        public X509CertificateNotFoundException(string cert) : base($"Failed to load x509 certificate from '{cert}'")
        {
        }

    }
}