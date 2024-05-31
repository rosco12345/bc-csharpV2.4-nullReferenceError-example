using Org.BouncyCastle.Crypto;

namespace BouncyCastleV2._4Triage;

public class KeyPair
{
    private readonly PrivateKey _privateKey;
    private readonly PublicKey _publicKey;

    internal KeyPair(AsymmetricCipherKeyPair keyPair)
        : this(keyPair.Private, keyPair.Public)
    {
    }

    private KeyPair(AsymmetricKeyParameter privateKey, AsymmetricKeyParameter publicKey)
        : this(new PrivateKey(privateKey), new PublicKey(publicKey)) 
    {
    }

    public KeyPair(PrivateKey privateKey, PublicKey publicKey)
    {
        _privateKey = privateKey;
        _publicKey = publicKey;
    }

    public PrivateKey PrivateKey
    {
        get { return _privateKey; }
    }

    public PublicKey PublicKey
    {
        get { return _publicKey; }
    }
}
