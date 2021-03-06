using SharedUtils.Scripts.Exceptions;

namespace SharedUtils.Scripts.Exceptions
{
    public class X509CertificateNotFoundException : NightFallException
    {

        public X509CertificateNotFoundException(string message) : base(message)
        {
        }

    }
}