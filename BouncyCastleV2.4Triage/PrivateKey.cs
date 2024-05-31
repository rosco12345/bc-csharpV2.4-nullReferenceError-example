using Org.BouncyCastle.Crypto;

namespace BouncyCastleV2._4Triage;

public class PrivateKey
{
    private readonly AsymmetricKeyParameter _value;

    internal PrivateKey(AsymmetricKeyParameter value)
    {
        if (!value.IsPrivate)
        {
            throw new ArgumentException("Expected a private key", nameof(value));
        }

        _value = value;
    }

    internal AsymmetricKeyParameter Value
    {
        get { return _value; }
    }
}