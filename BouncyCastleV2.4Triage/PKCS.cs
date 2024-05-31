using System.Text;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;

namespace BouncyCastleV2._4Triage;

public static class PKCS
{
    public static string Encrypt(PublicKey publicKey, string value)
    {
        return
            new Base64er().Encrypt(
                new Coder().Encrypt(
                    new Crypter(publicKey.Value).Encrypt(
                        new UTF8er().Encrypt(value))));
    }

    public static string Decrypt(PrivateKey privateKey, string value)
    {
        return
            new UTF8er().Decrypt(
                new Crypter(privateKey.Value).Decrypt(
                    new Coder().Decrypt(
                        new Base64er().Decrypt(value))));
    }

    private interface ICryptoPipeline<T1, T2>
    {
        T2 Encrypt(T1 value);
        T1 Decrypt(T2 value);
    }

    private sealed class UTF8er : ICryptoPipeline<string, byte[]>
    {
        private static readonly Encoding Encoding  = Encoding.UTF8;

        public byte[] Encrypt(string value)
        {
            return Encoding.GetBytes(value);
        }

        public string Decrypt(byte[] value)
        {
            return Encoding.GetString(value);
        }
    }

    private sealed class Crypter : ICryptoPipeline<byte[], CmsEnvelopedData>
    {
        private static readonly byte[] SubjectKeyIdentifier = Array.Empty<byte>();

        private readonly AsymmetricKeyParameter _key;

        internal Crypter(AsymmetricKeyParameter key)
        {
            _key = key;
        }

        public CmsEnvelopedData Encrypt(byte[] value)
        {
            var generator = new CmsEnvelopedDataGenerator();
            generator.AddKeyTransRecipient(_key, SubjectKeyIdentifier);
            return generator.Generate(new CmsProcessableByteArray(value), CmsEnvelopedGenerator.Aes256Cbc);
        }

        public byte[] Decrypt(CmsEnvelopedData value)
        {
            var recipientID = new RecipientID { SubjectKeyIdentifier = SubjectKeyIdentifier };
            return value.GetRecipientInfos().GetFirstRecipient(recipientID).GetContent(_key);
        }
    }

    private sealed class Coder : ICryptoPipeline<CmsEnvelopedData, byte[]>
    {
        public byte[] Encrypt(CmsEnvelopedData value)
        {
            return value.GetEncoded();
        }

        public CmsEnvelopedData Decrypt(byte[] value)
        {
            return new CmsEnvelopedData(value);
        }
    }

    private sealed class Base64er : ICryptoPipeline<byte[], string>
    {
        public string Encrypt(byte[] value)
        {
            return Convert.ToBase64String(value);
        }

        public byte[] Decrypt(string value)
        {
            return Convert.FromBase64String(value);
        }
    }
}
