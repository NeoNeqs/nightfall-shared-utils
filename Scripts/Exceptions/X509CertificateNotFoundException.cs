using System;

namespace SharedUtils.Scripts.Exceptions
{
    public class X509CertificateNotFoundException : Exception
    {

        public X509CertificateNotFoundException(string path) : base($"Failed to load x509 certificate from '{path}'")
        {
        }

    }
}