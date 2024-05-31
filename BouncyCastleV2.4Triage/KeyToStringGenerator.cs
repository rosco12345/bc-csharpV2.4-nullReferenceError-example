using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;

namespace BouncyCastleV2._4Triage;

public static class KeyToStringConverter
{
    public static KeyPair LoadKeyPair(string privateKeyString)
    {
        var asymmetricCipherKeyPair = LoadPem<AsymmetricCipherKeyPair>(privateKeyString);

        var privateKey = new PrivateKey(asymmetricCipherKeyPair.Private);
        var publicKey = new PublicKey(asymmetricCipherKeyPair.Public);

        return new KeyPair(privateKey, publicKey);
    }
    
    private static T LoadPem<T>(string key)
    {
        using (var stringReader = new StringReader(key))
        {
            var pemReader = new PemReader(stringReader);
            return (T) pemReader.ReadObject();
        }
    }
}