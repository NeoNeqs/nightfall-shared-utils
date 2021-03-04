using Godot;
using System;

namespace SharedUtils.Scripts.Exceptions
{
    public class X509CertificateNotFoundException : Exception
    {

        public X509CertificateNotFoundException(string message) : base(message)
        {
        }

    }
}