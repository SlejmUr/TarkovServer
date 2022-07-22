using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace ServerLib.Utilities
{
    public class CertHelper
    {
        public static void Make(System.Net.IPAddress serveraddress,string ip_port)
        {
            if (serveraddress == null)
            {
                return;
            }
            if (!Directory.Exists("cert"))
            {
                Directory.CreateDirectory("cert");
                MakeCert(serveraddress, "cert/cert.pem", "cert/key.pem", ip_port);
            }
            else if (!File.Exists("cert/cert.pem") && !File.Exists("cert/key.pem"))
            {
                MakeCert(serveraddress, "cert/cert.pem", "cert/key.pem", ip_port);
            }
            else
            {
                return;
            }
            Console.WriteLine("Generated self-signed certificate");
        }
        private static void MakeCert(System.Net.IPAddress serveraddress, string certFilename, string keyFilename, string ip_port)
        {
            const string CRT_HEADER = "-----BEGIN CERTIFICATE-----\n";
            const string CRT_FOOTER = "\n-----END CERTIFICATE-----";

            const string KEY_HEADER = "-----BEGIN RSA PRIVATE KEY-----\n";
            const string KEY_FOOTER = "\n-----END RSA PRIVATE KEY-----";

            using var rsa = RSA.Create();
            var certRequest = new CertificateRequest($"cn={ip_port}", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            // Adding SubjectAlternativeNames (SAN)
            var subjectAlternativeNames = new SubjectAlternativeNameBuilder();
            subjectAlternativeNames.AddIpAddress(serveraddress);
            certRequest.CertificateExtensions.Add(subjectAlternativeNames.Build());

            // We're just going to create a temporary certificate, that won't be valid for long
            var certificate = certRequest.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1));
            // export the private key
            var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey(), Base64FormattingOptions.InsertLineBreaks);

            File.WriteAllText(keyFilename, KEY_HEADER + privateKey + KEY_FOOTER);

            // Export the certificate
            var exportData = certificate.Export(X509ContentType.Cert);

            var crt = Convert.ToBase64String(exportData, Base64FormattingOptions.InsertLineBreaks);
            File.WriteAllText(certFilename, CRT_HEADER + crt + CRT_FOOTER);

            File.WriteAllBytes("cert/cert.pfx", certificate.Export(X509ContentType.Pfx));
        }
    }
}
