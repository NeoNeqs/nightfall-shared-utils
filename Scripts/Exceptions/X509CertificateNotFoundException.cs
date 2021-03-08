using SharedUtils.Exceptions;

namespace SharedUtils.Exceptions
{
    public class X509CertificateNotFoundException : NightFallException
    {

        public X509CertificateNotFoundException(string message) : base(message)
        {
        }

    }
}